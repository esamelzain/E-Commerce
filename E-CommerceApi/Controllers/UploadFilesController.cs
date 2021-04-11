using E_CommerceApi.Models.vModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_CommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        public UploadFilesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<BaseResponse> UploadAsync()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return new BaseResponse { Message = new ResponseMessage { Message = "Success", Code = 200 } };
                }
                else
                {
                    return new BaseResponse { Message = new ResponseMessage { Message = "Bad Rquest", Code = 300 } };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse { Message = new ResponseMessage { Message = "Internal server error", Code = 500 } };
            }
        }
    }
}
