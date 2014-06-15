using Faj.Common.Message.Content.Interface;

namespace Faj.Common.Message.Content
{
	class StringContent : IdContent, IStringContent
	{
        readonly string content;

        public StringContent(string id, string content) : base(id)
        {
            this.content = content;

        }

        public string GetContent()
        {
            return content;
        }
	}
}
