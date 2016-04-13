using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Spike.WinformClient
{
	public class Model
	{
		public CounterForm View { get; set; } // Hack for now.
		public Func<StoreObj, DatasetObj, StoreObj> Container { get; set; }
		public Func<StoreObj, StateObj> State { get; set; }
		public Func<StateObj, Action<Action<DatasetObj>>> NAP { get; set; }
		private StoreObj _store;
		public StoreObj Store
		{
			get { return _store; }
			set
			{
				_store = value;
				var state = this.State(_store);
				this.NAP.Invoke(state).Invoke(ds => ds.Launch = true);
				View.Render.Invoke(state, View); // Hack for now.
			}
		}

		//public Model() { }
		public Model(
			Func<StoreObj, DatasetObj, StoreObj> container,
			Func<StoreObj, StateObj> state,
			Func<StateObj, Action<Action<DatasetObj>>> nap,
			StoreObj initialStore,
		//Action (command?), // Enhancer
			CounterForm form
		)
		{
			this.View = form; // Hack for now. Must be assigned before Store.
			this.Container = container;
			this.State = state;
			this.NAP = nap;
			this.Store = initialStore;
		}

		//public Action<StateObj> Subscribe { get; set; } =
		//(state) =>
		//{
		//	MessageBox.Show(string.Format("View received new state [{0}].", state.ToString()));
		//	// render App (state, dispatch, dom root)
		//};

		public Action<DatasetObj> Present { get; set; } =
		(dataset) =>
		{
			// Don't accept increments greater than 1.
			if (dataset.IncreaseBy > 1)
			{
				var txt = string.Format("Presented IncreaseBy value [{0}] must be < 1.", dataset.IncreaseBy);
				throw new ApplicationException(txt);
			}
			else
			{
				var newStore = CounterForm._staticModel.Container.Invoke(CounterForm._staticModel.Store, dataset);
				CounterForm._staticModel.Store = newStore; // Immutable store.
			}
		};
	}
}
