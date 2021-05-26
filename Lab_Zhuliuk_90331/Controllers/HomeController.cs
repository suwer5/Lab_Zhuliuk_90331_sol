using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Zhuliuk_90331.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering; 




namespace Lab_Zhuliuk_90331.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<ListDemo> _listDemo;
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["Lst"] = new  SelectList(_listDemo, "ListItemValue", "ListItemText");
            return View();
        }
        public HomeController()
        {
            _listDemo = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"}

            };
        }
    }
    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }
     


    }


}
