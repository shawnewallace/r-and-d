using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using GridSpike.Lib.Model;

namespace GridSpike.Lib.Data
{
	public class GridSpikeContext : DbContext
	{
		public DbSet<QueuedTest> Queue { get; set; }
	}
}
