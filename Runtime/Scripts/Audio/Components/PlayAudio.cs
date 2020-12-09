using UnityEngine;

namespace Tevolve.Audio.Components {
	public class PlayAudio : MonoBehaviour {

		[SerializeField]
		private AudioClip audioClip;
		[SerializeField]
		private AudioConfiguration audioConfig;
		[SerializeField]
		private bool use3DPosition;

		public void Play() {
			Vector3 position = Vector3.zero;
			if(use3DPosition)
				position = transform.position;
			
			if(audioClip)
				AudioManager.Instance.PlayAudio(audioClip, position, audioConfig);
		}

	}
}