// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientRoomData.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   Defines the ClientRoomData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System.Collections.Generic;

    /// <summary>
    /// The client room data.
    /// </summary>
    public class ClientRoomData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRoomData"/> class.
        /// </summary>
        /// <param name="clientName">
        /// The client name.
        /// </param>
        /// <param name="roomData">
        /// The room data.
        /// </param>
        public ClientRoomData(string clientName, List<RoomData> roomData)
        {
            this.ClientName = clientName;
            this.RoomData = roomData;
        }

        /// <summary>
        /// Gets the client name.
        /// </summary>
        public string ClientName { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public List<RoomData> RoomData { get; }
    }
}
