using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationTest;

namespace SerializationTest
{
    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool isHatchBack;

        public override string ToString()
        {
            return string.Format("The car {0} hatchback. And it has radio:\n\t {1}", isHatchBack ? "is." : "is not.", TheRadio);
        }
    }


    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;

        public override string ToString()
        {
            string str = base.ToString() + string.Format("\nIts a special James Bond car. \n\tIt {0} fly. \n\tIt {1} submerge.", canFly ? "can" : "can't", canSubmerge ? "can" : "can't");
            return str;
        }
    }
}
