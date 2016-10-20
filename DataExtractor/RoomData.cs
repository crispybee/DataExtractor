// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomData.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   The room data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System.Collections.Generic;

    /// <summary>
    /// The room data.
    /// </summary>
    public class RoomData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomData"/> class.
        /// </summary>
        /// <param name="roomName">
        /// The room name.
        /// </param>
        /// <param name="wifiData">
        /// The wi-fi data.
        /// </param>
        public RoomData(string roomName, List<WifiData> wifiData)
        {
            this.RoomName = roomName;
            this.WifiData = wifiData;
        }

        /// <summary>
        /// Gets the wi-fi data.
        /// </summary>
        public List<WifiData> WifiData { get; }

        /// <summary>
        /// Gets or sets the room name.
        /// </summary>
        public string RoomName { get; set; }
    }
}
