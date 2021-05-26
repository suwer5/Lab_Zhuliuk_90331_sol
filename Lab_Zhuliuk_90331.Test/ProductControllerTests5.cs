using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Zhuliuk_90331.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WLibrary.DAL.Entities;
using WLibrary.DAL.Data;
using Lab_Zhuliuk_90331;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;

namespace Lab_Zhuliuk_90331.Test
{

    public class ProductControllerTests5
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests5()
        {
            _options =
           new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange 
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo:
               page) as ViewResult;
                var model = result?.Model as List<Plants>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].PlantsId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [Fact]

        public void ControllerSelectsGroup()
        {
            // arrange

            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
                .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;

            // заполнить DB  данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };


                var comparer = Comparer<Plants>.GetComparer((d1, d2) => d1.PlantsId.Equals(d2.PlantsId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Plants>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Plantses
                    .ToArrayAsync()
                    .GetAwaiter()
                    .GetResult()[2], model[0], comparer);
            }
        }

    }
}