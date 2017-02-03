using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Lesson from here...
//https://professorweb.ru/my/csharp/thread_and_files/level4/4_4.php
namespace SerializationTest
{
   
    

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
            SaveSoapFormat(jbc,"carData2.dat");

            JamesBondCar jbc2,jbc3; 
            
            LoadBinaryFormat(out jbc2, "carData.dat");

            LoadSoapFormat(out jbc3, "carData2.dat");

            Console.WriteLine(jbc2);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(jbc3);

        }
        #region BinaryFormatter
        //BinaryFormatter
        static void SaveBinaryFormat(object objGraph, string fileName)
        {
            //using System.Runtime.Serialization.Formatters.Binary;
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine($"Saving to {fileName} by binary formatter");
        }

        static void LoadBinaryFormat(out JamesBondCar loadedFile, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {
                loadedFile = (JamesBondCar)binFormat.Deserialize(fStream);
            }

            Console.WriteLine($"Loading from {fileName} by binary formatter");
        }
        #endregion

        //using System.Runtime.Serialization.Formatters.Soap;
        //ref System.Runtime.Serialization.Formatters.Soap.dll
        #region SoapFormatter
        static void SaveSoapFormat(object objGraph, string fileName)
        {
            //using System.Runtime.Serialization.Formatters.Binary;
             SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine($"Saving to {fileName} by Soap formatter");
        }

        static void LoadSoapFormat(out JamesBondCar loadedFile, string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {
                loadedFile = (JamesBondCar)soapFormat.Deserialize(fStream);
            }

            Console.WriteLine($"Loading from {fileName} by Soap formatter");
        }
        #endregion
    }
}
