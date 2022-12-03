namespace JasonSkillman.AudioPool.Factory {
	using UnityEngine;
	
	public abstract class FactorySO<T> : ScriptableObject, IFactory<T> {
		public abstract T Create();
	}
}