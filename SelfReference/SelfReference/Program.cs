using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SelfReference
{
	public class Profile
	{
		[Key]
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}
		private Guid _id = Guid.NewGuid();

		[StringLength(155)]
		public string Name { get; set; }

		public Guid? CoachId { get; set; }
		public Profile Coach { get; set; }

		public ICollection<Profile> Coachees { get; set; }
	}

	public class ProfileContext : DbContext
	{
		public DbSet<Profile> Profiles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Profile>()
				.HasOptional(e => e.Coach)
				.WithMany(f => f.Coachees)
				.HasForeignKey(m => m.CoachId);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new ProfileContext())
			{
				var coach    = new Profile { Name = "Coach" };
				var coachee1 = new Profile { Name = "Coachee1" };
				var coachee2 = new Profile { Name = "Coachee2" };
				var coachee3 = new Profile { Name = "Coachee2" };
				var noCoach  = new Profile { Name = "NoCoach" };

				context.Profiles.Add(coach);
				context.Profiles.Add(coachee1);
				context.Profiles.Add(coachee2);
				context.Profiles.Add(coachee3);
				context.Profiles.Add(noCoach);

				coachee1.Coach = coach;
				coachee2.Coach = coach;
				coachee3.Coach = coach;

				context.SaveChanges();

				foreach (var s in context.Profiles
														.Include(m => m.Coach)
														.Include(m => m.Coachees)
														.ToList())
				{
					Console.WriteLine("{0} {1} {2} {3}"
						, s.Id
						, s.Name
						, (s.Coachees == null ? 0 : s.Coachees.Count())
						, (s.Coach == null ? "???" : s.Coach.Name));

					//context.Profiles.Remove(s);
				}

				context.SaveChanges();
			}
			Console.ReadLine();
		}
	}
}
