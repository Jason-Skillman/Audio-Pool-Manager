using UnityEngine;

namespace Tevolve.Audio.Components {
	public class PlayAudioRandom : MonoBehaviour {
		
		[SerializeField]
		private AudioClip[] audioClips;
		[SerializeField]
		private AudioConfiguration audioConfig;
		[SerializeField]
		private bool use3DPosition;

		public void Play() {
			int randomIndex = Random.Range(0, audioClips.Length);
			AudioClip audioClip = audioClips[randomIndex];
			
			Vector3 position = Vector3.zero;
			if(use3DPosition)
				position = transform.position;
			
			if(audioClip)
				AudioManager.Instance.PlayAudio(audioClip, position, audioConfig);
		}
		
	}
}