namespace AudioPool {
	using Factory;
	using AudioPool.Pooling;
	using UnityEngine;

	public class AudioEmitterPool : ComponentPool<AudioEmitter> {
		
		[SerializeField]
		private AudioEmitterFactory factory;
		[SerializeField]
		private int initialPoolSize;

		public override IFactory<AudioEmitter> Factory {
			get => factory;
			set => factory = value as AudioEmitterFactory;
		}

		public override int InitialPoolSize {
			get => initialPoolSize;
			set => initialPoolSize = value;
		}
	}
}
