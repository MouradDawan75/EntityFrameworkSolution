namespace _06_FluentApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_06_FluentApi.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_06_FluentApi.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            #region Tags

            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag{Id=1, Name="c#"} },
                {"angular", new Tag{Id=2, Name="angular"} },
                {"javascript", new Tag{Id=3, Name="javascript"} }
            };

            foreach (var item in tags.Values)
            {
                context.Tags.AddOrUpdate(t => t.Id, item);
            }


            #endregion

            #region Authors

            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Dawan"
                },

                new Author
                {
                    Id=2,
                    Name="Jehann"
                },

                new Author
                {
                    Id=3,
                    Name="Dan"
                }

            };

            foreach (var author in authors) 
            { 
            context.Authors.AddOrUpdate(a => a.Id, author);
            }

            #endregion

            #region Courses

            var courses = new List<Course>
            {
                new Course
                {
                    Id=1,
                    Name="c# basics",
                    AuthorId = 1,
                    FullPrice=20,
                    Tags = new List<Tag>
                    {
                        tags["c#"]
                    }
                    
                },

                new Course
                {
                    Id=2,
                    Name="javascript",
                    AuthorId=2,
                    FullPrice=20,
                    Tags = new List<Tag>
                    {
                        tags["javascript"]
                    }
                },

                new Course
                {
                    Id=3,
                    Name="Angular",
                    AuthorId=3,
                    FullPrice=30,
                    Tags = new List<Tag>
                    {
                        tags["angular"]
                    }
                }


            };

            foreach (var course in courses)
            {
                context.Courses.AddOrUpdate(c => c.Id, course);
            }

            #endregion
        }
    }
}
