using Microsoft.VisualBasic.ApplicationServices;

namespace MyAssistant.Starter
{
    /// <summary>
    /// Wrap WPF application by WinForms application to use VisualBasic library
    /// </summary>
    public class SingleInstanceApplicationWrapper : WindowsFormsApplicationBase
    {
        #region Wpf Instance

        /// <summary>
        /// The WPF Application instance
        /// </summary>
        private App wpfApp;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SingleInstanceApplicationWrapper()
        {
#if (DEBUG)
            // Mark this application as non=single instance in debug
            IsSingleInstance = false;
#else
            // Mark this application as single instance in release
            IsSingleInstance = true;
#endif
        }

        #endregion

        #region Handle First Instance Application Starup Event

        /// <summary>
        /// Handle startup event
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override bool OnStartup(StartupEventArgs e)
        {
            // First time app is launched
            wpfApp = new App();
            wpfApp.InitializeComponent();
            wpfApp.Run();

            // Must return false to avoid exception
            return false;
        }

        #endregion

        #region Handle Next Instance of Application Startup Event

        /// <summary>
        /// If another instance is created, shutdown it and active the single instance
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // Subsequent launches
            base.OnStartupNextInstance(eventArgs);

            // Restore and activate the main window
            System.Windows.SystemCommands.RestoreWindow(wpfApp.MainWindow);
            wpfApp.MainWindow.Activate();
        }

        #endregion
    }
}