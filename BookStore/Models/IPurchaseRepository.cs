using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models
{
    public interface IPurchaseRepository
    {
    IQueryable<Purchase> Purchases { get; }

        void SavePurchase(Purchase purchase);

    }
}
