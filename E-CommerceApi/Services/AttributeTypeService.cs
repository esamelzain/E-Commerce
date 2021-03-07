﻿using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class AttributeTypeService
    {
        private readonly ApplicationDbContext _db;
        public AttributeTypeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllAttributeTypes> GetAll()
        {
            try
            {
                var dbAttributeType = await _db.AttributeTypes.Where(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed).ToListAsync();
                if (dbAttributeType.Count > 0)
                {
                    return new AllAttributeTypes
                    {
                        AttributeTypes = dbAttributeType,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllAttributeTypes
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
                return new AllAttributeTypes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<AttributeType> Get(int Id)
        {
            try
            {
                var dbAttributeType = await _db.Attributes.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbAttributeType != null)
                {
                    return new AttributeType
                    {
                        AttributeTypeResponse = dbAttributeType,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AttributeType
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
                return new AttributeType
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.AttributeType attributeType)
        {
            try
            {
                await _db.AttributeTypes.AddAsync(attributeType);
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
