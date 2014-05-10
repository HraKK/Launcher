using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Faj.Common.Model.Player.Structure
{
    enum Status
    {
        CREATED,
        STARTED,
        FINISHED
    }

    [ProtoContract]
    [Serializable]
	class QuestStructure
	{
        [ProtoMember(1)]
        public string templateId;
        [ProtoMember(2)]
        public Status status = Status.CREATED;
        [ProtoMember(3)]
        public int value = 0;

        public QuestStructure()
        {
        }

        public QuestStructure(string templateId)
        {
            this.templateId = templateId;
        }
	}
}
