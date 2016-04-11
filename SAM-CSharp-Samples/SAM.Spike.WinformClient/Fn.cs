using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.WinformClient
{
	public static class Fn
	{
		// Container
		public static Func<StoreObj, DatasetObj, StoreObj> Container = (store, dataset) =>
		{
			// todo: 04/11/16 gph. Implement.
			var newStore = new StoreObj();
			return newStore;
		};

		// State
		public static Func<StoreObj, StateObj> State = (store) =>
		{
			var state = new StateObj();
			state.Counter = store.Counter;
			state.LaunchImminent = store.Counter == 9;
			state.HasLaunched = store.Launched;
			return state;
		};

		// NAP (Next Action Predicate)
		public static Func<StateObj, Action<Action<DatasetObj>>> NAP = (state) =>
		{
			return (present) =>
			{
				if (state.Counter == 10 && !state.HasLaunched)
					present(new DatasetObj { Launch = true });
			};
		};

		// Enhancer (Not sure the purpose of this yet. So minimal implementation, to change later.)
		//public static Action Enhancer = () => { };

		// CreateModel
		public static Func<
			Func<StoreObj, DatasetObj, StoreObj>, // Container
			Func<StoreObj, StateObj>, // State
			Func<StateObj, Action<Action<DatasetObj>>>, // NAP
			StoreObj, // StoreObj
			//Action, // Enhancer
			Model
		> CreateModel = (container, state, nap, initialStore) =>
		{
			// todo: 04/11/16 gph. Implement.
			return new Model();
		};

		// CreateDispatch
		public static Func<
			Action<DatasetObj>, // Model.Present
			DispatchObj // Dispatch
		> CreateDispatch = (present) =>
		{
			var dispatch = new DispatchObj();
			//dispatch.Model = model;
			dispatch.Request = (accion) =>
			{
				Console.WriteLine("Dispatch [{0}].", accion.Type);
				switch (accion.Type)
				{
					case "INC":
						//model.Present("{ increaseBy: 1 }");
						present(new DatasetObj { IncreaseBy = 1 });
						break;
				}
			};
			return dispatch;
		};

		// Dispatch
		public static Action<AccionObj> Dispatch { get; set; }

		// Moved to UI.
		//public static Action<StateObj> Render { get; set; }

		// App
		public static Func<
			Action<AccionObj>, // Dispatch
			StateObj, // State
			Action<StateObj>
		> App = (Dispatch, state) =>
		{
			// todo: 04/11/16 gph. Implement.
			return null;
		};
	}
}
