using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Zhuliuk_90331.Extensions;
using Lab_Zhuliuk_90331.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_Zhuliuk_90331.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
