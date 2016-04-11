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
		public Action<StateObj> Subscribe = (state) =>
		{
			MessageBox.Show("View received new state.", state.ToString());
			// render App (state, dispatch, dom root)
		};

		public Action<DatasetObj> Present = (dataset) =>
		{
			// todo: 04/11/16 gph. Implement.
		};
	}
}
