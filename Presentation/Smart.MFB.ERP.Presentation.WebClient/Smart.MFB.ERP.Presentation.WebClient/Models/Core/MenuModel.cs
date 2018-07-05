using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class MenuModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Alias { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public int Position { get; set; }
        public long? Parent { get; set; }
        public int MenuLevel { get; set; }
        public List<MenuModel> Children { get; set; }
    }
}