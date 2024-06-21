namespace JasonSkillman.AudioPool.Components {
	using UnityEngine;
	using AudioConfiguration = AudioConfiguration;
	using Random = UnityEngine.Random;

	public class PlayAudioRandom : MonoBehaviour {
		
		[SerializeField]
		private AudioClip[] audioClips = default;
		[SerializeField]
		private AudioConfiguration audioConfig = default;
		
		[Space]
		[SerializeField]
		private float volume = 1.0f;
		
		[Header("Random Pitch")]
		[SerializeField]
		private Vector2 pitchRange = new(0.9f, 1.2f);

		[Header("Spatial Audio")]
		[SerializeField]
		private bool use3DPosition = true;
		[SerializeField]
		private AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;
		[SerializeField]
		private float minDistance = 1.0f;
		[SerializeField]
		private float maxDistance = 500.0f;

		[ContextMenu("Play")]
		public void Play() {
			if(audioClips.Length <= 0) return;
			
			int randomIndex = Random.Range(0, audioClips.Length);
			AudioClip audioClip = audioClips[randomIndex];
			
			Vector3 position = use3DPosition ? transform.position : Vector3.zero;
			
			//Copy data and override values
			AudioConfigurationData configurationData = audioConfig.AudioConfigurationData;

			configurationData.volume = Mathf.Max(Mathf.Min(volume, 1.0f), 0.0f);
			
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
