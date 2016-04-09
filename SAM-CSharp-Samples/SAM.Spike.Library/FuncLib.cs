using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.Library
{
	public static class FuncLib
	{
		public static Func<State, Action<Dataset>> NextActionPredicate { get; set; } = (state) =>
		{
			return (action) =>
			{
				if (state.Counter == 10 && !state.HasLaunched)
					action.Launch = true;
			};
		};
	}
}
