using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{
	public class State
	{
		public View view { get; set; } = new View();

		public Action<Model> represent { get; set; }

		public State()
		{
			this.represent = (model) =>
			{
				string representation = "doh!";

				if (this.ready(model))
					representation = this.view.ready(model);
				if (this.counting(model))
					representation = this.view.counting(model);
				if (this.launched(model))
					representation = this.view.launched(model);
				if (this.aborted(model))
					representation = this.view.aborted(model);

				this.view.display(representation);
			};
			this.render = (model) =>
			{
				this.represent(model);
				this.nextAction(model);
			};
			this.nextAction = (model) =>
			{
				var actionToTake = "none";
				if (this.counting(model))
				{
					if (model.counter > 0)
					{
						actionToTake = "decrement";
						Action tick = () => 
							Actions.decrement(new Data { counter = model.counter }, model.present);
						Task.Factory.StartNew(tick);
					}

					if (model.counter == 0)
					{
						actionToTake = "launch";
						Actions.launch(null, model.present);
					}
				}
				Console.WriteLine("next action taken [{0}].", actionToTake);
			};
		}



		public Func<Model, bool> ready { get; set; } = (model) =>
		{
			bool status = ((model.counter == Model.COUNTER_MAX) && !model.started && !model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> counting { get; set; } = (model) =>
		{
			var status = ((model.counter <= Model.COUNTER_MAX) && (model.counter >= 0) && model.started && !model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> launched { get; set; } = (model) =>
		{
			var status = ((model.counter == 0) && model.started && model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> aborted { get; set; } = (model) =>
		{
			var status = ((model.counter <= Model.COUNTER_MAX) && (model.counter >= 0) && model.started && !model.launched && model.aborted);
			return status;
		};

		public Action<Model> render { get; set; }
		public Action<Model> nextAction { get; set; }

	}
}
