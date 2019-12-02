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
        private List<Models.Point> points;
        
        public List<Models.Point> Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }


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
            int inRadius = 0;
            Stopwatch stopwatch = new Stopwatch();
            Points = new List<Models.Point>();

            stopwatch.Start();
            Points = await GeneratePointsAsync();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            inRadius = Points.Select(p => p).Where(w => Math.Sqrt(Math.Pow(w.XCoordinate,2) + Math.Pow(w.YCoordinate,2)) <= 1).Count();
            Result = (double) 4 * inRadius / Calculations;
        }

        private async Task<List<Models.Point>> GeneratePointsAsync()
        {
            Random random = new Random();
            var result = new List<Models.Point>();
            List<Task> tasks = new List<Task>();
            await Task.Run(() => 
            {
                for (int i = 0; i < Calculations; i++)
                {
                    result.Add(new Models.Point(random.NextDouble(), random.NextDouble()));
                    Progress = (result.Count() * 100) / Calculations;
                }
            } );
            return result;
        }
    }
}
