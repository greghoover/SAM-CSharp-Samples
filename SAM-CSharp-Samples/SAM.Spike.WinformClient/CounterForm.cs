using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Spike.WinformClient
{
	public partial class CounterForm : Form
	{
		private Model _model { get; set; }
		private DispatchObj _dispatch { get; set; }
		//private StateObj _state { get; set; }
		
		public CounterForm()
		{
			InitializeComponent();
		}

		private void SpikeForm_Load(object sender, EventArgs e)
		{
			var initialStore = new StoreObj { Counter = 5 };
			_model = Fn.CreateModel(Fn.Container, Fn.State, Fn.NAP, initialStore);
			_dispatch = Fn.CreateDispatch(_model.Present);

			//_model.Subscribe
		}

		private StateObj State { get; set; }

		public Action<StateObj, CounterForm> Render = (state, form) =>
		{
			MessageBox.Show(string.Format("View received new state [{0}].", state.ToString()));

			// render App (state, dispatch, dom root)
			form.labelCounter.Text = string.Format("Counter: {0}", state.Counter);
			if (state.LaunchImminent)
				form.labelCounter.Text += " (watch out! will launch soon!)";

			form.labelStatus.Text = state.HasLaunched ? "LAUNCHED" : "";

			form.buttonSubmitAction.Text = "INC";
			EventHandler increment = (sender, e) =>
			{
				Fn.Dispatch(new AccionObj { Type = "INC" });
			};
			form.buttonSubmitAction.Click += increment;
		};

	}
}
