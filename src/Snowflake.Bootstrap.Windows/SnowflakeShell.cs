﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using Snowflake.Configuration;
using Snowflake.Emulator;

using Snowflake.Input.Controller.Mapped;
using Snowflake.Input.Device;
using Snowflake.Platform;
using Snowflake.Records.File;
using Snowflake.Records.Game;
using Snowflake.Scraper;
using Snowflake.Services;
using Snowflake.Utility;
using Snowflake.Plugin.Emulators.RetroArch.Adapters.Bsnes;
using Snowflake.Romfile;
using Snowflake.Loader;
using Snowflake.Services.AssemblyLoader;

namespace Snowflake.Shell.Windows
{
    internal class SnowflakeShell
    {
        private IServiceContainer loadedCore;
        private readonly string appDataDirectory = PathUtility.GetSnowflakeDataPath();
        internal SnowflakeShell()
        {
            this.StartCore();
        }
       
        public void StartCore()
        {

            this.loadedCore = new ServiceContainer(this.appDataDirectory);
            var loader = this.loadedCore.Get<IModuleEnumerator>();
            var composer = new AssemblyComposer(this.loadedCore, loader);
            composer.Compose();
            //this.loadedCore.Get<IEmulatorAssembliesManager>()?.LoadEmulatorAssemblies();
            //this.loadedCore.Get<IPluginManager>()?.Initialize();
           /* this.loadedCore.Get<IServerManager>().RegisterServer("ThemeServer", new ThemeServer(Path.Combine(this.loadedCore.AppDataDirectory, "themes")));
            foreach (string serverName in this.loadedCore.Get<IServerManager>().RegisteredServers)
            {
                this.loadedCore.Get<IServerManager>()?.StartServer(serverName);
                var serverStartEvent = new ServerStartEventArgs(this.loadedCore, serverName);
                SnowflakeEventManager.EventSource.RaiseEvent(serverStartEvent); //todo Move event registration to SnowflakeEVentManager
            }*/
            /*var im = this.loadedCore.Get<IPluginManager>().Get<IInputEnumerator>()["InputEnumerator-Keyboard"];
            var ep = new EmulatedPort(1, im.ControllerLayout,
                im.GetConnectedDevices().First(), MappedControllerElementCollection.GetDefaultMappings(im.ControllerLayout, this.loadedCore.Get<IStoneProvider>().Controllers["NES_CONTROLLER"]));
            var gr = new GameRecord(this.loadedCore.Get<IStoneProvider>().Platforms["NINTENDO_SNES"], "test",
                @"E:\Super Mario World (USA).sfc", "application/x-romfile-snes-sfc");
            var raadapter = this.loadedCore.Get<IPluginManager>().Get<BsnesRetroArchAdapter>().First().Value;
            
            var lmfao = raadapter.Instantiate(gr, gr.Files[0], 0, new List<IEmulatedPort> { ep});
            lmfao.Create();
            lmfao.Start();*/
        }

        public void StartShell() {
            var electronUi = this.loadedCore.Get<IUserInterface>();
            //electronUi.StartUserInterface();
        }

        public void RestartCore()
        {
            this.ShutdownCore();
            this.StartCore();
        }

        public void ShutdownCore()
        {
            this.loadedCore.Dispose();
            GC.WaitForPendingFinalizers();
        }  
    }
}
