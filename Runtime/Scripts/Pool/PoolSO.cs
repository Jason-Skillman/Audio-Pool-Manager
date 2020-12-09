using System.Collections.Generic;
using UnityEngine;
using Tevolve.Factory;

namespace Tevolve.Pool {
	/// <summary>
	/// A generic pool that generates members of type T on-demand via a factory.
	/// </summary>
	/// <typeparam name="T">Specifies the type of elements to pool.</typeparam>
	public abstract class PoolSO<T> : ScriptableObject, IPool<T> {

		protected readonly Stack<T> available = new Stack<T>();
		public abstract IFactory<T> Factory { get; set; }

		protected virtual T Create() {
			return Factory.Create();
		}

		public virtual T Request() {
			return available.Count > 0 ? available.Pop() : Create();
		}

		/*public virtual IEnumerable<T> Request(int num = 1) {
			List<T> members = new List<T>(num);
			for(int i = 0; i < num; i++) {
				members.Add(Request());
			}

			return members;
		}*/

		public virtual void Return(T member) {
			available.Push(member);
		}

		/*public virtual void Return(IEnumerable<T> members) {
			foreach(T member in members) {
				Return(member);
			}
		}*/

		public virtual void OnDisable() {
			available.Clear();
		}
	}

}