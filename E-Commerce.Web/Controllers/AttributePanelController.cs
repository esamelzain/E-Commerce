using E_Commerce.Web.Helpers;
using E_CommerceApi.Models.vModels;
using E_CommerceApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Web.Controllers
{
    public class AttributePanelController : Controller
    {
        private readonly IAttributeTypeService attributeTypeService;
        public AttributePanelController(IAttributeTypeService attributeTypeService)
        {
            this.attributeTypeService = attributeTypeService;
        }
        public IActionResult AttributeTypes()
        {
            var model = attributeTypeService.GetAll();
            if (model.Result.Message.Code == 200)
            {
                return View(model.Result.AttributeTypes);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
