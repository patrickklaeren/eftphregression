using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TPHRepro
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Migrating with EF6...");
            
            var migrationConfiguration = new Migrations.Configuration();
            var migrator = new System.Data.Entity.Migrations.DbMigrator(migrationConfiguration);
            migrator.Update();

            Console.WriteLine("Migrated!");

            Console.WriteLine("Adding 4 shapes to the database...");

            using (var db = new EntityContext())
            {
                db.Shapes.Add(new Circle
                {
                    Name = Guid.NewGuid().ToString("n"),
                });
                db.Shapes.Add(new Rectangle
                {
                    Name = Guid.NewGuid().ToString("n"),
                });
                db.Shapes.Add(new Square
                {
                    Name = Guid.NewGuid().ToString("n"),
                });
                db.Shapes.Add(new Pentagon
                {
                    Name = Guid.NewGuid().ToString("n"),
                });

                await db.SaveChangesAsync();
            }

            Console.WriteLine("Added shapes!");

            using (var db = new EntityContext())
            {
                var count = await db.Shapes.CountAsync();

                Console.WriteLine($"We have {count} shapes in the EF6 database!");
            }

            Console.WriteLine("Done EF6!");
            Console.ReadLine();
        }
    }

    public class EntityContext : DbContext
    {
        public EntityContext() : base("Server=localhost;Database=EF6TPHRepo;Trusted_Connection=True")
        {
            
        }

        public virtual DbSet<Shape> Shapes { get; set; }
        public virtual DbSet<Circle> Cirlces { get; set; }
        public virtual DbSet<Rectangle> Rectangles { get; set; }
        public virtual DbSet<Pentagon> Pentagons { get; set; }
    }

    public abstract class Shape
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Circle : Shape
    {
    }

    public class Rectangle : Shape
    {
    }

    public class Square : Shape
    {
    }

    public class Pentagon : Shape
    {
    }
}
