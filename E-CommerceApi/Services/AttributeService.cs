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
    public interface IAttributeService
    {
           Task<AllAttributes> GetAll();
           Task<Models.vModels.AttributeRes> Get(int Id);
           Task<BaseResponse> Add(Models.dbModels.Attribute Attribute);
           Task<BaseResponse> Edit(Models.dbModels.Attribute Attribute);
          Task<BaseResponse> Delete(int Id);
    }
    public class AttributeService : IAttributeService
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
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllAttributes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllAttributes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.AttributeRes> Get(int Id)
        {
            try
            {
                var dbAttribute = await _db.Attributes.SingleOrDefaultAsync(attr => (bool)attr.IsActive && !(bool)attr.IsDeleted && !(bool)attr.IsTrashed && attr.Id == Id);
                if (dbAttribute != null)
                {
                    return new Models.vModels.AttributeRes
                    {
                        AttributeResponse = dbAttribute,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.AttributeRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.AttributeRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Attribute Attribute)
        {
            try
            {
                if (_db.Attributes.Any(attribute => attribute.AttributeName == Attribute.AttributeName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.Attributes.AddAsync(Attribute);
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
        public async Task<BaseResponse> Edit(Models.dbModels.Attribute Attribute)
        {
            try
            {
                var dbAttribute = await _db.Attributes.SingleOrDefaultAsync(attribute => attribute.Id == Attribute.Id);
                if (dbAttribute == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Entry(dbAttribute).State = EntityState.Modified;
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
                var dbAttribute = await _db.Attributes.SingleOrDefaultAsync(attribute => attribute.Id == Id);
                if (dbAttribute == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Attributes.Remove(dbAttribute);
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
