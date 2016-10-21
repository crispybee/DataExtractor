// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientData.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   Defines the ClientData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System.Collections.Generic;

    /// <summary>
    /// The client data.
    /// </summary>
    public class ClientData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientData"/> class.
        /// </summary>
        /// <param name="clientName">
        /// The client name.
        /// </param>
        /// <param name="phoneData">
        /// The phone Data.
        /// </param>
        public ClientData(string clientName, List<PhoneData> phoneData)
        {
            this.ClientName = clientName;
            this.PhoneData = phoneData;
        }

        /// <summary>
        /// Gets the client name.
        /// </summary>
        public string ClientName { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public List<PhoneData> PhoneData { get; }
    }
}
