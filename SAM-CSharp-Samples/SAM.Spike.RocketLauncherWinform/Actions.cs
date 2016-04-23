using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{
	public static class Actions
	{
		public static Action<Data, Action<Data>> start { get; set; }
		public static Action<Data, Action<Data>> decrement { get; set; }
		public static Action<Data, Action<Data>> launch { get; set; }
		public static Action<Data, Action<Data>> abort { get; set; }

		static Actions()
		{
			start = (data, present) =>
			{
				data = data ?? new Data();
				data.started = true;
				present(data);
			};

			decrement = (data, present) =>
			{
				data = data ?? new Data();
				//data.counter = data.counter ?? Model.COUNTER_MAX; // Dflt if needed.
				Task.Delay(1000).Wait();
				//data.counter -= 1;
				data.decrementBy = 1;
				present(data);
			};

			launch = (data, present) =>
			{
				data = data ?? new Data();
				data.launched = true;
				present(data);
			};

			abort = (data, present) =>
			{
				data = data ?? new Data();
				data.aborted = true;
				present(data);
			};

		}
	}
}
