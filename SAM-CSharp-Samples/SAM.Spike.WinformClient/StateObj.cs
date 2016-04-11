using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.WinformClient
{
	public class StateObj
	{
		public int Counter { get; set; }
		public bool LaunchImminent { get; set; }
		public bool HasLaunched { get; set; }

		public override string ToString()
		{
			var s = string.Format("Counter [{0}], LaunchImminent [{1}], HasLaunched [{2}]",
				this.Counter, this.LaunchImminent, this.HasLaunched);
			return s;
		}
	}
}
