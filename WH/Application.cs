using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain;
using WH.Domain.Interfaces;

namespace WH
{
    public class Application : IApplication
    {
        private readonly IDataImporter _dataImporter;
        private readonly IRiskInspector _riskInspector;

        public Application(IDataImporter dataImporter, IRiskInspector riskInspector)
        {
            _dataImporter = dataImporter;
            _riskInspector = riskInspector;
        }

        public void Run()
        {
            var customers = _dataImporter.Import(new[] { "Settled.csv", "Unsettled.csv" });

            var customersWithHighWinRate = _riskInspector.CustomersWithUnusualWinRate(customers, RiskInspectorThresholds.CustomerWinRate);
            var customersWithHighBets = _riskInspector.CustomersWithHighBets(customers, RiskInspectorThresholds.HighToWinAmount);
            var betsWithunusualStakes = _riskInspector.BetsWithUnusualStakes(customers, RiskInspectorThresholds.HighStakes);
            var betsWithVeryUnusualStakes = _riskInspector.BetsWithVeryUnusualStakes(customers, RiskInspectorThresholds.UnusuallyHighStakes);
        }
    }
}