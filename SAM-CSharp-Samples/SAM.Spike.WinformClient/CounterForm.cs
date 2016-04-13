using System;
using System.Windows.Forms;

namespace SAM.Spike.WinformClient
{
	public partial class CounterForm : Form
	{
		public Fn _fn = new Fn();
		public Model _instanceModel { get; set; }
		public static Model _staticModel { get; set; }
		public Action<CommandObj> _dispatch { get; set; }
		//private DispatchObj _dispatch { get; set; }
		//private StateObj _state { get; set; }

		public CounterForm()
		{
			InitializeComponent();
		}

		private void CounterForm_Load(object sender, EventArgs e)
		{
			var initialStore = new StoreObj { Counter = 8 };
			//_instanceModel = _fn.CreateModel(_fn.Container, _fn.State, _fn.NAP, initialStore, this);
			CounterForm._staticModel = _fn.CreateModel(_fn.Container, _fn.State, _fn.NAP, initialStore, this);
			_dispatch = _fn.CreateDispatch(CounterForm._staticModel.Present);
		}

		public Action<StateObj, CounterForm> Render = (state, form) =>
		{
			Console.WriteLine(string.Format("View received new state [{0}].", state.ToString()));

			// render App (state, dispatch, dom root)
			form.labelCounter.Text = string.Format("Counter: {0}", state.Counter);
			if (state.LaunchImminent)
				form.labelCounter.Text += " (watch out! will launch soon!)";

			form.labelStatus.Text = state.HasLaunched ? "LAUNCHED" : "";

			if (state.Counter != 10)
				form.buttonSubmitAction.Text = "INC";
			else
				form.buttonSubmitAction.Text = "LAUNCH";
			//EventHandler increment = (sender, e) =>
			//{
			//	//_fn.Dispatch(new CommandObj { Type = "INC" });
			//};
			//form.buttonSubmitAction.Click += increment;
		};

		private void buttonSubmitAction_Click(object sender, EventArgs e)
		{
			if (buttonSubmitAction.Text == "LAUNCH")
				_dispatch(new CommandObj { Type = "LAUNCH" });
			else
				_dispatch(new CommandObj { Type = "INC" });
			
		}
	}
}
