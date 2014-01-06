using Uddle.Message.Content.Interface;

namespace Faj.Common.Message.Content.Interface
{
    interface IIdContent : IContent
    {
        string GetId();
    }
}
