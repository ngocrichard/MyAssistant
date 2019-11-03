using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssistant.Core.Services
{
    public class ProcessService
    {
        public Process Run(string filePath, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = filePath;
            process.StartInfo.Arguments = arguments;
            process.Start();
            return process;
        }
    }
}
