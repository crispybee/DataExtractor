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

            // Inject and order all the data into FinalDataList
            foreach (var clientData in AllClientPhoneDataList)
            {
                FinalDataList.Add(new ClientRoomData(clientData.ClientName, new List<RoomData>()));

                foreach (var roomGroup in clientData.PhoneData.GroupBy(x => x.Room))
                {
                    var roomList = roomGroup.ToList();
                    var accessPointList = new List<AccessPoint>();
                    
                    foreach (var macGroup in roomList.GroupBy(x => x.Mac))
                    {
                        var macList = macGroup.ToList();
                        var convertedRoomMacListToWifiDataList = new List<WifiData>();

                        foreach (var phoneData in macList)
                        {
                            convertedRoomMacListToWifiDataList.Add(new WifiData(phoneData.Timestamp, phoneData.Mac, phoneData.Distance));
                        }

                        var accessPoint = new AccessPoint(macGroup.Key, convertedRoomMacListToWifiDataList);
                        accessPointList.Add(accessPoint);
                    }

                    // todo: insert the AccessPoint class
                    var roomData = new RoomData(roomGroup.Key, accessPointList);

                    FinalDataList.Last().RoomData.Add(roomData);
                }
            }

            /*
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
            */

            // excelChartCreator.CreateTable();
            Console.WriteLine("END");
        }
    }
}
