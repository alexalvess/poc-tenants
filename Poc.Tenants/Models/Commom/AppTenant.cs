using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Tenants.Models.Commom
{
    public class AppTenant
    {
        public AppTenant(string registerNumber)
        {
            RegisterNumber = registerNumber;
        }

        public string RegisterNumber { get; }
    }
}
