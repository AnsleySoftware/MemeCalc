using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeCalcBackEnd
{
    public class UnitClass
    {
        public string Name { get; }
        public decimal Ratio { get; }
        public string? IconPath { get; }

        public UnitClass(string name, decimal ratio, string? iconPath = null)
        {
            Name = name;
            Ratio = ratio;
            IconPath = iconPath;
        }
    }
}
