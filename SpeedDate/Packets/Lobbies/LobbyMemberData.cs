﻿using System.Collections.Generic;
using SpeedDate.Network;
using SpeedDate.Network.Utils.IO;

namespace SpeedDate.Packets.Lobbies
{
    /// <summary>
    /// Information about a member of the lobby
    /// </summary>
    public class LobbyMemberData : SerializablePacket
    {
        public string Username;
        public Dictionary<string, string> Properties;
        public bool IsReady;
        public string Team;

        public override void ToBinaryWriter(EndianBinaryWriter writer)
        {
            writer.WriteDictionary(Properties);
            writer.Write(IsReady);
            writer.Write(Username);
            writer.Write(Team);
        }

        public override void FromBinaryReader(EndianBinaryReader reader)
        {
            Properties = reader.ReadDictionary();
            IsReady = reader.ReadBoolean();
            Username = reader.ReadString();
            Team = reader.ReadString();
        }
    }
}