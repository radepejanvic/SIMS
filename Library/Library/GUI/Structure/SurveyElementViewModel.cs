using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel.Structure
{
    public class SurveyElementViewModel : ViewModelBase
    {
        public SurveryElement SurveryElement;
        public string Name => SurveryElement.Name;
        public int ValueOfOne => SurveryElement.ValueOfOne;
        public int ValueOfTwo => SurveryElement.ValueOfTwo;
        public int ValueOfThree => SurveryElement.ValueOfThree;
        public int ValueOfFour => SurveryElement.ValueOfFour;
        public int ValueOfFive =>SurveryElement.ValueOfFive;

        public SurveyElementViewModel(SurveryElement surveryElement)
        {
            SurveryElement = surveryElement;
        }
    }
}
