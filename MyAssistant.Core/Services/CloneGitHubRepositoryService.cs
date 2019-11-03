using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssistant.Core.Scripts
{
    public class CloneGitHubRepositoryService
    {
        public void Clone(string filePath, string url)
        {
            Process process = new Process();
            process.StartInfo.FileName = filePath;
            process.StartInfo.Arguments = url;
            process.Start();
        }
    }
}
