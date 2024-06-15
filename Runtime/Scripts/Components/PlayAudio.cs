namespace JasonSkillman.AudioPool.Components {
	using UnityEngine;
	using AudioConfiguration = AudioConfiguration;
	
	public class PlayAudio : MonoBehaviour {

		[SerializeField]
		private AudioClip audioClip = default;
		[SerializeField]
		private AudioConfiguration audioConfig = default;
		
		[Header("Spatial Audio")]
		[SerializeField]
		private bool use3DPosition = true;
		[SerializeField]
		private AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;
		[SerializeField]
		private float minDistance = 1.0f;
		[SerializeField]
		private float maxDistance = 500.0f;
		
		[Header("Random Pitch")]
		[SerializeField]
		private Vector2 pitchRange = new(0.9f, 1.2f);

		[ContextMenu("Play")]
		public void Play() {
			if(!audioClip) return;
			
			Vector3 position = use3DPosition ? transform.position : Vector3.zero;
			
			//Copy data and randomize pitch
			AudioConfigurationData configurationData = audioConfig.AudioConfigurationData;
			configurationData.RandomPitch(pitchRange);
			
			if(use3DPosition && configurationData.spatialBlend <= 0.0f)
				configurationData.spatialBlend = 1.0f;
			configurationData.rolloffMode = rolloffMode;
			configurationData.minDistance = minDistance;
			configurationData.maxDistance = maxDistance;

			AudioManager.Instance.PlayAudio(audioClip, position, configurationData);
		}
	}
}
