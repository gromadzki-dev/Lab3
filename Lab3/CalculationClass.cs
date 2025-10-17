using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class CalculationClass
    {
        public double Volume { get; set; }
        public double Percentage { get; set; }
        public int Amount { get; set; }
        public double TotalVolume() => Volume * Amount;
        public double PureSubstancePercentage() => TotalVolume() * (Percentage / 100);
    }
}