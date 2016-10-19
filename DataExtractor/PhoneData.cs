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
    using System;

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
        /// <param name="mac">
        /// The mac.
        /// </param>
        /// <param name="distance">
        /// The distance.
        /// </param>
        public PhoneData(string timestamp, string mac, string distance)
        {
            this.Timestamp = long.Parse(timestamp);
            this.Mac = mac;
            this.Distance = double.Parse(distance);
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
        public double Distance { get; }
    }
}
