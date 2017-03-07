using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WH.Domain;
using WH.Domain.Interfaces;

namespace WH
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<DataImporter>().As<IDataImporter>();
            return builder.Build();
        }
    }
}
