using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTest
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RF6";

        string PresetFormat()
        {
            string str = "";
            foreach (double st in stationPresets)
            {
                str += st.ToString();

                str += ", ";
            }
            str = str.Remove(str.Length - 2, 2);
            return str;
        }
        public override string ToString()
        {
            return string.Format("Radio model {3}:\n\t {0} tweeters \n\t {1} Subwofers \n\t Station presets: {2}  ", hasTweeters ? "has" : "has not", hasSubWoofers ? "has" : "has not", PresetFormat(), radioID);
        }
    }
}
