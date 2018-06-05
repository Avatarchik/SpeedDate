﻿namespace SpeedDate.ServerPlugins.Lobbies
{
    /// <summary>
    /// Represents the current state of the lobby
    /// </summary>
    public enum LobbyState
    {
        FailedToStart = -1,

        // Before game 
        Preparations = 0,

        StartingGameServer,

        // During the game
        GameInProgress,

        // After the game
        GameOver
    }
}