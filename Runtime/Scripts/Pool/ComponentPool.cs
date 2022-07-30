namespace AudioPool.Pool {
	using UnityEngine;
	
	public abstract class ComponentPool<T> : PoolSO<T> where T : Component {
		
		public abstract int InitialPoolSize { get; set; }
		
		private GameObject poolRootObject;
		
		public Transform Parent { get; set; }

		private void InitializePool() {
			poolRootObject = new GameObject(name);
			poolRootObject.transform.SetParent(Parent);
			//DontDestroyOnLoad(poolRootObject);
			for(int i = 0; i < InitialPoolSize; i++) {
				available.Push(Create());
			}
		}

		public override T Request() {
			if(poolRootObject == null)
				InitializePool();
			
			T member = base.Request();
			member.gameObject.SetActive(true);
			return member;
		}

		public override void Return(T member) {
			if(poolRootObject == null)
				InitializePool();
			
			member.transform.SetParent(poolRootObject.transform);
			member.gameObject.SetActive(false);
			base.Return(member);
		}

		protected override T Create() {
			T newMember = base.Create();
			newMember.transform.SetParent(poolRootObject.transform);
			newMember.gameObject.SetActive(false);
			return newMember;
		}

		public override void OnDisable() {
			base.OnDisable();
#if UNITY_EDITOR
			DestroyImmediate(poolRootObject);
#else
			Destroy(poolRootObject);
#endif
		}
	}
}
