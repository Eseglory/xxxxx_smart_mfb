using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class CountryModel
    {
        public Country Country { get; set; }
        public StateData[] States { get; set; }
    }
}