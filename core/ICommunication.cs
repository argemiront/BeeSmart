using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    public interface ICommunication
    {
        /// <summary>
        /// Disconnect the serial communication
        /// </summary>
        /// <returns>returns true if disconnections was succefull</returns>
        bool Disconnect();

        /// <summary>
        /// Connect with specified port and bound rate
        /// </summary>
        /// <param name="commPort">Serial Port</param>
        /// <param name="boundRate">Bound rate</param>
        /// <returns>returns true if connection was succefull</returns>
        bool Connect(string commPort, int boundRate);

        /// <summary>
        /// Discover devices joined to network
        /// </summary>
        void NetworkDiscover();

        /// <summary>
        /// Get the status of all PAN devices and updates the device table
        /// </summary>
        void UpdateAllDeviceStatus();

        /// <summary>
        /// Get the status of the specified device
        /// </summary>
        /// <param name="Address64bits">64 bits address of the device</param>
        /// <returns>Returns true if the status was succefull updated</returns>
        bool UpdateDeviceStatus(string Address64bits);
    }
}
