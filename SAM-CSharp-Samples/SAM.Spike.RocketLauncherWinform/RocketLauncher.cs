using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM.Spike.RocketLauncherWinform
{
	public partial class RocketLauncher : Form
	{
		//int _counter = 10;
		Model _model = new Model();

		public RocketLauncher()
		{
			InitializeComponent();
		}

		private void RocketLauncher_Load(object sender, EventArgs e)
		{
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			Actions.start(null, _model.present);
		}

		private void buttonDecrement_Click(object sender, EventArgs e)
		{
			//_counter -= 1;
			//Actions.decrement(new Data { counter = _counter }, _model.present);
			Actions.decrement(new Data { decrementBy = 1 }, _model.present);
		}

		private void buttonLaunch_Click(object sender, EventArgs e)
		{
			Actions.launch(null, _model.present);
		}

		private void buttonAbort_Click(object sender, EventArgs e)
		{
			Actions.abort(null, _model.present);
		}
	}
}
