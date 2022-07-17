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
    public interface IProductService
    {
        Task<IResponse<List<GetProductDto>>> GetProducts(string searchTerm); //
        Task<IResponse<GetProductDto>> Post(CreateProductDto productDto); //
        Task<IResponse<List<GetProductDto>>> GetProductsID(int id);
        Task<IResponse<UpdateProductDto>> Update(UpdateProductDto productDto, int id); //
        Task<IResponse<bool>> DeleteByIdAsync(int id);
        Task<IResponse<List<GetListProductDto>>> GetAllProduct();
        Task<IResponse<Product>> AddProductCategory(CreateandProductDto products);
    }
}
