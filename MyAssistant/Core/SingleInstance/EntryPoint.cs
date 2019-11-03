using System;

namespace MyAssistant.Starter
{
    public class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Command line arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            // Create instance of the application and run with command line arguments
            var app = new SingleInstanceApplicationWrapper();
            app.Run(args);
        }
    }
}