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
        /// The all client phone data list.
        /// </summary>
        private static readonly List<ClientData> AllClientPhoneDataList = new List<ClientData>();

        /// <summary>
        /// The final data list.
        /// </summary>
        private static readonly List<ClientRoomData> FinalDataList = new List<ClientRoomData>();

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            var excelChartCreator = new ExcelChartCreator();
            var reader = new StreamReader(File.OpenRead(currentPath + args[0]));

            var timestamp = new List<string>();
            var roomEntry = new List<string>();
            var id = new List<string>();
            var mac = new List<string>();
            var distance = new List<string>();
            var roomListArrayTim = new List<List<PhoneData>>();
            var roomListArrayAndi = new List<List<PhoneData>>();
            var roomListArrayKemal = new List<List<PhoneData>>();
            var roomListArrayThomas = new List<List<PhoneData>>();
            var phoneIdList = new List<string>();

            // Get only relevant values
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(';');

                    timestamp.Add(values[1]);
                    roomEntry.Add(values[2]);
                    id.Add(values[3]);
                    mac.Add(values[4]);
                    distance.Add(values[5]);
                }
            }
            
            // Get all phone names and create a folder for each one
            foreach (string name in id)
            {
                if (!phoneIdList.Contains(name))
                {
                    phoneIdList.Add(name);
                    AllClientPhoneDataList.Add(new ClientData(name, new List<PhoneData>()));
                    Directory.CreateDirectory(name);
                }
            }

            // Split phones to individual lists
            for (int i = 0; i < id.Count; i++)
            {
                var phoneData = new PhoneData(timestamp[i], roomEntry[i], mac[i], distance[i]);

                for (int j = 0; j < phoneIdList.Count; j++)
                {
                    if (id[i] == phoneIdList[j])
                    {
                        // Add phoneData to fitting names as PhoneData objects
                        AllClientPhoneDataList.First(x => x.ClientName.Equals(phoneIdList[j])).PhoneData.Add(phoneData);
                    }
                }
            }

            foreach (var clientData in AllClientPhoneDataList)
            {
                FinalDataList.Add(new ClientRoomData(clientData.ClientName, new List<RoomData>()));

                foreach (var roomGroup in clientData.PhoneData.GroupBy(x => x.Room))
                {
                    var roomList = roomGroup.ToList();
                    var convertedRoomListToWifiDataList = new List<WifiData>();

                    foreach (var phoneData in roomList)
                    {
                        convertedRoomListToWifiDataList.Add(new WifiData(phoneData.Timestamp, phoneData.Mac, phoneData.Distance));
                    }

                    // todo: insert the AccessPoint class
                    RoomData roomData = new RoomData(roomGroup.Key, convertedRoomListToWifiDataList);

                    FinalDataList.Last().RoomData.Add(roomData);
                }
            }

            // group list by mac adress by Tim
            foreach (var phoneDataMacList in TimPhoneData.GroupBy(x => x.Room))
            {
                var groupedMacList = phoneDataMacList.ToList();
                roomListArrayTim.Add(groupedMacList);
            }

            // group list by mac adress by Andi
            foreach (var phoneDataMacList in AndiPhoneData.GroupBy(x => x.Room))
            {
                var groupedMacList = phoneDataMacList.ToList();
                roomListArrayAndi.Add(groupedMacList);
            }

            // group list by mac adress by Kemal
            foreach (var phoneDataMacList in KemalPhoneData.GroupBy(x => x.Room))
            {
                var groupedMacList = phoneDataMacList.ToList();
                roomListArrayKemal.Add(groupedMacList);
            }

            // group list by mac adress by Thomas
            foreach (var phoneDataMacList in ThomasPhoneData.GroupBy(x => x.Room))
            {
                var groupedMacList = phoneDataMacList.ToList();
                roomListArrayThomas.Add(groupedMacList);
            }

            int h = 0;
            var listOfGroupedRoomsAndGroupedMacs = new List<PhoneData>();

            foreach (var list in roomListArrayTim)
            {
                int j = 0;

                foreach (var phoneData in list.GroupBy(x => x.Mac))
                {
                    var phoneDataListGroupedByMac = new List<PhoneData>();

                    phoneDataListGroupedByMac = phoneData.ToList();
                    listOfGroupedRoomsAndGroupedMacs.AddRange(phoneDataListGroupedByMac);

                    var writer = new StreamWriter(File.OpenWrite(PhoneName1 + "\\" + "grouped" + h + "_" + j + @".csv"));
                    
                    for (int i = 0; i < phoneDataListGroupedByMac.Count; i++)
                    {
                        writer.WriteLine(phoneDataListGroupedByMac[i].Timestamp + ";" + phoneDataListGroupedByMac[i].Room + ";" + phoneDataListGroupedByMac[i].Mac + ";" + phoneDataListGroupedByMac[i].Distance);
                    }

                    writer.Close();

                    phoneDataListGroupedByMac.Clear();
                    j++;
                }

                h++;
            }

            Console.WriteLine(listOfGroupedRoomsAndGroupedMacs);
            /*

            for (int i = 0; i < roomListArrayTim.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName1 + "\\" + i + @".csv"));

                foreach (var phoneData in roomListArrayTim[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Room + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < roomListArrayAndi.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName2 + "\\" + i + @".csv"));

                foreach (var phoneData in roomListArrayAndi[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Room + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < roomListArrayKemal.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName3 + "\\" + i + @".csv"));

                foreach (var phoneData in roomListArrayKemal[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Room + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }

            for (int i = 0; i < roomListArrayThomas.Count; i++)
            {
                var writer = new StreamWriter(File.OpenWrite(PhoneName4 + "\\" + i + @".csv"));

                foreach (var phoneData in roomListArrayThomas[i])
                {
                    writer.WriteLine(phoneData.Timestamp + ";" + phoneData.Room + ";" + phoneData.Mac + ";" + phoneData.Distance);
                }

                writer.Close();
            }
            */

            // excelChartCreator.CreateTable();
            Console.WriteLine("END");
        }
    }
}
