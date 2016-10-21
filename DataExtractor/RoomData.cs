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
        /// <param name="accessPointList">
        /// The access Point List.
        /// </param>
        public RoomData(string roomName, List<AccessPoint> accessPointList)
        {
            this.RoomName = roomName;
            this.AccessPointList = accessPointList;
        }

        /// <summary>
        /// Gets the wi-fi data.
        /// </summary>
        public List<AccessPoint> AccessPointList { get; }

        /// <summary>
        /// Gets the room name.
        /// </summary>
        public string RoomName { get; }
    }
}
