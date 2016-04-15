using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{
	public static class Actions
	{
		public static Func<Data, Action<Data>, bool> start { get; set; }
		public static Action<Data, Action<Data>> decrement { get; set; }
		public static Action<Data, Action<Data>> launch { get; set; }
		public static Func<Data, Action<Data>, bool> abort { get; set; }

		static Actions()
		{
			start = (data, present) =>
			{
				if (data == null) data = new Data();
				data.started = true;
				present(data);
				return false;
			};
			decrement = (data, present) =>
			{
				if (data == null) data = new Data();
				data.counter = data.counter ?? Model.COUNTER_MAX;
				// todo: 04/15/16 gph. Setup a timer task do decrement once per second.
				data.counter -= 1; // just do once for now.
			};
			launch = (data, present) =>
			{
				if (data == null) data = new Data();
				data.launched = true;
				present(data);
			};
			abort = (data, present) =>
			{
				if (data == null) data = new Data();
				data.aborted = true;
				present(data);
				return false;
			};
		}
	}
}
