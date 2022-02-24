using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Models
{
    public class Basket 
    {
       public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

       public void AddItem (Book bk, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 20);

            return sum;
        }
    }


    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
