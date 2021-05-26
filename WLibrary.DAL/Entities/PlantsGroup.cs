using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLibrary.DAL.Entities
{
    public class PlantsGroup
    {
        public int PlantsGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Plants> Plantses { get; set; }
    }
}
