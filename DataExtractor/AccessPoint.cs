// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccessPoint.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   Defines the AccessPoint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System.Collections.Generic;

    /// <summary>
    /// The access point.
    /// </summary>
    public class AccessPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessPoint"/> class.
        /// </summary>
        /// <param name="mac">
        /// The mac.
        /// </param>
        /// <param name="wifiData">
        /// The wi-fi data.
        /// </param>
        public AccessPoint(string mac, List<WifiData> wifiData)
        {
            this.Mac = mac;
            this.WifiData = wifiData;
        }

        /// <summary>
        /// Gets or sets the mac.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// Gets or sets the wi-fi data.
        /// </summary>
        public List<WifiData> WifiData { get; set; }
    }
}
