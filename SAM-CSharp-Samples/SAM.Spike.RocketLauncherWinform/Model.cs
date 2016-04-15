using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{

	public class Model
	{
		public const int COUNTER_MAX = 10;

		public int counter { get; set; } = COUNTER_MAX;
		public bool started { get; set; } = false;
		public bool launched { get; set; } = false;
		public bool aborted { get; set; } = false;

		public State state = new State();

		public Action<Data> present { get; set; }

		public Model()
		{
			this.present = (data) =>
			{
				if (this.state.counting(this))
				{
					if (this.counter ==0)
					{
						this.launched = data.launched ?? false;
					}
					else
					{
						this.aborted = data.aborted ?? false;
						if (data.counter.HasValue)
							this.counter = data.counter.Value;
					}
				}
				else if (this.state.ready(this))
				{
					this.started = data.started ?? false;
				}

				this.state.render(this);
			};

		}

	}
}
