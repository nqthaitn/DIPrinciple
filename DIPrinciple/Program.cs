using System;
using DIPrinciple.Client;
using DIPrinciple.ConstructorInjection;

namespace DIPrinciple
{
    class Program
    {
        /// <summary>
        /// This code has been written to understand the concept of DI and does not claim the better way to implement DI
        /// The better way to implement DI is use DI CONTAINER (Autofac, Unity,...)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            var client = new ClientConstructorInjection(new Service.Service());
            client.Start();

            var clientPropertyInjection = new ClientPropertyInjection();
            clientPropertyInjection.Service = new Service.Service();
            clientPropertyInjection.Start();

            var clientMethodInjection = new ClientMethodInjection();
            clientMethodInjection.Start(new Service.Service());

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
