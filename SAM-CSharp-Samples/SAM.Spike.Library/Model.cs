using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Spike.Library
{
	public class Model
	{
		/**
		 * Creates a SAM Model that holds the Store tree.
		 * The only way to change the data in the Store is to call `present()` on it.
		 * @param {Function} Business Logic Container
		 * @param {Function} State to translate Store to State
		 * @param {Function} [nap] Function that implements the next-action-predicate
		 * @param {any} [initialStore]
		 * @param {Function} enhancer
		 * @returns {Model} A SAM model that lets you read the State, present data and
		 * subscribe to changes.
		 */

		//public void Subscribe() { }
		public void Present(string jsonString)
		{
			Console.WriteLine("Model presented with update reqeust [{0}].", jsonString);
		}


	////////////////////////////////////////////////////////////
	public interface IModelFactory
	{
		Model NewFrom(Action container, Action state, Action nap, Action initialStore, Action enhancer);
	}

	public class ModelFactory : IModelFactory
	{
			public Model NewFrom(Action container, Action state, Action nap, Action initialStore, Action enhancer)
			{
				var model = new Model();
				return model;
			}
			//export default function createModel(container, state, nap = nop, initialStore, enhancer)
			//{
			//	if (typeof enhancer !== 'undefined')
			//	{
			//		// TODO: Apply enhancer
			//		return enhancer(createModel)(container, state, nap, initialStore)
			//    }
			//}
		}
	}


}
