// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WifiData.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   The wifi data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    /// <summary>
    /// The wi-fi data.
    /// </summary>
    public class WifiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WifiData"/> class. 
        /// Initializes a new instance of the <see cref="PhoneData"/> class.
        /// </summary>
        /// <param name="timestamp">
        /// The timestamp.
        /// </param>
        /// <param name="mac">
        /// The mac.
        /// </param>
        /// <param name="distance">
        /// The distance.
        /// </param>
        public WifiData(long timestamp, string mac, float distance)
        {
            this.Timestamp = timestamp;
            this.Mac = mac;
            this.Distance = distance;
        }

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
