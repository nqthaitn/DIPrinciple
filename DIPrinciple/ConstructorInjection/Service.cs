using System;

namespace DIPrinciple.ConstructorInjection
{
    public class Service: IService
    {
        public void Serv()
        {
            Console.WriteLine("Service called");
        }
    }
}