using System.Data.Entity;
using System;
using WebApplication1.Models.DBModels;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL
{
    public class SurfDBInitializer : //DropCreateDatabaseAlways<SurfDbContext>
        DropCreateDatabaseIfModelChanges<SurfDbContext>
    {
        
        protected override void Seed(SurfDbContext context)
        {
            var user = new User
            {
                Nickname = "user",
                Password = "123456",
                LastName = "Бойков",
                Name = "Володя",
                Email = "clame@gmail.com",
                About = "Я такой хороший"
            };

            var post1 = new Post
            {
                Text = "Первый текст",
                PublishDate = DateTime.Now,
                Author = user
            };

            var post2 = new Post
            {
                Text = "Второй текст",
                PublishDate = DateTime.Now,
                Author = user
            };

            context.Users.Add(user);
            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.SaveChanges();
        }
    }
}