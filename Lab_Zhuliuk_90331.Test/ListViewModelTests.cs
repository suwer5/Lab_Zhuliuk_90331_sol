using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLibrary.DAL.Entities;
using Lab_Zhuliuk_90331;
using Lab_Zhuliuk_90331.Models;
using Xunit;

namespace Lab_Zhuliuk_90331.Test
{
    public class ListViewModelTests
    {
        
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Plants>
           .GetModel(TestData.GetDishesList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Plants>
           .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Plants>
           .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].PlantsId);
        }
    }

}

