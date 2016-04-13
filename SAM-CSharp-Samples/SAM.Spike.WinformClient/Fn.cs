using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.WinformClient
{
	public class Fn
	{
		/// <summary>
		/// Container.
		/// Inputs: store (current), dataset (presented).
		/// Output: store (new).
		/// </summary>
		public Func<StoreObj, DatasetObj, StoreObj> Container = (store, dataset) =>
		{
			var newStore = new StoreObj();
			newStore.Counter = store.Counter + dataset.IncreaseBy;
			if (dataset.Launch)
				newStore.Launched = true;
			return newStore;
		};

		/// <summary>
		/// State. 
		/// Input: store (from model).
		/// Output: state (to view and nap).
		/// </summary>
		public Func<StoreObj, StateObj> State = (store) =>
		{
			var state = new StateObj();
			state.Counter = store.Counter;
			state.LaunchImminent = store.Counter == 9;
			state.HasLaunched = store.Launched;
			return state;
		};

		/// <summary>
		/// NAP (Next Action Predicate).
		/// Input: State.
		/// Output: NAP, i.e. a function which accepts a function (present) and may or may not call it.
		/// </summary>
		public Func<StateObj, Action<Action<DatasetObj>>> NAP = (state) =>
		{
			return (present) =>
			{
				if (state.Counter > 9)
					if (!state.HasLaunched)
						present(new DatasetObj { Launch = true });
			};
		};

		/// <summary>
		/// CreateDispatch.
		/// Input: Model.Present.
		/// Output: Dispatch (a function which accepts an action and presents values to the model).
		/// </summary>
		public Func<
			Action<DatasetObj>, // Model.Present
			Action<CommandObj> // Command
		> CreateDispatch = (present) => (command) =>
		{
			Console.WriteLine("Dispatch [{0}].", command.Type);
			switch (command.Type)
			{
				case "INC":
					present(new DatasetObj { IncreaseBy = 1 });
					break;
				case "LAUNCH":
					present(new DatasetObj { IncreaseBy = 1, Launch = true });
					break;
			}
		};

		// Enhancer (Not sure the purpose of this yet. So minimal implementation, to change later.)
		//public static Action Enhancer = () => { };

		// CreateModel
		public Func<
			Func<StoreObj, DatasetObj, StoreObj>, // Container
			Func<StoreObj, StateObj>, // State
			Func<StateObj, Action<Action<DatasetObj>>>, // NAP
			StoreObj, // StoreObj
			//Action, // Enhancer
			CounterForm, // Hack for now.
			Model
		> CreateModel = (container, state, nap, initialStore, form) =>
		{
			Model model = new Model(container, state, nap, initialStore, form);
			return model;
		};

		// Moved to UI.
		//public static Action<StateObj> Render { get; set; }

		// App
		//public static Func<
		//	Action<CommandObj>, // Dispatch
		//	StateObj, // State
		//	Action<StateObj>
		//> App = (dispatch, state) =>
		//{
		//	// todo: 04/11/16 gph. Implement.
		//	return null;
		//};
	}
}
