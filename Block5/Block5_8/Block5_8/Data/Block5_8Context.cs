using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Block5_8.Models;

namespace Block5_8.Data
{
    public class Block5_8Context : DbContext
    {
        public Block5_8Context (DbContextOptions<Block5_8Context> options)
            : base(options)
        {
        }

        public DbSet<Block5_8.Models.OfficeWork> OfficeWork { get; set; }
    }
}
