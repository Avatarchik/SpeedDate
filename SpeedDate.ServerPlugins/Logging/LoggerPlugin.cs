﻿using System;
using SpeedDate.Interfaces;
using SpeedDate.Interfaces.Network;
using SpeedDate.Interfaces.Plugins;
using SpeedDate.Logging;
using SpeedDate.Server;
using SpeedDate.ServerPlugins.Authentication;

namespace SpeedDate.ServerPlugins.Logging
{
    class LoggerPlugin : ServerPluginBase
    {
        private readonly ILogger _logger;

        public LoggerPlugin(IServer server, ILogger logger) : base(server)
        {
            _logger = logger;
            server.Started += ServerOnStarted;
            server.PeerConnected += Server_PeerConnected;
            server.PeerDisconnected += ServerOnPeerDisconnected;
        }

        private void ServerOnStarted(int port)
        {
            _logger.Info("Started on port: " + port);
        }

        public override void Loaded(IPluginProvider pluginProvider)
        {
            base.Loaded(pluginProvider);
            var auth = pluginProvider.Get<AuthPlugin>();
            auth.LoggedIn += AuthOnLoggedIn;
            auth.LoggedOut += AuthOnLoggedOut;
        }

        private void Server_PeerConnected(IPeer peer)
        {
            _logger.Info("New Client connected.");
        }

        private void ServerOnPeerDisconnected(IPeer peer)
        {
            _logger.Info("Client disconnected.");
        }

        private void AuthOnLoggedIn(IUserExtension account)
        {
            _logger.Info("Client logged in: " + account.Username);
        }

        private void AuthOnLoggedOut(IUserExtension account)
        {
            _logger.Info("Client logged out: " + account.Username);
        }
    }
}