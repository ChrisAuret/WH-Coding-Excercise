using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain.Interfaces
{
    public interface IRiskInspector
    {
        List<Customer> CustomersWithUnusualWinRate(List<Customer> customers);
        List<Bet> CustomersWithHighBets(List<Customer> customers);
    }
}
