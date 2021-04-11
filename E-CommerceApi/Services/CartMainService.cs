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
    public class CartMainService
    {
        private readonly ApplicationDbContext _db;
        public CartMainService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllCartMains> GetAll()
        {
            try
            {
                var dbCartMains = await _db.CartMain.ToListAsync();
                if (dbCartMains.Count > 0)
                {
                    return new AllCartMains
                    {
                        CartMains = dbCartMains,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllCartMains
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllCartMains
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<CartMainRes> Get(int Id)
        {
            try
            {
                var dbCartMain = await _db.CartMain.SingleOrDefaultAsync(cart => cart.Id == Id);
                if (dbCartMain != null)
                {
                    return new Models.vModels.CartMainRes
                    {
                        CartMainResponse = dbCartMain,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.CartMainRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.CartMainRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<CartMainRes> GetByIpAdress(string IpAddress)
        {
            try
            {
                var dbCartMain = await _db.CartMain.SingleOrDefaultAsync(cart => cart.IPAddress == IpAddress);
                if (dbCartMain != null)
                {
                    return new Models.vModels.CartMainRes
                    {
                        CartMainResponse = dbCartMain,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.CartMainRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.CartMainRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.CartMain CartMain)
        {
            try
            {
                if (_db.CartMain.Any(CartMain => CartMain.IPAddress == CartMain.IPAddress))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.CartMain.AddAsync(CartMain);
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
        public async Task<BaseResponse> Edit(Models.dbModels.CartMain CartMain)
        {
            try
            {
                var dbCartMain = await _db.CartMain.SingleOrDefaultAsync(CartMain => CartMain.Id == CartMain.Id);
                if (dbCartMain == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    _db.Entry(dbCartMain).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(401)
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
                var dbCartMain = await _db.CartMain.SingleOrDefaultAsync(CartMain => CartMain.Id == Id);
                if (dbCartMain == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.CartMain.Remove(dbCartMain);
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
