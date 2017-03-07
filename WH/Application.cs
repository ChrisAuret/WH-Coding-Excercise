using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain.Interfaces;

namespace WH
{
    public class Application : IApplication
    {
        private readonly IDataImporter _dataImporter;

        public Application(IDataImporter dataImporter)
        {
            _dataImporter = dataImporter;
        }

        public void Run()
        {
            var customers = _dataImporter.Import(new[] {"Settled.csv", "Unsettled.csv"});
        }
    }
}
