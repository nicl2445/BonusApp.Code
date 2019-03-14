using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public delegate double BonusProvider(double amount);

    public class Bonuses
    {

        public static Func<double, double> TenPercent = (double amount) => amount / 10.0;
       
        public static Func<double, double> FlatTwoIfAmountMoreThanFive = (double amount) => amount > 5.0 ? 2.0 : 0.0;

    }
}
