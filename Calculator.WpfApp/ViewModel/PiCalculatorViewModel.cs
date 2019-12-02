using Calculator.WpfApp.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.WpfApp.ViewModel
{
    class PiCalculatorViewModel : BaseViewModel
    {
        #region Properties


        private int calculations;

        public int Calculations
        {
            get { return calculations; }
            set
            {
                calculations = value;
                OnPropertyChanged(nameof(Calculations));
            }
        }

        private int threads;

        public int Threads
        {
            get { return threads; }
            set
            {
                threads = value;
                OnPropertyChanged(nameof(Threads));
            }
        }

        private int progress;

        public int Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        private double time;

        public double Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }


        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }



        #endregion

        #region Commands
        public ICommand CmdStart { get; set; }
        #endregion

        public PiCalculatorViewModel()
        {
            CmdStart = new RelayCommand(StartCalculation);
            Threads = 1;
        }

        private async void StartCalculation(object obj)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int inRadius = await GeneratePointAsync();

            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            Result = (double)4 * inRadius / Calculations;
        }


        private async Task<int> GeneratePointAsync()
        {
            Random random = new Random();
            int inCircle = 0;
            Models.Point point = new Models.Point();
            await Task.Run(() =>
            {
                for (int i = 0; i < Calculations; i++)
                {
                    point.XCoordinate = random.NextDouble();
                    point.YCoordinate = random.NextDouble();
                    if (Math.Sqrt(Math.Pow(point.XCoordinate, 2) + Math.Pow(point.YCoordinate, 2)) <= 1)
                        inCircle++;
                    Progress = (i * 100) / Calculations;
                }
            });
            return inCircle;
        }
    }
}
