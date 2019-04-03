using Autofac;
using Avocado.Entities;
using Avocado.Services;
using System;

namespace Avocado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            { 
                var container = BuildContainer();
                var staffProcessor = container.Resolve<IProcessor<Staff>>();
                staffProcessor.ProcessData(@"../../Data/Staff.csv");
                var superProcessor = container.Resolve<IProcessor<Super>>();
                superProcessor.ProcessData(@"../../Data/Super.csv");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(-1);
            }
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CsvParser>().As<IParser>();
            builder.RegisterType<StaffProcessor>().As<IProcessor<Staff>>();
            builder.RegisterType<SuperProcessor>().As<IProcessor<Super>>();
            return builder.Build();
        }
    }
}
