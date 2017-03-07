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
                var isSettledFile = file.ToLower().StartsWith("s");
                
                using (var fs = File.OpenRead(file))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line == null) continue;
                        var values = line.Split(',');

                        var customerId = int.Parse(values[0]);

                        var bet = new Bet()
                        {
                            CustomerId = customerId,
                            EventId = int.Parse(values[1]),
                            ParticipantId = int.Parse(values[2]),
                            Stake = int.Parse(values[3]),
                            BetAmount = int.Parse(values[4])
                        };

                        var customer = new Customer
                        {
                            Id = customerId
                        };

                        if (isSettledFile)
                        {
                            customer.Settled.Add(bet);
                        }
                        else
                        {
                            customer.Unsettled.Add(bet);
                        }

                        if (!customers.Contains(customer))
                        {
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
    }
}
