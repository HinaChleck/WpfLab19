using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLab19
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;//Таким образом передали управление
            remove=>CommandManager.RequerySuggested -= value;//событием CanExecuteChanged КоммандМэнеджеру. Эта часть будет общая для все команд. Отличаться они будут только CanExecute и Execute
        }
        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute)//создаем конструктор
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;    
        }
        public bool CanExecute(object parameter)=>canExecute?.Invoke(parameter) ?? true;
        

        public void Execute(object parameter)=>execute(parameter);
        
    }
}
