using System;
using Uddle.Model.Downloader.Interface;

namespace Uddle.Model.Game.Interface
{
	interface IGameModel
	{
        event Action OnInitializeCompleteEvent;
        void Initialize(string playerId);
        void Run();
	}
}
