using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.WinformClient
{
	public class DispatchObj
	{
		//public Model Model { get; set; } // May not be appropriate here.
		public Action<AccionObj> Request { get; set; }
	}
}
