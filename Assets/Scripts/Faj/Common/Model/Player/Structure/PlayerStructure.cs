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
        public int level;
        [ProtoMember(2)]
        public Dictionary<string, int> resources = new Dictionary<string, int>();
	}
}
