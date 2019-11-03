using MyAssistant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAssistant.DAL
{
    public interface IAppRepository
    {
        List<AppModel> SelectAllApps();
        Task<bool> DeleteAppById(long id);
        long? InsertNewApp(string name, string path);
        Task<bool> UpdateAppById(long id, string name, string path);
    }
}
