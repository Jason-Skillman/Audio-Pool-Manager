namespace AudioPool {
	using Factory;
	using AudioPool.Pool;
	using UnityEngine;

	//[CreateAssetMenu(fileName = "New SoundEmitter Pool", menuName = "Pool/SoundEmitter Pool")]
	public class AudioEmitterPool : ComponentPool<AudioEmitter> {
		
		[SerializeField]
		private AudioEmitterFactory factory;
		[SerializeField]
		private int initialPoolSize;

		public override IFactory<AudioEmitter> Factory {
			get { return factory; }
			set { factory = value as AudioEmitterFactory; }
		}

		public override int InitialPoolSize {
			get { return initialPoolSize; }
			set { initialPoolSize = value; }
		}
	}
}
