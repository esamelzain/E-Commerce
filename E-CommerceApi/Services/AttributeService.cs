using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class AttributeService
    {
        private readonly ApplicationDbContext _db;
        public AttributeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllAttributes> GetAll()
        {
            try
            {
                var dbAttributes = await _db.Attributes.Where(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed).ToListAsync();
                if (dbAttributes.Count > 0)
                {
                    return new AllAttributes
                    {
                        Attributes = dbAttributes,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllAttributes
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
                return new AllAttributes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public Models.vModels.Attribute Get(int Id)
        {
            try
            {
                var dbAttribute = _db.Attributes.SingleOrDefault(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbAttribute != null)
                {
                    return new Models.vModels.Attribute
                    {
                        AttributeResponse = dbAttribute,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.Attribute
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
                return new Models.vModels.Attribute
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Attribute Attribute)
        {
            try
            {
                await _db.Attributes.AddAsync(Attribute);
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
        public BaseResponse Edit()
        {
            try
            {
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
        public BaseResponse Delete()
        {
            try
            {
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
    }
}
