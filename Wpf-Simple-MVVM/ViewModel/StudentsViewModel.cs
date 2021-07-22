using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Simple_MVVM.Model;
using Wpf_Simple_MVVM.MVVMBase;

namespace Wpf_Simple_MVVM.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public ICommand UpdateStudentNameCommand { get; set; }
        public string SelectedStudentName { get; set; }

        public StudentsViewModel() 
        {
            UpdateStudentNameCommand = new RelayCommand<Student>(SelectedStudentDetails); //listemize yeni öğrenciler ekledim
            StudentList = new ObservableCollection<Student>();
            StudentList.Add(new Student() { Name = "Doğan" });
            StudentList.Add(new Student() { Name = "Dorukan" });
            StudentList.Add(new Student() { Name = "Mehmet" });
            StudentList.Add(new Student() { Name = "Cengiz" });
        }

        private void SelectedStudentDetails(Student obj)
        {
            if (obj != null)
            {
                this.SelectedStudentName = obj.Name;
                // burada özellik değişikliğini cağırmadım direk seçilen öğrenciye gittim.
                this.RaisePropertyChanged("SelectedStudentName");
            }
        }
    }
}
