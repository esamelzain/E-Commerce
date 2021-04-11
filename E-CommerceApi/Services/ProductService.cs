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
    public class ProductsService
    {
        private readonly ApplicationDbContext _db;
        public ProductsService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllProducts> GetAll()
        {
            try
            {
                var dbProducts = await _db.ProductMain.Where(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed).ToListAsync();
                if (dbProducts.Count > 0)
                {
                    return new AllProducts
                    {
                        Products = dbProducts,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllProducts
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllProducts
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.ProductRes> Get(int Id)
        {
            try
            {
                var dbProduct = await _db.ProductMain.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.ID == Id);
                if (dbProduct != null)
                {
                    return new Models.vModels.ProductRes
                    {
                        ProductResponse = dbProduct,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.ProductRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.ProductRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.ProductMain Product)
        {
            try
            {
                if (_db.ProductMain.Any(Product => Product.ProductName == Product.ProductName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.ProductMain.AddAsync(Product);
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
        public async Task<BaseResponse> Edit(Models.dbModels.ProductMain Product)
        {
            try
            {
                var dbProduct = await _db.ProductMain.SingleOrDefaultAsync(Product => Product.ID == Product.ID);
                if (dbProduct == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    _db.Entry(dbProduct).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(401)
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
        public async Task<BaseResponse> Delete(int Id)
        {
            try
            {
                var dbProduct = await _db.ProductMain.SingleOrDefaultAsync(Product => Product.ID == Id);
                if (dbProduct == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.ProductMain.Remove(dbProduct);
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
