﻿using FreeCourse.Service.Catalog.Dtos;
using FreeCourse.Service.Catalog.Model;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Service.Catalog.Services
{
    public interface ICourseService
    {

        Task<ResponseDto<List<CourseDto>>> GetAllAsync();


        Task<ResponseDto<CourseDto>> GetByIdAsync(string id);


        Task<ResponseDto<List<CourseDto>>> GetAllByUserIdAsync(string userId);


        Task<ResponseDto<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);


        Task<ResponseDto<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);


        Task<ResponseDto<NoContent>> DeleteAsync(string id);

    }
}
