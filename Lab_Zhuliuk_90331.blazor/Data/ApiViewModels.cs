using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Lab_Zhuliuk_90331.blazor.Data
{
    public class ApiViewModels
    {
    }
    public class ListViewModel
    {
        [JsonPropertyName("plantsId")]
        public int PlantsId { get; set; } // id блюда
        [JsonPropertyName("plantsName")]
        public string PlantsName { get; set; } // название блюда
    }
    public class DetailsViewModel
    {
        [JsonPropertyName("plantsName")]
        public string PlantsName { get; set; } // название блюда
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание блюда
        [JsonPropertyName("calories")]
        public int Calories { get; set; } // кол. калорий на порцию
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения 
    }
}
