using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class CategoryMainService
    {
        private readonly ApplicationDbContext _db;
        public CategoryMainService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllCategoryMains> GetAll()
        {
            try
            {
                var dbCategoryMains = await _db.CategoryMain.Where(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed).ToListAsync();
                if (dbCategoryMains.Count > 0)
                {
                    return new AllCategoryMains
                    {
                        CategoryMains = dbCategoryMains,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllCategoryMains
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
                return new AllCategoryMains
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<Models.vModels.CategoryMainRes> Get(int Id)
        {
            try
            {
                var dbCategoryMain = await _db.CategoryMain.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbCategoryMain != null)
                {
                    return new Models.vModels.CategoryMainRes
                    {
                        CategoryMainResponse = dbCategoryMain,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.CategoryMainRes
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
                return new Models.vModels.CategoryMainRes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.CategoryMain CategoryMain)
        {
            try
            {
                    await _db.CategoryMain.AddAsync(CategoryMain);
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
        public async Task<BaseResponse> Edit(Models.dbModels.CategoryMain CategoryMain)
        {
            try
            {
                var dbCategoryMain = await _db.CategoryMain.SingleOrDefaultAsync(CategoryMain => CategoryMain.Id == CategoryMain.Id);
                if (dbCategoryMain == null)
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
                    _db.Entry(dbCategoryMain).State = EntityState.Modified;
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
                var dbCategoryMain = await _db.CategoryMain.SingleOrDefaultAsync(CategoryMain => CategoryMain.Id == Id);
                if (dbCategoryMain == null)
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
                    _db.CategoryMain.Remove(dbCategoryMain);
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
