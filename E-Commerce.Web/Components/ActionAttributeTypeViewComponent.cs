using E_CommerceApi.Models.dbModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Web.Components
{
    public class ActionAttributeTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            if (id == null)
            {
                return View(new AttributeType());
            }
            else
            {
                return View("Edit");
            }
        }
    }
}
