using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WicGames.WICLibrary
{
	class Event
	{
		private List<Action> functions = new List<Action>();
		public void trigger()
		{
			for (int i = 0; i < functions.Count; i++)
			{
				functions.ElementAt(i).Invoke();
			}
		}
		public void connect(Action function)
		{
			functions.Add(function);
		}
		public static Event operator +(Event e, Action a)
		{
			e.connect(a);
			return e;
		}
	}
}
