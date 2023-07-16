using AuthenticationApp.Models.Interfaces;
using System;

namespace AuthenticationApp.Services
{
    public class Logger : ILogger
    {

        public void WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);
        }

        public void WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
