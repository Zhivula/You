using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using You.Properties;
using You.ViewModel;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для TrainingPageView.xaml
    /// </summary>
    public partial class TrainingPageView : UserControl
    {
        public TrainingPageView()
        {
            //        Week week = new Week();
            //        byte sizeG = 15;
            //        int sizeV = 15 * 7;
            //        int sizeResult = sizeV / sizeG;
            //        string[] full = File.ReadAllLines(Path.currentWeekResult, Encoding.Default).Take(sizeV).ToArray();

            //        for (int i = 0; i < sizeV / sizeG; i++)
            //        {
            //            for (byte j = 0; j < sizeG; j++)
            //            {
            //                switch (j)
            //                {
            //                    case 0:
            //                        week.Name1[i] = full[i * sizeG + j];
            //                        break;
            //                    case 1:
            //                        week.Name2[i] = full[i * sizeG + j];
            //                        break;
            //                    case 2:
            //                        week.Name3[i] = full[i * sizeG + j];
            //                        break;
            //                    case 3:
            //                        week.Name4[i] = full[i * sizeG + j];
            //                        break;
            //                    case 4:
            //                        week.Name5[i] = full[i * sizeG + j];
            //                        break;
            //                    case 5:
            //                        week.Plan1[i] = full[i * sizeG + j];
            //                        break;
            //                    case 6:
            //                        week.Plan2[i] = full[i * sizeG + j];
            //                        break;
            //                    case 7:
            //                        week.Plan3[i] = full[i * sizeG + j];
            //                        break;
            //                    case 8:
            //                        week.Plan4[i] = full[i * sizeG + j];
            //                        break;
            //                    case 9:
            //                        week.Plan5[i] = full[i * sizeG + j];
            //                        break;
            //                    case 10:
            //                        week.Clock1[i] = full[i * sizeG + j];
            //                        break;
            //                    case 11:
            //                        week.Clock2[i] = full[i * sizeG + j];
            //                        break;
            //                    case 12:
            //                        week.Clock3[i] = full[i * sizeG + j];
            //                        break;
            //                    case 13:
            //                        week.Clock4[i] = full[i * sizeG + j];
            //                        break;
            //                    case 14:
            //                        week.Clock5[i] = full[i * sizeG + j];
            //                        break;
            //                }
            //            }
            //        }
            //        InitializeComponent();
            //        ChartEffect chartEffect = new ChartEffect();
            //        DataContext = new TrainingViewModel();
            //        byte weekNum = (byte)Settings.Default["NowWeekDay"];
            //        if (weekNum == 0) weekNum = 7;//ЭТО БУДЕТ ВОСКРЕСЕНЬЕ, ИЗНАЧАЛЬНО ИМЕЕТ ЗНАЧЕНИЕ "0"
            //        weekNum--;
            //        for (byte i = 0; i < weekNum; i++)
            //        {
            //            TrainingTableCurrentWeek trainingTableCurrentWeek = new TrainingTableCurrentWeek();
            //            trainingTableCurrentWeek.TitleDay.Content = Days.daysList[i];

            //            trainingTableCurrentWeek.Name1.Text = week.Name1[i];
            //            trainingTableCurrentWeek.Name2.Text = week.Name2[i];
            //            trainingTableCurrentWeek.Name3.Text = week.Name3[i];
            //            trainingTableCurrentWeek.Name4.Text = week.Name4[i];
            //            trainingTableCurrentWeek.Name5.Text = week.Name5[i];

            //            trainingTableCurrentWeek.Plan1.Text = week.Plan1[i];
            //            trainingTableCurrentWeek.Plan2.Text = week.Plan2[i];
            //            trainingTableCurrentWeek.Plan3.Text = week.Plan3[i];
            //            trainingTableCurrentWeek.Plan4.Text = week.Plan4[i];
            //            trainingTableCurrentWeek.Plan5.Text = week.Plan5[i];

            //            trainingTableCurrentWeek.Clock1.Text = week.Clock1[i];
            //            trainingTableCurrentWeek.Clock2.Text = week.Clock2[i];
            //            trainingTableCurrentWeek.Clock3.Text = week.Clock3[i];
            //            trainingTableCurrentWeek.Clock4.Text = week.Clock4[i];
            //            trainingTableCurrentWeek.Clock5.Text = week.Clock5[i];
            //            if (byte.Parse(week.Plan1[i]) == byte.Parse(week.Clock1[i]))
            //            {
            //                trainingTableCurrentWeek.Icon1.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon1.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon1.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon1.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan2[i]) == byte.Parse(week.Clock2[i]))
            //            {
            //                trainingTableCurrentWeek.Icon2.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon2.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon2.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon2.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan3[i]) == byte.Parse(week.Clock3[i]))
            //            {
            //                trainingTableCurrentWeek.Icon3.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon3.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon3.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon3.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan4[i]) == byte.Parse(week.Clock4[i]))
            //            {
            //                trainingTableCurrentWeek.Icon4.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon4.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon4.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon4.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan5[i]) == byte.Parse(week.Clock5[i]))
            //            {
            //                trainingTableCurrentWeek.Icon5.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon5.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon5.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon5.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            } 
            //            trainingTableCurrentWeek.BorderTable.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            //            trainingTableCurrentWeek.FirstGrid.IsEnabled = false;
            //            TrainingWeekPanel.Children.Add(trainingTableCurrentWeek);
            //        }
            //        for (byte i = weekNum; i < 7; i++)
            //        {
            //            TrainingTableCurrentWeek trainingTableCurrentWeek = new TrainingTableCurrentWeek();
            //            trainingTableCurrentWeek.TitleDay.Content = Days.daysList[i];

            //            trainingTableCurrentWeek.Name1.Text = week.Name1[i];
            //            trainingTableCurrentWeek.Name2.Text = week.Name2[i];
            //            trainingTableCurrentWeek.Name3.Text = week.Name3[i];
            //            trainingTableCurrentWeek.Name4.Text = week.Name4[i];
            //            trainingTableCurrentWeek.Name5.Text = week.Name5[i];

            //            trainingTableCurrentWeek.Plan1.Text = week.Plan1[i];
            //            trainingTableCurrentWeek.Plan2.Text = week.Plan2[i];
            //            trainingTableCurrentWeek.Plan3.Text = week.Plan3[i];
            //            trainingTableCurrentWeek.Plan4.Text = week.Plan4[i];
            //            trainingTableCurrentWeek.Plan5.Text = week.Plan5[i];

            //            trainingTableCurrentWeek.Clock1.Text = week.Clock1[i];
            //            trainingTableCurrentWeek.Clock2.Text = week.Clock2[i];
            //            trainingTableCurrentWeek.Clock3.Text = week.Clock3[i];
            //            trainingTableCurrentWeek.Clock4.Text = week.Clock4[i];
            //            trainingTableCurrentWeek.Clock5.Text = week.Clock5[i];

            //            if (byte.Parse(week.Plan1[i]) == byte.Parse(week.Clock1[i]))
            //            {
            //                trainingTableCurrentWeek.Icon1.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon1.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon1.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon1.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan2[i]) == byte.Parse(week.Clock2[i]))
            //            {
            //                trainingTableCurrentWeek.Icon2.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon2.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon2.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon2.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan3[i]) == byte.Parse(week.Clock3[i]))
            //            {
            //                trainingTableCurrentWeek.Icon3.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon3.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon3.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon3.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan4[i]) == byte.Parse(week.Clock4[i]))
            //            {
            //                trainingTableCurrentWeek.Icon4.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon4.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon4.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon4.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            if (byte.Parse(week.Plan5[i]) == byte.Parse(week.Clock5[i]))
            //            {
            //                trainingTableCurrentWeek.Icon5.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            //                trainingTableCurrentWeek.Icon5.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            //            }
            //            else
            //            {
            //                trainingTableCurrentWeek.Icon5.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
            //                trainingTableCurrentWeek.Icon5.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //            }
            //            TrainingWeekPanel.Children.Add(trainingTableCurrentWeek);
            //        }


            //    }
            //    public void ThisDay()
            //    {
            //        ThisDay thisDay = new ThisDay();
            //        byte sizeG = 2;
            //        int sizeV = File.ReadAllLines(@"Today.txt").Where(x => x != "").Count();
            //        int sizeR = sizeV / sizeG;
            //        string[] full = File.ReadAllLines(@"Today.txt", Encoding.Default).Take(sizeV).ToArray();
            //        Array.Resize(ref thisDay.name, sizeR);
            //        Array.Resize(ref thisDay.clock, sizeR);
            //        for (int i = 0; i < sizeR; i++)
            //        {
            //            for (byte j = 0; j < sizeG; j++)
            //            {
            //                switch (j)
            //                {
            //                    case 0:
            //                        thisDay.name[i] = full[i * sizeG + j];
            //                        break;
            //                    case 1:
            //                        thisDay.clock[i] = byte.Parse(full[i * sizeG + j]);
            //                        break;
            //                }
            //            }
            //        }
            //        int count = 0;//БУДЕМ ИСПОЛЬЗОВАТЬ ЕЕ ДЛЯ ПРАВИЛЬНОЙ ИНДЕКСАЦИИ МАССИВА clockResult И  nameResult
            //        string[] nameResult = new string[0];
            //        byte[] clockResult = new byte[0];
            //        for (int i = 0; i < sizeR; i++)
            //        {
            //            if(nameResult.Contains(thisDay.name[i]) == false)
            //            {
            //                for (int j = 0; j < sizeR; j++)
            //                {
            //                    if (thisDay.name[i] == thisDay.name[j])
            //                    {
            //                        //ТУТ ОШИБКА!!!
            //                        count++;
            //                        Array.Resize(ref clockResult, count);
            //                        Array.Resize(ref nameResult, count);
            //                        clockResult[count] += thisDay.clock[j];
            //                        nameResult[count] = thisDay.name[j];
            //                    }
            //                }

            //            }

            //        }

        }
    }
    //public class ThisDay
    //{
    //   public string[] name;
    //   public byte[] clock;
    //}
}
