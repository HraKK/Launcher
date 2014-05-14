using System.Collections.Generic;
using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace Faj.Common.Model.Player.Structure
{
    [ProtoContract]
    [Serializable]
	class PlayerStructure
	{
        [ProtoMember(1)]
        public Dictionary<string, int> resources = new Dictionary<string, int>();
        [ProtoMember(2)]
        public Dictionary<string, int> levels = new Dictionary<string, int>();
        [ProtoMember(3)]
        public Dictionary<string, int> upgrades = new Dictionary<string, int>();
        [ProtoMember(4)]
        public List<string> perks = new List<string>();
        [ProtoMember(5)]
        public Dictionary<string, QuestStructure> quests = new Dictionary<string, QuestStructure>();
        [ProtoMember(6)]
        public Dictionary<string, QuestStructure> achievements = new Dictionary<string, QuestStructure>();
	}
}
