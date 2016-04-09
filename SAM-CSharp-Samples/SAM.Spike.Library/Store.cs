using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.Library
{
	public class Store
	{
		public int Counter { get; set; }
		public bool Launched { get; set; }
	}

	////////////////////////////////////////////////////////////
	public interface IStoreFactory
	{
		Store NewFrom();
	}

	public class StoreFactory : IStoreFactory
	{
		public Store NewFrom()
		{
			var store = new Store();
			store.Counter = 0;
			store.Launched = false;
			return store;
		}
	}

}
