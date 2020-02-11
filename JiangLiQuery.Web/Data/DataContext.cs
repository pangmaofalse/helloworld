using JiangLiQuery.Web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JiangLiQuery.Web.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { 
        
        }
        public DbSet<Student> Students { get; set; }

    }
}
