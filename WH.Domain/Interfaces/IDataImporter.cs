using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain.Interfaces
{
    public interface IDataImporter
    {
        List<Customer> Import(string[] files);
    }
}