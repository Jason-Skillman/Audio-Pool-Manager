namespace JasonSkillman.AudioPool.Components {
	using UnityEngine;
	using AudioConfiguration = AudioConfiguration;
	using Random = UnityEngine.Random;

	public class PlayAudioRandom : MonoBehaviour {
		
		[SerializeField]
		private AudioClip[] audioClips = default;
		[SerializeField]
		private AudioConfiguration audioConfig = default;
		[SerializeField]
		private bool playOnStart = true;
		[SerializeField]
		private bool continuousPlay;
		[SerializeField]
		private float delay, interval = 1;
		
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

		private bool isContinuousPlayRunning;

		private void Start()
		{
			if(playOnStart)
				Play();
		}

		[ContextMenu("Play")]
		public void Play() {
			if(continuousPlay)
				StartContinuousPlay();
			else
				PlayAudio();
		}
		
		[ContextMenu("StartContinuousPlay")]
		public void StartContinuousPlay()
		{
			if(isContinuousPlayRunning) return;
			
			isContinuousPlayRunning = true;
			InvokeRepeating(nameof(PlayAudio), delay, interval);
		}
		
		[ContextMenu("StopContinuousPlay")]
		public void StopContinuousPlay() {
			isContinuousPlayRunning = false;
			CancelInvoke(nameof(PlayAudio));
		}

		private void PlayAudio()
		{
			if(audioClips.Length <= 0) return;
			
			int randomIndex = Random.Range(0, audioClips.Length);
			AudioClip audioClip = audioClips[randomIndex];
			
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
