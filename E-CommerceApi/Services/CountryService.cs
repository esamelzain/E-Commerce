using E_CommerceApi.Authentication;
using E_CommerceApi.Models.vModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class Countrieservice
    {
        private readonly ApplicationDbContext _db;
        public Countrieservice(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllCountries> GetAll()
        {
            try
            {
                var dbCountries = await _db.Countries.ToListAsync();
                if (dbCountries.Count > 0)
                {
                    return new AllCountries
                    {
                        Countries = dbCountries,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new AllCountries
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
                return new AllCountries
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<Models.vModels.CountryRes> Get(int Id)
        {
            try
            {
                var dbCountry = await _db.Countries.SingleOrDefaultAsync(country =>  country.Id == Id);
                if (dbCountry != null)
                {
                    return new Models.vModels.CountryRes
                    {
                        CountryResponse = dbCountry,
                        Message = new ResponseMessage
                        {
                            Message = "Success",
                            Code = 200
                        }
                    };
                }
                else
                {
                    return new Models.vModels.CountryRes
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
                return new Models.vModels.CountryRes
                {
                    Message = new ResponseMessage
                    {
                        Message = ex.Message,
                        Code = 500
                    }
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Country Country)
        {
            try
            {
                if (_db.Countries.Any(Country => Country.CountryName == Country.CountryName))
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
                    await _db.Countries.AddAsync(Country);
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
        public async Task<BaseResponse> Edit(Models.dbModels.Country Country)
        {
            try
            {
                var dbCountry = await _db.Countries.SingleOrDefaultAsync(Country => Country.Id == Country.Id);
                if (dbCountry == null)
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
                    _db.Entry(dbCountry).State = EntityState.Modified;
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
                var dbCountry = await _db.Countries.SingleOrDefaultAsync(Country => Country.Id == Id);
                if (dbCountry == null)
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
                    _db.Countries.Remove(dbCountry);
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
