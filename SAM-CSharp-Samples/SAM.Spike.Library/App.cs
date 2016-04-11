using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.Library
{
	public class App
	{
		public void Fred()
		{
			Func<Dispatch, State, string> app = (dispatch, state) =>
			{
				Action inc = () => dispatch.Request(new Accion { Type = "INC" });

				return "HtmlTextDisplayingStateAndTriggeringIncOnClick";
			};
		}
	}
}
