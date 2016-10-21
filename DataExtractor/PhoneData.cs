// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneData.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   The phone data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    /// <summary>
    /// The phone data.
    /// </summary>
    public class PhoneData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneData"/> class.
        /// </summary>
        /// <param name="timestamp">
        /// The timestamp.
        /// </param>
        /// <param name="room">
        /// The room.
        /// </param>
        /// <param name="mac">
        /// The mac.
        /// </param>
        /// <param name="distance">
        /// The distance.
        /// </param>
        public PhoneData(string timestamp, string room, string mac, string distance)
        {
            this.Timestamp = long.Parse(timestamp);
            this.Room = room;
            this.Mac = mac;
            this.Distance = float.Parse(distance);
        }

        /// <summary>
        /// Gets the room.
        /// </summary>
        public string Room { get; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the mac.
        /// </summary>
        public string Mac { get; }

        /// <summary>
        /// Gets the distance.
        /// </summary>
        public float Distance { get; }
    }
}
