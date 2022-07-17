using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Entities.Dtos;
using Entities.Models;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResponse<Product>> AddProductCategory(CreateandProductDto products)
        {
            try
            {
             var product = _mapper.Map<Product>(products);


            await _unitOfWork.Product.AddProduct(product);

            foreach (var pr in products.Categories)
            {
                await _unitOfWork.Product.AddCategoryProduct(product.Id, pr);
            }
                var response = new Response<Product>()
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = product
                };
                return response;
           
            }
            catch (Exception ex)
            {

                return new Response<Product>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
            
        }

        public async Task<IResponse<bool>> DeleteByIdAsync(int id)
        {

            try
            {
             var category = await _unitOfWork.Product.GetProduct(id);
             
            if (category != null)
            {
                await _unitOfWork.Product.Delete(category);

               
            }
            else
            {
                throw new ValidationException("kategori bulunmadı");
            }
                var response = new Response<bool>()
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true

                };
                return response;
            }
            catch (Exception ex)
            {

                return new Response<bool>()
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = true

                };
            }
            
        }

        public async Task<IResponse<List<GetListProductDto>>> GetAllProduct()
        {
            try
            {
                var a = await _unitOfWork.Product.GetAll();
                var list = _mapper.Map<List<GetListProductDto>>(a);
                var response = new Response<List<GetListProductDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<GetListProductDto>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<IResponse<List<GetProductDto>>> GetProducts(string searchTerm)
        {
            try
            {
               if    (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ValidationException("Arama bölümü boş olamaz");
            }
            var a = _mapper.Map<List<GetProductDto>>(await _unitOfWork.Product.GetProducts(searchTerm));
                var b = new Response<List<GetProductDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = a
                };

                return b;
            }
            catch (Exception ex)
            {

                return new Response<List<GetProductDto>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
            
        }

        public async Task<IResponse<List<GetProductDto>>> GetProductsID(int id)
        {
            var category = await _unitOfWork.Product.GetProductsId(id);
            var list = _mapper.Map<List<GetProductDto>>(category);
            if (category.Count > 0)
            {
                return new Response<List<GetProductDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };
            }
            else
            {
                return new Response<List<GetProductDto>>
                {
                    Message = "Böyle bir kategori bulunamadı.",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<IResponse<GetProductDto>> Post(CreateProductDto productDto)
        {

            try
            {
            var category = _mapper.Map<Product>(productDto);
            var existingCat = await _unitOfWork.Product.ProductExists(productDto.Name);
            //
            

            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetProductDto>(existingCat);
                
            }
            await _unitOfWork.Product.AddProduct(category);
            var categoryForGetDto = _mapper.Map<GetProductDto>(category);
                var response = new Response<GetProductDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = categoryForGetDto
                };
                return response;
            }
            catch (Exception ex)
            {

                return new Response<GetProductDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
            
           
        }

        public async Task<IResponse<UpdateProductDto>> Update(UpdateProductDto productDto, int id)
        {

            try
            {
            var ownerEntity = await _unitOfWork.Product.GetProduct(id);
          _mapper.Map<GetProductDto>(ownerEntity);
            _mapper.Map(productDto, ownerEntity);
          await _unitOfWork.Product.Update(ownerEntity, id);
                var response = new Response<UpdateProductDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data  = productDto
                };
                return response;
            }

            catch (Exception ex)
            {

                return new Response<UpdateProductDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
            

            
        }
    }
}
