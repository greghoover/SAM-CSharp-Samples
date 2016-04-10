using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.Library
{
	public class State
	{
		public int Counter { get; set; }
		public bool LaunchImminent { get; set; }
		public bool HasLaunched { get; set; }
		public Func<State, Action<Dataset>> NextAction { get; set; } = NextActionPredicate.CounterNap;

		internal State() { }

		public static State NewFrom(Store store)
		{
			var state = new StateFactory().NewFrom(store);
			return state;
		}
	}

	////////////////////////////////////////////////////////////
	public interface IStateFactory
	{
		State NewFrom(Store store);
	}

	public class StateFactory : IStateFactory
	{
		public State NewFrom(Store store)
		{
			var state = new State();
			state.Counter = store.Counter;
			state.LaunchImminent = store.Counter == 9;
			state.HasLaunched = store.Launched;
			return state;
		}
	}
}
