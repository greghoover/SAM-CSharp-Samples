using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{
	public class State
	{
		public View view { get; set; } = new View();

		public Action<Model> representation { get; set; }

		public State()
		{
			this.representation = (model) =>
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
				Console.WriteLine("Render [{0}].", model.counter);
				this.representation(model);
				this.nextAction(model);
			};
			this.nextAction = (model) =>
			{
				Console.WriteLine("NextAction [{0}].", model.counter);
				if (this.counting(model))
				{
					if (model.counter > 0)
					{
						Actions.decrement(new Data { counter = model.counter }, model.present);
					}

					if (model.counter == 0)
					{
						Actions.launch(null, model.present);
					}
				}
			};
		}



		public Func<Model, bool> ready { get; set; } = (model) =>
		{
			Console.WriteLine("Ready [{0}].", model.counter);
			bool status = ((model.counter == Model.COUNTER_MAX) && !model.started && !model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> counting { get; set; } = (model) =>
		{
			Console.WriteLine("Counting [{0}].", model.counter);
			var status = ((model.counter <= Model.COUNTER_MAX) && (model.counter >= 0) && model.started && !model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> launched { get; set; } = (model) =>
		{
			Console.WriteLine("Launched [{0}].", model.counter);
			var status = ((model.counter == 0) && model.started && model.launched && !model.aborted);
			return status;
		};
		public Func<Model, bool> aborted { get; set; } = (model) =>
		{
			Console.WriteLine("Aborted [{0}].", model.counter);
			var status = ((model.counter <= Model.COUNTER_MAX) && (model.counter >= 0) && model.started && !model.launched && model.aborted);
			return status;
		};

		public Action<Model> render { get; set; }
		public Action<Model> nextAction { get; set; }

	}
}
