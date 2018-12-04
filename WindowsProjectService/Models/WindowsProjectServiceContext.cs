using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WindowsProjectService.Models
{
    public class WindowsProjectServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WindowsProjectServiceContext() : base("name=WindowsProjectServiceContext")
        {
        }

        public System.Data.Entity.DbSet<WindowsProjectService.Models.Onderneming> Ondernemings { get; set; }

        public System.Data.Entity.DbSet<WindowsProjectService.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<WindowsProjectService.Models.KortingsBon> KortingsBons { get; set; }

        public System.Data.Entity.DbSet<WindowsProjectService.Models.Promotie> Promoties { get; set; }

        public System.Data.Entity.DbSet<WindowsProjectService.Models.Gebruiker> Gebruikers { get; set; }
    }
}
