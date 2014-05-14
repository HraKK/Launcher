using UnityEngine;
using System.Collections;
using Uddle.Service;
using Uddle.Service.Interface;
using Uddle.Config;
using Faj.Client.Bootstrap;
using Faj.Client.Model.Game;
using Uddle.Bootstrap.Interface;
using Uddle.Model.Game.Interface;
using Uddle.GUI.Render.Service.Interface;

namespace Faj.Client
{
    public class Main : MonoBehaviour
    {
        private IGUIObserverService GUIObserverService;
        IGameModel gameModel;

        void Awake()
        {            
            var bootstraper = new FajBootstraper(new ApplicationConfig());
            gameModel = new GameModel(bootstraper);
            var coroutineService = ServiceProvider.Instance.GetService<ICoroutineService>();
            coroutineService.OnCouroutine += new CoroutineProxy(OnCoroutine);
            gameModel.OnInitializeCompleteEvent += new System.Action(OnInitializeComplete);
            gameModel.Initialize("testPlayer13");
            
            GUIObserverService = ServiceProvider.Instance.GetService<IGUIObserverService>();
        }

        private void OnInitializeComplete()
        {
            UnityEngine.Debug.Log("initial compl");
            
            gameModel.Run();
        }

        private void Update()
        {

        }

        private void OnGUI()
        {            
            GUIObserverService.Notify();
        }

        private void OnCoroutine(CoroutineMethod coroutine)
        {
            StartCoroutine(coroutine());
        }
    }
}
