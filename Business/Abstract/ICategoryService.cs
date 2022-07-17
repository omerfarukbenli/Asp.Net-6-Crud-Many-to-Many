using Entities.Dtos;
using Entities.Models;
using Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IResponse<List<GetCategoryDto>>> GetCategories(string searchTerm);
        Task<IResponse<GetCategoryDto>> Post(CreateCategoryDto categoryDto);
        Task<IResponse<List<GetCategoryDto>>> GetCategoriesID(int id);
        Task<IResponse<UpdateCategoryDto>> Update(UpdateCategoryDto categoryDto, int id);
        Task<IResponse<bool>> DeleteByIdAsync(int id);
        Task<IResponse<List<GetListCategory>>> GetAllCategory();
        Task<IResponse<Category>> AddCategoryProduct(CreateandCategoryDto category);
    }
}
