﻿using Uddle.Service.Interface;
using Uddle.Static.Collection.Interface;

namespace Uddle.Static.Service.Interface
{
	interface IStaticContainerService : IService
	{
        IStaticCollection GetStaticCollection(string name);
        TStaticCollection GetStaticCollection<TStaticCollection>(string name) where TStaticCollection : IStaticCollection;
	}
}
