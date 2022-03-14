using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLab19.Models;

namespace WpfLab19.ViewModels
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int radius;
        public int Radius
        { 
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged();
            } 
        }
        private double length;
        public double Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand LengthCommand { get; }
        private void OnLengthCommandExecute(object p)
        {
            Length = Ariph.Length(Radius);
        }
        private bool CanLengthCommandExecuted(object p)
        {
            if (Radius != 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel()
        {
            LengthCommand = new RelayCommand(OnLengthCommandExecute, CanLengthCommandExecuted);
        }
    }
}
