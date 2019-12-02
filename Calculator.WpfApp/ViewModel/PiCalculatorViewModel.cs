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
            double piSum = 0;
            Stopwatch stopwatch = new Stopwatch();
            List<Task<double>> tasks = new List<Task<double>>();

            stopwatch.Start();

            for (int i = 0; i < Threads; i++)
            {
                tasks.Add(Task.Run(() => GeneratePointAsync(Calculations / Threads)));
            }

            foreach (var item in tasks)
            {
                piSum += await item;
            }

            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            Result = piSum / Threads;
        }


        private async Task<double> GeneratePointAsync(int pointsToGenerate)
        {
            Random random = new Random();
            int inCircle = 0;
            Models.Point point = new Models.Point();
            await Task.Run(() =>
            {
                for (int i = 0; i < pointsToGenerate; i++)
                {
                    point.XCoordinate = random.NextDouble();
                    point.YCoordinate = random.NextDouble();
                    if (Math.Sqrt(Math.Pow(point.XCoordinate, 2) + Math.Pow(point.YCoordinate, 2)) <= 1)
                        inCircle++;
                    Progress = (i * 100) / Calculations;
                }
            });
            return (double)inCircle * 4 / pointsToGenerate;
        }
    }
}
