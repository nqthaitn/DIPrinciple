using System;
using Autofac;
using DIPrinciple.Client;
using DIPrinciple.ConstructorInjection;
using DIPrinciple.Service;

namespace DIPrinciple
{
    class Program
    {
        //store it for later use.
        private static IContainer Container { get; set; }

        /// <summary>
        /// This code has been written to understand the concept of DI and does not claim the better way to implement DI
        /// The better way to implement DI is use DI CONTAINER (Autofac, Unity,...)
        /// Key points about DI
        ///     01. Reduces class coupling
        ///     02. Increases code reusing
        ///     03. Improves code maintainability
        ///     04. Improves application testing
        /// </summary>
        static void Main(string[] args)
        {

            var client = new ClientConstructorInjection(new Service.Service());
            client.Start();

            var clientPropertyInjection = new ClientPropertyInjection();
            clientPropertyInjection.Service = new Service.Service();
            clientPropertyInjection.Start();

            var clientMethodInjection = new ClientMethodInjection();
            clientMethodInjection.Start(new Service.Service());

            //=========================================================================
            // Use Autofac
            //=========================================================================
            
            Console.WriteLine("\nUse Autofac");
            
            var builder = new ContainerBuilder();
            
            
            //3 ways to Register individual components
            //builder.RegisterType<Service.Service>().As<IService>();
            //builder.RegisterInstance(new Service.Service()).As<IService>();
            //builder.Register(s => new Service.Service()).As<IService>();

            //another way - Scan an assembly for components
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            
            //store it for later use.
            Container = builder.Build();

            //avoid memory lead
            using (var scope = Container.BeginLifetimeScope())
            {
                var clientConstructor = new ClientConstructorInjection(scope.Resolve<IService>());
                clientConstructor.Start();
            }
            

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
