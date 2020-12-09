using UnityEngine;

namespace Tevolve.Factory {
	public abstract class FactorySO<T> : ScriptableObject, IFactory<T> {
		public abstract T Create();
	}
}