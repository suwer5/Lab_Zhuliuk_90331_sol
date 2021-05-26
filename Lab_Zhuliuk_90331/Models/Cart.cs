using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;

namespace Lab_Zhuliuk_90331.Models
{
    public class Cart
    {

        public Dictionary <int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество айди в место количества калорий
        /// </summary>
        public int Calories
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Plants.PlantsId);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="plants">добавляемый объект</param>
        public void AddToCart(Plants plants)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(plants.PlantsId))
                Items[plants.PlantsId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(plants.PlantsId, new CartItem
                {
                    Plants = plants,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Plants Plants { get; set; }
        public int Quantity { get; set; }
    }




}

