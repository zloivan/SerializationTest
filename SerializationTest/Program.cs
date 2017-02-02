using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Lesson from here...
//https://professorweb.ru/my/csharp/thread_and_files/level4/4_4.php
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
            string str="";
            foreach (double st in stationPresets)
            {
                str += st.ToString();
                
                str += ", ";
            }
            str=str.Remove(str.Length-2,2);
            return str;
        }
        public override string ToString()
        {
            return string.Format("Radio model {3}:\n\t {0} tweeters \n\t {1} Subwofers \n\t Station presets: {2}  ", hasTweeters?"has":"has not",hasSubWoofers?"has": "has not",PresetFormat(),radioID);
        }
    }
    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool isHatchBack;

        public override string ToString()
        {
            return string.Format("The car {0} hatchback. And it has radio:\n\t {1}", isHatchBack?"is.":"is not.",TheRadio);
        }
    }
    [Serializable]
    public class JamesBondCar : Car
    {
        public bool canFly;
        public bool canSubmerge;

        public override string ToString()
        {
            string str= base.ToString()+string.Format("\nIts a special James Bond car. \n\tIt {0} fly. \n\tIt {1} submerge.",canFly?"can":"can't",canSubmerge?"can":"can't");
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            JamesBondCar jbc = new JamesBondCar();

            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.TheRadio.stationPresets = new double[] {96.7,105.9,106.1};
            jbc.TheRadio.hasTweeters = true;
            Console.WriteLine(jbc);
            SaveBinaryFormat(jbc,"carData.dat");
            JamesBondCar jbc2 = new JamesBondCar();
            LoadBinaryFormat(out jbc2, "carData.dat");

            Console.WriteLine(jbc2);

        }

        static void SaveBinaryFormat(object objGraph, string fileName)
        {
            //using System.Runtime.Serialization.Formatters.Binary;
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine($"Saving to {fileName}");
        }
        static void LoadBinaryFormat(out JamesBondCar loadedFile, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {
                loadedFile = (JamesBondCar)binFormat.Deserialize(fStream);
            }

            Console.WriteLine($"Loading from {fileName}");
        }
    }
}
