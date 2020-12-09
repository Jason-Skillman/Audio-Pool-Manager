using Factory;
using UnityEngine;

namespace Audio {
	//[CreateAssetMenu(fileName = "New SoundEmitter Factory", menuName = "Factory/SoundEmitter Factory")]
	public class AudioEmitterFactory : FactorySO<AudioEmitter> {
		public AudioEmitter prefab;

		public override AudioEmitter Create() {
			return Instantiate(prefab);
		}
	}
}