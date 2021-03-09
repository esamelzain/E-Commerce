using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class CategoryDetailsService
    {
        private readonly ApplicationDbContext _db;
        public CategoryDetailsService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllCategoryDetails> GetAll()
        {
            try
            {
                var dbCategoryDetails = await _db.CategoryDetails.ToListAsync();
                if (dbCategoryDetails.Count > 0)
                {
                    return new AllCategoryDetails
                    {
                        CategoryDetails = dbCategoryDetails,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllCategoryDetails
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
                return new AllCategoryDetails
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<Models.vModels.CategoryDetailRes> Get(int Id)
        {
            try
            {
                var dbCategoryDetails = await _db.CategoryDetails.SingleOrDefaultAsync(attr => attr.Id == Id);
                if (dbCategoryDetails != null)
                {
                    return new Models.vModels.CategoryDetailRes
                    {
                        CategoryDetailResponse = dbCategoryDetails,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.CategoryDetailRes
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
                return new Models.vModels.CategoryDetailRes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.CategoryDetails CategoryDetails)
        {
            try
            {
                    await _db.CategoryDetails.AddAsync(CategoryDetails);
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
        public async Task<BaseResponse> Edit(Models.dbModels.CategoryDetails CategoryDetails)
        {
            try
            {
                var dbCategoryDetails = await _db.CategoryDetails.SingleOrDefaultAsync(CategoryDetails => CategoryDetails.Id == CategoryDetails.Id);
                if (dbCategoryDetails == null)
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
                    _db.Entry(dbCategoryDetails).State = EntityState.Modified;
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
                var dbCategoryDetails = await _db.CategoryDetails.SingleOrDefaultAsync(CategoryDetails => CategoryDetails.Id == Id);
                if (dbCategoryDetails == null)
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
                    _db.CategoryDetails.Remove(dbCategoryDetails);
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
