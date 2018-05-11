using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.MFB.ERP.Common.ServiceModel
{
    public static class CodeGenerator
    {

        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
     
         public static string RandomString(int length)
         {
                    
             return new string(Enumerable.Repeat(chars, length)
             .Select(s => s[random.Next(s.Length)]).ToArray());
         }

     }

}

