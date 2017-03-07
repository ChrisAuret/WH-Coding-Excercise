using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain.Interfaces;

namespace WH.Domain
{
    public class DataImporter : IDataImporter
    {
        public List<Customer> Import(string[] files)
        {
            var customers = new List<Customer>();

            foreach (var file in files)
            {
                using (var fs = File.OpenRead(file))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line == null) continue;
                        var values = line.Split(',');

                        var customer = new Customer { Id = int.Parse(values[0]) };

                        var bet = new Bet()
                        {
                            CustomerId = int.Parse(values[0]),
                            EventId = int.Parse(values[1]),
                            ParticipantId = int.Parse(values[2]),
                            Stake = int.Parse(values[3]),
                            BetAmount = int.Parse(values[4])
                        };

                        var unsettled = new List<Bet>();
                        var settled = new List<Bet>();
                    }
                }
            }

            return customers;
        }
    }
}
