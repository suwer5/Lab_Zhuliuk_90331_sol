using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLibrary.DAL.Entities;
using WLibrary.DAL.Data;
using Lab_Zhuliuk_90331.Models;
using Moq;
using Microsoft.AspNetCore.Http;
using Lab_Zhuliuk_90331.Extensions;
using Microsoft.Extensions.Logging;

namespace Lab_Zhuliuk_90331.Controllers
{
    public class ProductController : Controller
    {


        ApplicationDbContext _context;

        int _pageSize;

        private ILogger _logger;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]

        public IActionResult Index(int? group, int pageNo)
        {
            var groupName = group.HasValue ? _context.PlantsGroups.Find(group.Value)?.GroupName : "all groups";
            //_logger.LogInformation($"info: group={group}, page={pageNo}");

            var plantsesFiltered = _context.Plantses
                .Where(d=> !group.HasValue||d.PlantsGroupId==group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.PlantsGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            //return View(ListViewModel<Plants>.GetModel(plantsesFiltered, pageNo,_pageSize));
            var model = ListViewModel<Plants>.GetModel(plantsesFiltered, pageNo,_pageSize);

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            
            else
                return View(model);
        }
       
    }
}
