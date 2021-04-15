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
    public interface IAttributeTypeService
    {
        public Task<AllAttributeTypes> GetAll();
        public Task<AttributeTypeResponse> Get(int Id);
        public Task<BaseResponse> Add(Models.dbModels.AttributeType AttributeType);
        public Task<BaseResponse> Edit(Models.dbModels.AttributeType attributeType);
        public Task<BaseResponse> Delete(int Id);
    }
    public class AttributeTypeService : IAttributeTypeService
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
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllAttributeTypes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllAttributeTypes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<AttributeTypeResponse> Get(int Id)
        {
            try
            {
                var dbAttributeType = await _db.AttributeTypes.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbAttributeType != null)
                {
                    return new AttributeTypeResponse
                    {
                        AttributeType = dbAttributeType,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AttributeTypeResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AttributeTypeResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.AttributeType AttributeType)
        {
            try
            {
                if (_db.AttributeTypes.Any(attributetype=>attributetype.AttributeTypeName == AttributeType.AttributeTypeName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.AttributeTypes.AddAsync(AttributeType);
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
        public async Task<BaseResponse> Edit(Models.dbModels.AttributeType attributeType)
        {
            try
            {
                var dbAttributeType = await _db.AttributeTypes.SingleOrDefaultAsync(attributetype => attributetype.Id == attributeType.Id);
                if (dbAttributeType==null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Entry(attributeType).State = EntityState.Modified;
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
        public async Task<BaseResponse> Delete(int Id)
        {
            try
            {
                var dbAttributeType = await _db.AttributeTypes.SingleOrDefaultAsync(attributetype => attributetype.Id == Id);
                if (dbAttributeType == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.AttributeTypes.Remove(dbAttributeType);
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
