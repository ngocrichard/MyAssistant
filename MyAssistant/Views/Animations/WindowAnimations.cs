using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MyAssistant.Views
{
    /// <summary>
    /// Support animation for window
    /// </summary>
    public class WindowAnimations
    {
        /// <summary>
        /// Add slide window from right animation to storyboard
        /// </summary>
        /// <param name="window">Target window</param>
        /// <param name="storyboard">Target storyboard</param>
        /// <param name="durationInSeconds">Duration of animation in seconds</param>
        public async Task SlideFromRight(Window window)
        {
            var storyboard = new Storyboard();
            double duration = 0.2;

            // Slide window from right
            var slideToRightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(duration),
                AccelerationRatio = 0,
                DecelerationRatio = 1,
                From = SystemParameters.WorkArea.Width,
                To = SystemParameters.WorkArea.Width - window.Width
            };

            // Set target property and add to storyboard
            Storyboard.SetTargetProperty(slideToRightAnimation, new PropertyPath("Left"));
            storyboard.Children.Add(slideToRightAnimation);

            // Perform animation
            await StoryboardHelper.PerformAnimation(storyboard, window, duration);
        }

        /// <summary>
        /// Add slide window to right animation to storyboard
        /// </summary>
        /// <param name="window">Target window</param>
        /// <param name="storyboard">Target storyboard</param>
        /// <param name="durationInSeconds">Duration of animation in seconds</param>
        public async Task SlideToRight(Window window)
        {
            var storyboard = new Storyboard();
            double duration = 0.1;

            // Slide window to right
            var slideToRightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(duration),
                AccelerationRatio = 1,
                DecelerationRatio = 0,
                From = SystemParameters.WorkArea.Width - window.Width,
                To = SystemParameters.WorkArea.Width
            };

            // Set target property and add to storyboard
            Storyboard.SetTargetProperty(slideToRightAnimation, new PropertyPath("Left"));
            storyboard.Children.Add(slideToRightAnimation);

            // Perform animation
            await StoryboardHelper.PerformAnimation(storyboard, window, duration);
        }
    }
}
