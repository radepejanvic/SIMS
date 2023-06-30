using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Library.Model;
using Library.Service.AppointmentService;
using Library.Service.FarmaceuticalService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService;
using Library.Service.RefferalService;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.View.Form
{
    /// <summary>
    /// Interaction logic for LeaveRequestFormView.xaml
    /// </summary>
    public partial class LeaveRequestFormView : Window
    {
        public LeaveRequestFormView(Doctor doctor, ISchedulingService schedulingService, ILeaveRequestService leaveRequestService)
        {
            InitializeComponent();
            DataContext = new LeaveRequestFormViewModel(doctor, schedulingService, leaveRequestService);
        }
    }
}
