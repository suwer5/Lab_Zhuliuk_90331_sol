using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WLibrary.DAL.Entities
{
    public class Plants
    {
        public int PlantsId { get; set; } // id растения
        public string PlantsName { get; set; } // название растения
        public string Description { get; set; } // описание растения
        public string Image { get; set; } // имя файла изображения 

        // Навигационные свойства
        /// <summary>
        /// группа растений (например, цветы, декаративные растения и т.д.)
        /// </summary>
        public int PlantsGroupId { get; set; }
        public PlantsGroup Group { get; set; }
    }
}
