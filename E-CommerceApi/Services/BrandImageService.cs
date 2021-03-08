using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class BrandImageService
    {
        private readonly ApplicationDbContext _db;
        public BrandImageService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllBrandImages> GetAll()
        {
            try
            {
                var dbBrandImages = await _db.BrandImages.ToListAsync();
                if (dbBrandImages.Count > 0)
                {
                    return new AllBrandImages
                    {
                        BrandImages = dbBrandImages,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllBrandImages
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
                return new AllBrandImages
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<Models.vModels.BrandImageRes> Get(int Id)
        {
            try
            {
                var dbBrandImage = await _db.BrandImages.SingleOrDefaultAsync(brandImage => brandImage.Id == Id);
                if (dbBrandImage != null)
                {
                    return new Models.vModels.BrandImageRes
                    {
                        BrandImageResponse = dbBrandImage,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.BrandImageRes
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
                return new Models.vModels.BrandImageRes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.BrandImage BrandImage)
        {
            try
            {
                await _db.BrandImages.AddAsync(BrandImage);
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
        public async Task<BaseResponse> Edit(Models.dbModels.BrandImage BrandImage)
        {
            try
            {
                var dbBrandImage = await _db.BrandImages.SingleOrDefaultAsync(BrandImage => BrandImage.Id == BrandImage.Id);
                if (dbBrandImage == null)
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
                    _db.Entry(dbBrandImage).State = EntityState.Modified;
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
                var dbBrandImage = await _db.BrandImages.SingleOrDefaultAsync(BrandImage => BrandImage.Id == Id);
                if (dbBrandImage == null)
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
                    _db.BrandImages.Remove(dbBrandImage);
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
