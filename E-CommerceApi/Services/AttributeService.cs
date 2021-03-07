using E_CommerceApi.Models.vModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Services
{
    public class AttributeService
    {
        public BaseResponse GetAll()
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
        public BaseResponse Get()
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
        public BaseResponse Add()
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
