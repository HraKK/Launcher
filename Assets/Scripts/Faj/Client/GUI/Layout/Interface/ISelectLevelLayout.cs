using Uddle.GUI.Layout.Interface;
using Uddle.Model.Preloader.Interface;
using Faj.Common.Model.Static.Level.Collection.Interface;
using System.Collections.Generic;

namespace Faj.Client.GUI.Layout.Interface
{
    interface ISelectLevelLayout : ILayout
    {
        ILevelCollection GetLevels();
        Dictionary<string, int> GetOpenedLevels();
    }
}
