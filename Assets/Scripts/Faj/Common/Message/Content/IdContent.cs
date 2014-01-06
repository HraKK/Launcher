using Faj.Common.Message.Content.Interface;

namespace Faj.Common.Message.Content
{
    class IdContent : IIdContent
    {
        readonly string id;

        public IdContent(string id)
        {
            this.id = id;
        }

        public string GetId()
        {
            return id;
        }
    }
}
