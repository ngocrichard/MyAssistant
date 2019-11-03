using Caliburn.Micro;
using MyAssistant.ViewModels;
using System;
using System.Collections.Generic;

namespace MyAssistant.Services
{
    public class TabProvider : ITabsProvider
    {
        #region Constructor

        public TabProvider()
        {
            tabViewModelTypes = new List<Type>()
            {
                typeof(HomeViewModel),
                typeof(AppsViewModel),
                typeof(YoutubeViewModel)
            };
        }

        #endregion

        #region Services

        /// <summary>
        /// List of ViewModel types of all tabs in order, use this for reflection
        /// </summary>
        private readonly List<Type> tabViewModelTypes;

        /// <summary>
        /// Get all tab ViewModel, use implicit cast to prevent null
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Screen> GetTabViewModels()
        {
            foreach (var type in tabViewModelTypes)
            {
                yield return (Screen)IoCExtension.Get(type);
            }
        }

        #endregion
    }
}
