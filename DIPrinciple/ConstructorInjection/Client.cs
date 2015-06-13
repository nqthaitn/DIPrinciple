using System;

namespace DIPrinciple.ConstructorInjection
{
    public class Client
    {
        private IService _service;

        /// <summary>
        /// Constructor Injection
        /// 01. This is the most common DI
        /// 02. DI is done by supplying the DEPENDENCY through the class's constructor when instantiating that class.
        /// 03. Injected component can be used anywhere within the class.
        /// 04. Should be used when the injected dependency is required one or more dependencies.
        /// 05. It addresses the most common scenario where a class requires one or more dependencies.
        /// </summary>
        /// <param name="service"></param>
        public Client(IService service)
        {
            _service = service;
        }

        public void Start()
        {
            Console.WriteLine("Service started");
            _service.Serv();
        }
    }
}