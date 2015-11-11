﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Emulator;

namespace Snowflake.Service.Manager
{
    public interface IEmulatorInstanceManager : IDisposable
    {
        /// <summary>
        /// Adds an instance to the container.
        /// </summary>
        void AddInstance(IEmulatorInstance instance);
        /// <summary>
        /// Removes an instance from the container;
        /// </summary>
        /// <param name="instance"></param>
        void RemoveInstance(IEmulatorInstance instance);
        /// <summary>
        /// Gets an instance given it's instance ID
        /// </summary>
        /// <param name="instanceId"></param>
        IEmulatorInstance GetInstance(string instanceId);
        /// <summary>
        /// Gets all instances that belong to a certain emulator
        /// </summary>
        /// <param name="bridge">The emulator bridge to get</param>
        IEnumerable<IEmulatorInstance> GetInstances(IEmulatorBridge bridge);
        /// <summary>
        /// Get instances of a certain state.
        /// </summary>
        /// <param name="state">The state of the instances</param>
        IEnumerable<IEmulatorInstance> GetInstances(EmulatorInstanceState state);
        /// <summary>
        /// Closes every single instance in the container, and purges the container.
        /// </summary>
        void CloseInstances();
        /// <summary>
        /// Removes hanging instances (ones that have shut down) from the container
        /// </summary>
        void PurgeHangingInstances();
        /// <summary>
        /// Disposes the container, shutting down all hanging instances.
        /// </summary>
        new void Dispose();
    }
}
