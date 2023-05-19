using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryServices.HealthTest
{
    public interface IHealthTestInterface
    {
        dynamic GetBasicHeatlthTestString();
        HealthTestMessage GetDbTestString();
    }
}
