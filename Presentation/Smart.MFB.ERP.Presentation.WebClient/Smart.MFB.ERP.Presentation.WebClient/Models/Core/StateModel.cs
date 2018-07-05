using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class StateModel
    {
        public State State { get; set; }
        public CityData[] Cities { get; set; }
    }
}