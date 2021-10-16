using Product.Entities;
using System;
using System.Collections.Generic;

namespace Product.Repositories
{
    public interface IITemsRepository
    {
        Item GetItem(Guid Id);

        IEnumerable<Item> GetItems();

        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}