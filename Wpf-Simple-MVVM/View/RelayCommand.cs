using System;
using System.Windows.Input;

namespace Wpf_Simple_MVVM.MVVMBase
{
    public class RelayCommand<T> : ICommand
    {
        // özel alanlar 
        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;
        //canexecute,execute komut durumunu uygulayan ve belirleyen olaylarla ilişkilendirir
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        //CommandManager bir şeyin değiştiğini düşündüğünde CommandManager.Requery Recommended olayı başlatılır
        //ve bu komutların yürütme yeteneğini etkileyecektir. Örneğin bu bir odak değişikliği olabilir.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
