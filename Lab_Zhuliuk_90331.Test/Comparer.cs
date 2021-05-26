using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Zhuliuk_90331.Controllers;
using Microsoft.AspNetCore.Mvc;
using WLibrary.DAL.Entities;
using Xunit;


namespace Lab_Zhuliuk_90331.Test
{
    class Comparer <T> : IEqualityComparer<T>
    {
        public static Comparer<T> GetComparer(Func<T, T, bool> func)
        {
            return new Comparer<T>(func);
        }
        Func<T, T, bool> comparerFunction;
        public Comparer(Func<T, T, bool> func)
        {
            comparerFunction = func;
        }
        public bool Equals(T x, T y)
        {
            return comparerFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }



    }
}
