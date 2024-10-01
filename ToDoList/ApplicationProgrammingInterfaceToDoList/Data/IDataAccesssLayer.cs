using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListModel.Models;

namespace ToDoList
{
    public class IDataAccesssLayer : DbContext
    {
        public IDataAccesssLayer (DbContextOptions<IDataAccesssLayer> options)
            : base(options)
        {
        }

        public DbSet<ToDoListModel.Models.ToDoTask> ToDoTask { get; set; } = default!;
    }
}
