using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssistant.Models
{
    public class ScriptModel : ObservableModelBase
    {
        public string Path { get; set; }
        public string Arguments { get; set; }
    }
}
