using Uddle.Model.Preloader;
using Faj.Client.Model.Preloader.View;

namespace Faj.Client.Model.Preloader
{
    class PreloaderModel : AbstractPreloaderModel
    {
        protected override void InitializeView()
        {
            view = new PreloaderView(this);
        }
    }
}
