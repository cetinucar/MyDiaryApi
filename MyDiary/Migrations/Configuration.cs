namespace MyDiary.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyDiary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDiary.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDiary.Models.ApplicationDbContext context)
        {

            if (!context.Users.Any(x=>x.UserName=="admincetin@gmail.com"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admincetin@gmail.com",
                     Email= "admincetin@gmail.com"
                };

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.Create(user, "Ankara1.");

                Metin metin = new Metin
                {
                    Baslik = "Ýlk Metin",
                    Icerik = "Bir masal gibi geçti tüm yaþananlar.",
                    OluþturulmaTarihi = DateTime.Now,
                    YazarId = user.Id    
                };

                context.Metinler.Add(metin);
                context.SaveChanges();
            }
       
        }
    }
}
