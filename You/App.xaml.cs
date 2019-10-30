using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using You.Properties;
using System.Globalization;
using System.IO;

namespace You
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            GregorianCalendar gregorianCalendar = new GregorianCalendar();//КАЛЕНДАРЬ
            DateTime dateTime = DateTime.Now;//ТЕКУЩАЯ ДАТА
            int week = gregorianCalendar.GetWeekOfYear(dateTime,CalendarWeekRule.FirstDay, DayOfWeek.Monday);//ПОЛУЧАЕМ ЗНАЧЕНИЕ ТЕКУЩЕЙ НЕДЕЛИ В ГОДУ
            int month = DateTime.Now.Month;//ТЕКУЩИЙ МЕСЯЦ ГОДА

            if ((int)Settings.Default["CurrentWeek"] != week)
            {
                Settings.Default["CurrentWeek"] = week;
                Settings.Default["CountGoodHoursInWeek"] = 0;//ОБНУЛЯЕМ ЗНАЧЕНИЕ ПРИ НАСТУПЛЕНИИ НОВОЙ НЕДЕЛИ
                File.WriteAllText(Path.lastWeek, string.Empty);//ОЧИЩАЕМ ФАЙЛ LastWeek.txt
                File.WriteAllText(Path.lastWeek, File.ReadAllText(Path.currentWeek));
                File.WriteAllText(Path.currentWeek, string.Empty);//ОЧИЩАЕМ ФАЙЛ CurrentWeek.txt
                Settings.Default.Save();
            }
            if ((int)Settings.Default["CurrentMonth"] != month)
            {
                Settings.Default["CurrentMonth"] = month;
                Settings.Default["CountGoodHoursInMonth"] = 0;//ОБНУЛЯЕМ ЗНАЧЕНИЕ ПРИ НАСТУПЛЕНИИ НОВОГО МЕСЯЦА
                File.WriteAllText(Path.currentMonth, string.Empty);//ОЧИЩАЕМ ФАЙЛ CurrentMonth.txt
                Settings.Default.Save();
            }
        }
    }
}
