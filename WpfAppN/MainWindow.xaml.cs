using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Timer Timer = new Timer(1000);
        public MainWindow()
        {
            InitializeComponent();
            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var time = DateTime.Now;
            Dispatcher.Invoke(
                DispatcherPriority.Normal,
                (Action)(() =>
                {
                    // Положение секундной стрелки
                    RotateSecond.Angle = 6 * (time.Second);

                    // Положение минутной стрелки
                    RotateMinute.Angle = 6 * time.Minute + RotateSecond.Angle / 60;

                    // Положение часовой стрелки
                    RotateHour.Angle =
                        30 * (time.Hour % 12) + RotateMinute.Angle / 60;
                }));
        }
    }
}
