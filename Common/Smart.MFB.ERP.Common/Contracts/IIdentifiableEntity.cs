using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart.MFB.ERP.Common.Contracts
{
    public interface IIdentifiableEntity
    {
        long EntityId { get; set; }
    }
}
