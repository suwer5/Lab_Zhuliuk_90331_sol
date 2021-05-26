using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLibrary.DAL.Entities;
using WLibrary.DAL.Data;

namespace Lab_Zhuliuk_90331
{
    public class TestData
    {
        public static void FillContext(ApplicationDbContext context)
        {
            context.PlantsGroups.Add(new PlantsGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Plants>
            {
                new Plants{ PlantsId=1, PlantsGroupId=1},
                new Plants{ PlantsId=2, PlantsGroupId=1},
                new Plants{ PlantsId=3, PlantsGroupId=2},
                new Plants{ PlantsId=4, PlantsGroupId=2},
                new Plants{ PlantsId=5, PlantsGroupId=3}
            });
            context.SaveChanges();
        }
        public static List<Plants> GetDishesList()
        {
            return new List<Plants>
                {
                    new Plants{ PlantsId=1, PlantsGroupId=1},
                    new Plants{ PlantsId=2, PlantsGroupId=1},
                    new Plants{ PlantsId=3, PlantsGroupId=2},
                    new Plants{ PlantsId=4, PlantsGroupId=2},
                    new Plants{ PlantsId=5, PlantsGroupId=3}
                };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }



    }
}
