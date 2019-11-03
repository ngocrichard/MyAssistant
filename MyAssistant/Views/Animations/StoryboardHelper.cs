using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MyAssistant.Views
{
    /// <summary>
    /// Help perform storyboard
    /// </summary>
    public static class StoryboardHelper
    {
        public static async Task PerformAnimation(Storyboard storyboard, FrameworkElement element, double durationInSeconds)
        {
            // Begin storyboard
            storyboard.Begin(element);

            // Wait storyboard to complete
            await Task.Delay((int)(durationInSeconds * 1000));
        }
    }
}
