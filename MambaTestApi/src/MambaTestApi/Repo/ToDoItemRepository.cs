using MambaTestApi.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MambaTestApi.Models;

namespace MambaTestApi.Repo
{
    public class ToDoItemRepository : ITodoItemsRepository
    {
        readonly List<ToDoItem> _items = new List<ToDoItem>();

        public IEnumerable<ToDoItem> AllItems
        {
            get
            {
                return _items;
            }
        }

        public ToDoItem GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ToDoItem item)
        {
            item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(item);
        }

        public bool TryDelete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }
    }
}
