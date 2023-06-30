using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class SurveryElement
    {
        public string Name { get; set; }
        public int ValueOfOne { get; set; }
        public int ValueOfTwo { get; set; }
        public int ValueOfThree { get; set; }
        public int ValueOfFour { get; set; }
        public int ValueOfFive { get; set; }

        public SurveryElement(string name, int valueOfOne, int valueOfTwo, int valueOfThree, int valueOfFour, int valueOfFive)
        {
            Name = name;
            ValueOfOne = valueOfOne;
            ValueOfTwo = valueOfTwo;
            ValueOfThree = valueOfThree;
            ValueOfFour = valueOfFour;
            ValueOfFive = valueOfFive;
        }

        public SurveryElement()
        {
            ValueOfOne = 0;
            ValueOfTwo = 0;
            ValueOfThree = 0;
            ValueOfFour = 0;
            ValueOfFive = 0;
        }
         
        public float GetAvg()
        {
            return (ValueOfOne*1+ValueOfTwo*2+ValueOfThree*3+ValueOfFour*4+ValueOfFive*5)/(ValueOfFive+ValueOfFour+ValueOfThree+ValueOfTwo+ValueOfOne);
        }
    }
}
