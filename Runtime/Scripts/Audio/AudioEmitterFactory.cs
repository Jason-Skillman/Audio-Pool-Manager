using Tevolve.Factory;
using UnityEngine;

namespace Tevolve.Audio {
	//[CreateAssetMenu(fileName = "New SoundEmitter Factory", menuName = "Factory/SoundEmitter Factory")]
	public class AudioEmitterFactory : FactorySO<AudioEmitter> {
		public AudioEmitter prefab;

		public override AudioEmitter Create() {
			return Instantiate(prefab);
		}
	}
}