//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Lab_Zhuliuk_90331.Controllers;
//using Lab_Zhuliuk_90331;
//using WLibrary.DAL.Entities;
//using Xunit;

//namespace Lab_Zhuliuk_90331.Test
//{
//    public class ProductControllerTests2
//    {
//        [Theory]
//        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
//        public void ControllerGetsProperPage(int page, int qty, int id)
//        {
//            // Arrange 
//            var controller = new ProductController();
//            controller._plantses = TestData.GetDishesList();
            
//            // Act
//            var result = controller.Index(pageNo:page,group:null) as ViewResult;
//            var model = result?.Model as List<Plants>;
            
//            // Assert
//            Assert.NotNull(model);
//            Assert.Equal(qty, model.Count);
//            Assert.Equal(id, model[0].PlantsId);
//        }

//    }
//}
