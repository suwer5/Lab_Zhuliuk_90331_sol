//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Lab_Zhuliuk_90331.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using WLibrary.DAL.Entities;
//using Lab_Zhuliuk_90331;
//using Xunit;

//namespace Lab_Zhuliuk_90331.Test
//{
//    public class ProductControllerTests3
//    {
//        [Fact]
//        public void ControllerSelectsGroup()
//        {
//            // arrange
//            var controller = new ProductController();
//            var data = TestData.GetDishesList();
//            controller._plantses = data;
//            var comparer = Comparer<Plants> .GetComparer((d1, d2) => d1.PlantsId.Equals(d2.PlantsId));
//            // act
//            var result = controller.Index(2) as ViewResult;
//            var model = result.Model as List<Plants>;
//            // assert
//            Assert.Equal(2, model.Count);
//            Assert.Equal(data[2], model[0], comparer);
//        }

//    }
//}
