namespace AudioPool {
	using Factory;
	
	public class AudioEmitterFactory : FactorySO<AudioEmitter> {
		
		public AudioEmitter prefab;

		public override AudioEmitter Create() => Instantiate(prefab);
	}
}
