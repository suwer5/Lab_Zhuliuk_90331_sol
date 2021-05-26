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
//using Moq;
//using Microsoft.AspNetCore.Http;


//namespace Lab_Zhuliuk_90331.Test
//{
    
//    public class ProductControllerTests4
//    {
//        [Fact]
       
//        public void ControllerSelectsGroup()
//        {
//            // Контекст контроллера
//            var controllerContext = new ControllerContext();
//            // Макет HttpContext
//            var moqHttpContext = new Mock<HttpContext>();
//            moqHttpContext.Setup(c => c.Request.Headers)
//                .Returns(new HeaderDictionary());

//            controllerContext.HttpContext = moqHttpContext.Object;
//            var controller = new ProductController()
//            { ControllerContext = controllerContext };

//            // arrange
            
//            var data = TestData.GetDishesList();
//            controller._plantses = data;
//            var comparer = Comparer<Plants>.GetComparer((d1, d2) => d1.PlantsId.Equals(d2.PlantsId));
//            // act
//            var result = controller.Index(2) as ViewResult;
//            var model = result.Model as List<Plants>;
//            // assert
//            Assert.Equal(2, model.Count);
//            Assert.Equal(data[2], model[0], comparer);
//        }

//    }
//}
