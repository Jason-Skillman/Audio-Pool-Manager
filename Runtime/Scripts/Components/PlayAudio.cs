namespace JasonSkillman.AudioPool.Components {
	using UnityEngine;
	using AudioConfiguration = AudioConfiguration;
	
	public class PlayAudio : MonoBehaviour {

		[SerializeField]
		private AudioClip audioClip = default;
		[SerializeField]
		private AudioConfiguration audioConfig = default;
		[SerializeField]
		private bool use3DPosition = default;

		[ContextMenu("Play")]
		public void Play() {
			Vector3 position = Vector3.zero;
			if(use3DPosition)
				position = transform.position;
			
			if(audioClip)
				AudioManager.Instance.PlayAudio(audioClip, position, audioConfig);
		}
	}
}
