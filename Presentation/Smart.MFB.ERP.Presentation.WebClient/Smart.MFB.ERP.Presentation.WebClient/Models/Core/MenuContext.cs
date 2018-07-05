using Smart.MFB.ERP.Common.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Smart.MFB.ERP.Presentation.WebClient.Models.Core
{
    public class MenuContext : DbContext
    {
        public DbSet<Menu> menu { get; set; }
        public DbSet<ModuleCategory> moduleCategory { get; set; }
    }
}