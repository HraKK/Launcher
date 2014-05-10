using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faj.Common.Model.Player.Structure
{
    enum Status
    {
        CREATED,
        STARTED,
        FINISHED
    }

	class QuestStructure
	{
        public readonly string templateId;
        public Status status = Status.CREATED;
        public int value = 0;

        public QuestStructure(string templateId)
        {
            this.templateId = templateId;
        }
	}
}
