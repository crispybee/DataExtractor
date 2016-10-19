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
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead(@"VS.csv"));
            
            var timestamp = new List<string>();
            var id = new List<string>();
            var mac = new List<string>();
            var distance = new List<string>();

            var andiPhoneData = new List<PhoneData>();
            var timPhoneData = new List<PhoneData>();

            // Get only relevant values
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                timestamp.Add(values[1]);
                id.Add(values[2]);
                mac.Add(values[4]);
                distance.Add(values[5]);
            }

            // Split phones to individual lists
            for (int i = 0; i < timestamp.Count; i++)
            {
                if (id[i] == "Tim")
                {
                    timPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
                else if (id[i] == "Andi")
                {
                    andiPhoneData.Add(new PhoneData(timestamp[i], mac[i], distance[i]));
                }
            }

            var macListArray = new List<List<PhoneData>>();

            // group list by mac adress
            foreach (var phoneDataMacList in timPhoneData.GroupBy(x => x.Mac))
            {
                var groupedMacList = phoneDataMacList.ToList();
                macListArray.Add(groupedMacList);
            }

            for (int i = 0; i < macListArray.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(i + @".csv"));

                foreach (var phoneData in macListArray[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }
            
            Console.WriteLine("END");
        }
    }
}
