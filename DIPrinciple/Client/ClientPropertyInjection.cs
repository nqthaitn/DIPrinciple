using System;
using DIPrinciple.Service;

namespace DIPrinciple.ConstructorInjection
{
    /// <summary>
    /// Property Injection (Setter Injection)
    /// 01. Used when a class has optional dependencies, or where the implementions may need to be swapped.
    ///     Different logger implementations could be used this way.
    /// 02. Need to check for null before using it 
    /// </summary>
    public class ClientPropertyInjection
    {
        public IService Service { get; set; }

        public void Start()
        {
            Console.WriteLine("Service starting from client used Property Injection");
            Service.Serv();
        }
    }

}