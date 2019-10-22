using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CookieAPI.Models;


namespace CookieAPI.DAL
{
    public static class DAL
    {
        public static void AddCookiePreferences(CookiePreferencesModel model)
        {
            using(var db = new CookieContext())
            {
                db.CookiePreferences.Add(model);
                db.SaveChanges();
            }
        }
    }

    public class CookieContext : DbContext
    {
        public DbSet<CookiePreferencesModel> CookiePreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=CookiePreferencesDatabase;Trusted_Connection=True;");
        }
    }
}
