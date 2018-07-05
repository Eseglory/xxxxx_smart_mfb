using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class ModuleModel
    {
        public Module Module { get; set; }
        public MenuData[] Menus { get; set; }
    }
}