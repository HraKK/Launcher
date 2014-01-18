using Uddle.GUI.Layout.Interface;
using Uddle.Model.Preloader.Interface;

namespace Faj.Client.GUI.Layout.Interface
{
	interface IPreloaderLayout : ILayout
	{
        IPreloaderModel GetPreloaderModel();
	}
}
