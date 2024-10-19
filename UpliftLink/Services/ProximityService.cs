using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace UpliftLink.Services
{
    /// <summary>
    /// Service for managing proximity detection of nearby devices.
    /// </summary>
    internal class ProximityService
    {
        private readonly IAdapter _bluetoothAdapter;
        private readonly IBluetoothLE _bluetoothLE;
        private bool isNearbyDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProximityService"/> class.
        /// </summary>
        public ProximityService()
        {
            _bluetoothLE = CrossBluetoothLE.Current;
            _bluetoothAdapter = CrossBluetoothLE.Current.Adapter;
            _bluetoothAdapter.DeviceDiscovered += OnDeviceDiscovered;
        }

        /// <summary>
        /// Starts the proximity detection process to scan for nearby devices.
        /// </summary>
        public async void StartProximityDetection()
        {
            if (_bluetoothLE.State == BluetoothState.On)
            {
                await _bluetoothAdapter.StartScanningForDevicesAsync();
            }
        }

        /// <summary>
        /// Stops the proximity detection process.
        /// </summary>
        public async void StopProximityDetection()
        {
            if (_bluetoothAdapter.IsScanning)
            {
                await _bluetoothAdapter.StopScanningForDevicesAsync();
            }
        }

        /// <summary>
        /// Sends a message to a nearby device identified by its unique MAC ID.
        /// </summary>
        /// <param name="macId">The MAC ID of the target device.</param>
        /// <param name="message">The message to send.</param>
        public async void SendMessage(string macId, string message)
        {
            var device = _bluetoothAdapter.ConnectedDevices.FirstOrDefault(d => d.Id.ToString() == macId);
            if (device != null && await IsAppInstalledOnDevice(device))
            {
                await SendMessageAsync(device, message);
            }
        }

        /// <summary>
        /// Event handler for device discovery.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDeviceDiscovered(object sender, DeviceEventArgs e)
        {
            // Logic to handle device discovery
            // For example, you can set isNearbyDevice to true if a specific device is found
            isNearbyDevice = true;
        }

        /// <summary>
        /// Checks if the app is installed on the specified device.
        /// </summary>
        /// <param name="device">The target device.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the app is installed on the device.</returns>
        private async Task<bool> IsAppInstalledOnDevice(IDevice device)
        {
            var services = await device.GetServicesAsync();
            return services.Any(service => service.Id == GattConstants.CustomServiceUuid);
        }

        /// <summary>
        /// Sends a message to the specified device in chunks if it exceeds the 32-character limit.
        /// </summary>
        /// <param name="device">The target device.</param>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task SendMessageAsync(IDevice device, string message)
        {
            var service = await device.GetServiceAsync(GattConstants.CustomServiceUuid);
            var characteristic = await service.GetCharacteristicAsync(GattConstants.CustomCharacteristicUuid);

            int chunkSize = 32;
            for (int i = 0; i < message.Length; i += chunkSize)
            {
                string chunk = message.Substring(i, Math.Min(chunkSize, message.Length - i));
                var bytes = Encoding.UTF8.GetBytes(chunk);
                await characteristic.WriteAsync(bytes);
            }
        }
    }

    /// <summary>
    /// Contains constants for GATT service and characteristic UUIDs.
    /// </summary>
    public static class GattConstants
    {
        /// <summary>
        /// The UUID for the custom GATT service.
        /// </summary>
        public static readonly Guid CustomServiceUuid = Guid.Parse("0000180D-0000-1000-8000-00805F9B34FB");

        /// <summary>
        /// The UUID for the custom GATT characteristic.
        /// </summary>
        public static readonly Guid CustomCharacteristicUuid = Guid.Parse("00002A37-0000-1000-8000-00805F9B34FB");
    }
}
