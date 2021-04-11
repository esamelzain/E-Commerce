using E_CommerceApi.Authentication;
using E_CommerceApi.Handlers;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class ProductImageService
    {
        private readonly ApplicationDbContext _db;
        public ProductImageService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllProductImageResponses> GetAll()
        {
            try
            {
                var dbProductImages = await _db.ProductImages.ToListAsync();
                if (dbProductImages.Count > 0)
                {
                    return new AllProductImageResponses
                    {
                        ProductImage = dbProductImages,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllProductImageResponses
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllProductImageResponses
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.ProductImageRes> Get(int Id)
        {
            try
            {
                var dbProductImage = await _db.ProductImages.SingleOrDefaultAsync(ProductImage => ProductImage.Id == Id);
                if (dbProductImage != null)
                {
                    return new Models.vModels.ProductImageRes
                    {
                        ProductImageResponse = dbProductImage,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.ProductImageRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.ProductImageRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.ProductImage ProductImage)
        {
            try
            {
                await _db.ProductImages.AddAsync(ProductImage);
                await _db.SaveChangesAsync();
                return new BaseResponse
                {
                    Message = Helper.GetResponseMessage(200)
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Edit(Models.dbModels.ProductImage ProductImage)
        {
            try
            {
                var dbProductImage = await _db.ProductImages.SingleOrDefaultAsync(ProductImage => ProductImage.Id == ProductImage.Id);
                if (dbProductImage == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Entry(dbProductImage).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(200)
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Delete(int Id)
        {
            try
            {
                var dbProductImage = await _db.ProductImages.SingleOrDefaultAsync(ProductImage => ProductImage.Id == Id);
                if (dbProductImage == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.ProductImages.Remove(dbProductImage);
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(200)
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
    }
}
