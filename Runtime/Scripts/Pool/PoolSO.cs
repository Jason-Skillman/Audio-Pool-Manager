namespace JasonSkillman.AudioPool.Pool {
	using System.Collections.Generic;
	using Factory;
	using UnityEngine;
	
	/// <summary>
	/// A generic pool that generates members of type T on-demand via a factory.
	/// </summary>
	/// <typeparam name="T">Specifies the type of elements to pool.</typeparam>
	public abstract class PoolSO<T> : ScriptableObject, IPool<T> {

		protected readonly Stack<T> available = new Stack<T>();
		
		public abstract IFactory<T> Factory { get; set; }
		
		public virtual void OnDisable() => available.Clear();

		protected virtual T Create() => Factory.Create();

		public virtual T Request() => available.Count > 0 ? available.Pop() : Create();

		public virtual void Return(T member) => available.Push(member);
	}
}
