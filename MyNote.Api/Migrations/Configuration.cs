namespace MyNote.Api.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyNote.Api.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyNote.Api.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyNote.Api.Models.ApplicationDbContext context)
        {

            //https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            //Admin Rolu olmadýgý ýcýn burayý yoruma alýyoruz.
            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}
            var userName = "MyBlog@burakturkozen.com";

            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = userName, Email = userName, EmailConfirmed = true };

                manager.Create(user, "123Pass_1");
                //manager.AddToRole(user.Id, "AppAdmin");

                for (int i = 1; i <= 5; i++)
                {
                    context.Notes.Add(new Note
                    {
                        AuthorId = user.Id,
                        Title = "Sample Note" + i,
                        Content = "Sapien elit in malesuada semper mi, id solicitudin urna fermantum",
                        CreationTime = DateTime.Now,
                        ModificationTime = DateTime.Now
                    }); 
                }
            }
        }
    }
}
