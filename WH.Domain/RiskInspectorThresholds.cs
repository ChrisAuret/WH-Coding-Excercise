using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain
{
    public class RiskInspectorThresholds
    {
        public static int CustomerWinRate => 60;
        public static int HighStakes => 10;
        public static int UnusuallyHighStakes => 30;
        public static int HighToWinAmount => 1000;
    }
}
