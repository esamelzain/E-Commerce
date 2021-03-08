using E_CommerceApi.Authentication;
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
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllBrands
                    {
                        Message = new ResponseMessage
                        {
                            Message = "Empty",
                            Code = 410
                        }
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllBrands
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
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
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.BrandRes
                    {
                        Message = new ResponseMessage
                        {
                            Message = "NotFound",
                            Code = 404
                        }
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.BrandRes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Brand Brand)
        {
            try
            {
                if (_db.Brands.Any(Brand => Brand.BrandName == Brand.BrandName))
                {
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "Exist",
                            Code = 510
                        }
                    };
                }
                else
                {
                    await _db.Brands.AddAsync(Brand);
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
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
        public async Task<BaseResponse> Edit(Models.dbModels.Brand Brand)
        {
            try
            {
                var dbBrand = await _db.Brands.SingleOrDefaultAsync(Brand => Brand.Id == Brand.Id);
                if (dbBrand == null)
                {
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "NotFound",
                            Code = 404
                        }
                    };
                }
                else
                {
                    _db.Entry(dbBrand).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
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
                var dbBrand = await _db.Brands.SingleOrDefaultAsync(Brand => Brand.Id == Id);
                if (dbBrand == null)
                {
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "NotFound",
                            Code = 404
                        }
                    };
                }
                else
                {
                    _db.Brands.Remove(dbBrand);
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
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
    }
}
