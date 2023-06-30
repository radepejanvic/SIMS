using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.AppointmentService.Interface;

namespace Library.ViewModel.Structure
{
    public  class AnamnesisViewModel : ViewModelBase
    {
        public Anamnesis _anamnesis;
        public string Sympthoms => _anamnesis.Sympthoms;
        public string Observations => _anamnesis.Observations;
        public string Conclusions => _anamnesis.Conclusions;

        public AnamnesisViewModel(Anamnesis anamnesis)
        {
            _anamnesis = anamnesis;
        }

        
    }
}
