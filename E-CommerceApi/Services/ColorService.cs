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
    public class ColorService
    {
        private readonly ApplicationDbContext _db;
        public ColorService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AllColors> GetAll()
        {
            try
            {
                var dbColors = await _db.Colors.ToListAsync();
                if (dbColors.Count > 0)
                {
                    return new AllColors
                    {
                        Colors = dbColors,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new AllColors
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new AllColors
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<Models.vModels.ColorRes> Get(int Id)
        {
            try
            {
                var dbColor = await _db.Colors.SingleOrDefaultAsync(Color =>  Color.Id == Id);
                if (dbColor != null)
                {
                    return new Models.vModels.ColorRes
                    {
                        ColorResponse = dbColor,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new Models.vModels.ColorRes
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new Models.vModels.ColorRes
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        public async Task<BaseResponse> Add(Models.dbModels.Color Color)
        {
            try
            {
                if (_db.Colors.Any(color => color.ColorName == Color.ColorName))
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(441)
                    };
                }
                else
                {
                    await _db.Colors.AddAsync(Color);
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
        public async Task<BaseResponse> Edit(Models.dbModels.Color Color)
        {
            try
            {
                var dbColor = await _db.Colors.SingleOrDefaultAsync(Color => Color.Id == Color.Id);
                if (dbColor == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Entry(dbColor).State = EntityState.Modified;
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
                var dbColor = await _db.Colors.SingleOrDefaultAsync(Color => Color.Id == Id);
                if (dbColor == null)
                {
                    return new BaseResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
                else
                {
                    _db.Colors.Remove(dbColor);
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
