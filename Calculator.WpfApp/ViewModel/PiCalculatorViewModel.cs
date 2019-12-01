using Calculator.WpfApp.Command;
using System;
using System.Collections.Generic;
using System.Text;
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

        private DateTime time;

        public DateTime Time
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
        }

        private void StartCalculation(object obj)
        {

        }
    }
}
