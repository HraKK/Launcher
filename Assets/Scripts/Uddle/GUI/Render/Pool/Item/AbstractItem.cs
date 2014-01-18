using Uddle.GUI.Render.Pool.Item.Interface;
using UnityEngine;

namespace Uddle.GUI.Render.Pool.Item
{
	class AbstractItem : IPoolItem
	{
        protected readonly GameObject gameObject;
        public AbstractItem(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }
	}
}
