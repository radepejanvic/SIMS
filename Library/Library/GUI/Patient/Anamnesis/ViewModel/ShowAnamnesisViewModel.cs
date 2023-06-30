using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Table
{
    public class ShowAnamnesisViewModel : ViewModelBase
    {
        public AnamnesisViewModel Anamnesis { get; set; }
        private string? _sympthoms;
        public string? Sympthoms
        {
            get
            {
                return _sympthoms;
            }
            set
            {
                _sympthoms = value;
                OnPropertyChanged(nameof(Sympthoms));
            }
        }

        private string? _observation;
        public string? Observation
        {
            get
            {
                return _observation;
            }
            set
            {
                _observation = value;
                OnPropertyChanged(nameof(Observation));
            }
        }

        private string? _conclusion;
        public string? Conclusion
        {
            get
            {
                return _conclusion;

            }
            set
            {
                _conclusion = value;
                OnPropertyChanged(nameof(Conclusion));
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;

            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public ICommand SubmitAnamnesis { get; }

        public ShowAnamnesisViewModel(AnamnesisViewModel anamnesis, IAnamnesisService anamnesisService, Appointment appointment, bool isEnabled)
        {
            Anamnesis = anamnesis;

            _sympthoms = anamnesis?.Sympthoms ?? "";
            _observation = anamnesis?.Observations ?? "";
            _conclusion = anamnesis?.Conclusions ?? "";

            _isEnabled = isEnabled;
            SubmitAnamnesis = new SubmitAnamnesisCommand(this, anamnesisService, appointment);
        }
    }
}
