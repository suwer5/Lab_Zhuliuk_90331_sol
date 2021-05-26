//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Lab_Zhuliuk_90331.Controllers;
//using WLibrary.DAL.Entities;
//using Xunit;


//namespace Lab_Zhuliuk_90331.Test
//{
//    public class ProductControllerTests
//    {
//        [Theory]
//        [InlineData(1, 3, 1)] // 1-я страница, кол. объектов 3, id первого объекта 1
//        [InlineData(2, 2, 4)] // 2-я страница, кол. объектов 2, id первого объекта 4
//        public void ControllerGetsProperPage(int page, int qty, int id)
//        {
//            // Arrange 
//            var controller = new ProductController();
//            controller._plantses = new List<Plants>
//            {
//                new Plants{ PlantsId=1},
//                new Plants{ PlantsId=2},
//                new Plants{ PlantsId=3},
//                new Plants{ PlantsId=4},
//                new Plants{ PlantsId=5}
//            };
//            // Act
//            var result = controller.Index(pageNo: page, group: null) as ViewResult;

//            var model = result?.Model as List<Plants>;
//            // Assert
//            Assert.NotNull(model);
//            Assert.Equal(qty, model.Count);
//            Assert.Equal(id, model[0].PlantsId);
//        }

//    }
//}
