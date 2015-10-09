using MambaTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MambaTestApi.Repo.Interfaces
{
    public interface ITodoItemsRepository
    {
        IEnumerable<ToDoItem> AllItems { get; }
        void Add(ToDoItem item);
        ToDoItem GetById(int id);
        bool TryDelete(int id);
    }
}
