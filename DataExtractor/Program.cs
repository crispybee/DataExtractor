// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The phone name 1.
        /// </summary>
        private const string PhoneName1 = "Tim";

        /// <summary>
        /// The phone name 2.
        /// </summary>
        private const string PhoneName2 = "Andi";

        /// <summary>
        /// The phone name 3.
        /// </summary>
        private const string PhoneName3 = "Kemal";

        /// <summary>
        /// The phone name 4.
        /// </summary>
        private const string PhoneName4 = "Thomas";

        /// <summary>
        /// The phone data of Andreas.
        /// </summary>
        private static readonly List<PhoneData> AndiPhoneData = new List<PhoneData>();

        /// <summary>
        /// The tim phone data.
        /// </summary>
        private static readonly List<PhoneData> TimPhoneData = new List<PhoneData>();

        /// <summary>
        /// The phone data of Kemal.
        /// </summary>
        private static readonly List<PhoneData> KemalPhoneData = new List<PhoneData>();

        /// <summary>
        /// The Thomas phone data.
        /// </summary>
        private static readonly List<PhoneData> ThomasPhoneData = new List<PhoneData>();

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            Directory.CreateDirectory("Tim");
            Directory.CreateDirectory("Andi");
            Directory.CreateDirectory("Kemal");
            Directory.CreateDirectory("Thomas");

            var reader = new StreamReader(File.OpenRead(@"VS.csv"));
            
            var timestamp = new List<string>();
            var id = new List<string>();
            var mac = new List<string>();
            var distance = new List<string>();

            // Get only relevant values
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(';');

                    timestamp.Add(values[1]);
                    id.Add(values[2]);
                    mac.Add(values[4]);
                    distance.Add(values[5]);
                }
            }

            // Split phones to individual lists
            for (int i = 0; i < timestamp.Count; i++)
            {
                if (id[i] == PhoneName1)
                {
                    TimPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
                else if (id[i] == PhoneName2)
                {
                    AndiPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
                else if (id[i] == PhoneName3)
                {
                    KemalPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
                else if (id[i] == PhoneName4)
                {
                    ThomasPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
            }

            var macListArrayTim = new List<List<PhoneData>>();
            var macListArrayAndi = new List<List<PhoneData>>();
            var macListArrayKemal = new List<List<PhoneData>>();
            var macListArrayThomas = new List<List<PhoneData>>();

            // group list by mac adress by Tim
            foreach (var phoneDataMacList in TimPhoneData.GroupBy(x => x.Mac))
            {
                var groupedMacList = phoneDataMacList.ToList();
                macListArrayTim.Add(groupedMacList);
            }

            // group list by mac adress by Andi
            foreach (var phoneDataMacList in AndiPhoneData.GroupBy(x => x.Mac))
            {
                var groupedMacList = phoneDataMacList.ToList();
                macListArrayAndi.Add(groupedMacList);
            }

            // group list by mac adress by Kemal
            foreach (var phoneDataMacList in KemalPhoneData.GroupBy(x => x.Mac))
            {
                var groupedMacList = phoneDataMacList.ToList();
                macListArrayKemal.Add(groupedMacList);
            }

            // group list by mac adress by Thomas
            foreach (var phoneDataMacList in ThomasPhoneData.GroupBy(x => x.Mac))
            {
                var groupedMacList = phoneDataMacList.ToList();
                macListArrayThomas.Add(groupedMacList);
            }

            for (int i = 0; i < macListArrayTim.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName1 + "\\" + i + @".csv"));

                foreach (var phoneData in macListArrayTim[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < macListArrayAndi.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName2 + "\\" + i + @".csv"));

                foreach (var phoneData in macListArrayAndi[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < macListArrayKemal.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName3 + "\\" + i + @".csv"));

                foreach (var phoneData in macListArrayKemal[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < macListArrayThomas.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName4 + "\\" + i + @".csv"));

                foreach (var phoneData in macListArrayThomas[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            Console.WriteLine("END");
        }
    }
}
