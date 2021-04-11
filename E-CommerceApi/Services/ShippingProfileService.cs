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
    public class ShippingProfileService
    {
        private readonly ApplicationDbContext _db;
        public ShippingProfileService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllShippingProfiles> GetAll()
        {
            try
            {
                var dbShippingProfiles = await _db.ShippingProfiles.ToListAsync();
                if (dbShippingProfiles.Count > 0)
                {
                    return new AllShippingProfiles
                    {
                        ShippingProfiles = dbShippingProfiles,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllShippingProfiles
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllShippingProfiles
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.ShippingProfileRes> Get(int Id)
        {
            try
            {
                var dbShippingProfile = await _db.ShippingProfiles.SingleOrDefaultAsync(shippingProfile =>  shippingProfile.Id == Id);
                if (dbShippingProfile != null)
                {
                    return new Models.vModels.ShippingProfileRes
                    {
                        ShippingProfileResponse = dbShippingProfile,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.ShippingProfileRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.ShippingProfileRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.ShippingProfile ShippingProfile)
        {
            try
            {
                if (_db.ShippingProfiles.Any(shippingProfile => shippingProfile.ProfileName == ShippingProfile.ProfileName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.ShippingProfiles.AddAsync(ShippingProfile);
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
        public async Task<BaseResponse> Edit(Models.dbModels.ShippingProfile ShippingProfile)
        {
            try
            {
                var dbShippingProfile = await _db.ShippingProfiles.SingleOrDefaultAsync(ShippingProfile => ShippingProfile.Id == ShippingProfile.Id);
                if (dbShippingProfile == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Entry(dbShippingProfile).State = EntityState.Modified;
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
                var dbShippingProfile = await _db.ShippingProfiles.SingleOrDefaultAsync(ShippingProfile => ShippingProfile.Id == Id);
                if (dbShippingProfile == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.ShippingProfiles.Remove(dbShippingProfile);
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
