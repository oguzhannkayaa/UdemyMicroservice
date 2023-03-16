using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Service.Catalog.Model;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Service.Catalog.Services
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync();


        Task<ResponseDto<CategoryDto>> CreateAsync(Category category);



        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);
 
    }
}
