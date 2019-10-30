using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using You.ViewModel;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace You
{
    public static class Resource
    {
        public static string[] name;
        public static int[] clock;
    }
    public static class VictoryData
    {
        public static string[] category;
        public static string[] name;
        public static string[] time;
        public static byte[] ochki;
    }
    public class Help : UserControl
    {
        public void Successfully()
        {
            WindowSuccessfully window = new WindowSuccessfully();
            window.Show();
            DoubleAnimation windowAnimation = new DoubleAnimation();
            windowAnimation.From = window.Opacity;
            windowAnimation.To = 0;
            windowAnimation.Duration = TimeSpan.FromSeconds(5);
            windowAnimation.Completed += window.ClosedThisWindow;
            window.BeginAnimation(OpacityProperty, windowAnimation);
        }
        public void NotSuccessfully()
        {
            WindowSuccessfully window = new WindowSuccessfully();
            window.TextLabel.Content = "Ошибка!";
            window.Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            window.Icon.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            window.Show();
            DoubleAnimation windowAnimation = new DoubleAnimation();
            windowAnimation.From = window.Opacity;
            windowAnimation.To = 0;
            windowAnimation.Duration = TimeSpan.FromSeconds(5);
            windowAnimation.Completed += window.ClosedThisWindow;
            window.BeginAnimation(OpacityProperty, windowAnimation);
        }

    }
    public class Days
    {
        public static List<string> daysList = new List<string>(7) {"ПОНЕДЕЛЬНИК", "ВТОРНИК", "СРЕДА", "ЧЕТВЕРГ", "ПЯТНИЦА", "СУББОТА", "ВОСКРЕСЕНЬЕ"};
    }
    public static class Path
    {
        public static string reward = @"Reward.txt";
        public static string lastWeekResult = @"LastWeekResult.txt";
        public static string currentWeekResult = @"CurrentWeekResult.txt";
        public static string currentWeek = @"CurrentWeek.txt";
        public static string lastWeek = @"LastWeek.txt";
        public static string currentMonth = @"CurrentMonth.txt";
    }
    //public class Week
    //{
    //    public string[] Name1 = new string[7];
    //    public string[] Name2 = new string[7];
    //    public string[] Name3 = new string[7];
    //    public string[] Name4 = new string[7];
    //    public string[] Name5 = new string[7];
    //    public string[] Plan1 = new string[7];
    //    public string[] Plan2 = new string[7];
    //    public string[] Plan3 = new string[7];
    //    public string[] Plan4 = new string[7];
    //    public string[] Plan5 = new string[7];
    //    public string[] Clock1 = new string[7];
    //    public string[] Clock2 = new string[7];
    //    public string[] Clock3 = new string[7];
    //    public string[] Clock4 = new string[7];
    //    public string[] Clock5 = new string[7];
    //}
}
