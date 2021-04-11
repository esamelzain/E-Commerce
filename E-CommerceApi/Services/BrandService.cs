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
    public class BrandService
    {
        private readonly ApplicationDbContext _db;
        public BrandService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllBrands> GetAll()
        {
            try
            {
                var dbBrands = await _db.Brands.Where(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed).ToListAsync();
                if (dbBrands.Count > 0)
                {
                    return new AllBrands
                    {
                        Brands = dbBrands,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllBrands
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllBrands
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.BrandRes> Get(int Id)
        {
            try
            {
                var dbBrand = await _db.Brands.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbBrand != null)
                {
                    return new Models.vModels.BrandRes
                    {
                        BrandResponse = dbBrand,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.BrandRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.BrandRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Brand Brand)
        {
            try
            {
                if (_db.Brands.Any(brand => brand.BrandName == Brand.BrandName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.Brands.AddAsync(Brand);
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
        public async Task<BaseResponse> Edit(Models.dbModels.Brand Brand)
        {
            try
            {
                var dbBrand = await _db.Brands.SingleOrDefaultAsync(brand => brand.Id == Brand.Id);
                if (dbBrand == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    _db.Entry(dbBrand).State = EntityState.Modified;
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
                var dbBrand = await _db.Brands.SingleOrDefaultAsync(Brand => Brand.Id == Id);
                if (dbBrand == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Brands.Remove(dbBrand);
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
