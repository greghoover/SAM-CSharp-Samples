using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.RocketLauncherWinform
{
	public class View
	{
		public Func<Model, string> init { get; set; } = (model) =>
		{
			return "view.init.ready";
		};
		public Action<string> display { get; set; } = (representation) =>
		{
			Console.WriteLine("display [{0}].", representation);
		};

		public Func<Model, string> ready { get; set; } = (model) =>
		{
			return "view.ready";
		};
		public Func<Model, string> counting { get; set; } = (model) =>
		{
			return string.Format("view.counting [{0}]", model.counter);
		};
		public Func<Model, string> aborted { get; set; } = (model) =>
		{
			return "view.aborted";
		};
		public Func<Model, string> launched { get; set; } = (model) =>
		{
			return "view.launched";
		};
	}
}
