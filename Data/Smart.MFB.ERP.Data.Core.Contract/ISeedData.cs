using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.MFB.ERP.Data.Core.Contract.Seed
{
    public interface ISeedData
    {
        void Execute(string mode);
        void UserGroupRole();
    }
}
