using AutoMapper;
using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Service.Catalog.Model;
using FreeCourse.Service.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;

namespace FreeCourse.Service.Catalog.Services
{
    public class CourseService : ICourseService
    {

        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Course>(databaseSettings.CourceCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);


            _mapper = mapper;
        }

        public async Task<ResponseDto<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();
            
            if (courses.Any())
            {
                foreach(var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.Category_Id).FirstOrDefaultAsync();
                }
            }
            else 
            {
                courses = new List<Course>();
            }

            return ResponseDto<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);

        }
    
        public async Task<ResponseDto<CourseDto>> GetByIdAsync(string id) {

            var course = await _courseCollection.Find<Course>(x => x.Id == id).SingleOrDefaultAsync();
            if(course == null)
            {
                return ResponseDto<CourseDto>.Fail("Course not found", 404);
            }

            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.Category_Id).FirstOrDefaultAsync();

            return ResponseDto<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        
        }
    
        public async Task<ResponseDto<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x => x.UserId == userId).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.Category_Id).FirstOrDefaultAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return ResponseDto<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<ResponseDto<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);

            newCourse.CreatedTime = DateTime.Now;
            
            await _courseCollection.InsertOneAsync(newCourse);

            return ResponseDto<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);

        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id,updateCourse);

            if(result == null)
            {
                return ResponseDto<NoContent>.Fail("Course not found",404);
            }

            return ResponseDto<NoContent>.Success(200);
        }

        public async Task<ResponseDto<NoContent>> DeleteAsync(string id)
        {
            var course = await _courseCollection.FindAsync(c => c.Id == id);

            if (!course.Any())
            {
                return ResponseDto<NoContent>.Fail("No course record found", 404);
            }
            
                await _courseCollection.DeleteOneAsync(c => c.Id == id);

            return ResponseDto<NoContent>.Success(200); 
        }


    }
}
