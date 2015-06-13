using System;
using DIPrinciple.Service;

namespace DIPrinciple.Client
{
    /// <summary>
    /// 01. Inject the dependency into a single method, for use by that method.
    /// 02. Could be useful where the whole class does not need the dependency, just the one method.
    /// 03. Generally uncommon, usually used for edge cases.
    /// </summary>
    public class ClientMethodInjection
    {
        private IService _service;

        public void Start(IService service)
        {
            _service = service;
            Console.WriteLine("Service starting from client used Method Injection");
            _service.Serv();
            Console.WriteLine("=======================================================");
        }
    }
}