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
		private bool use3DPosition = default;
		[SerializeField]
		private bool playOnStart = true;
		[SerializeField]
		private bool continuousPlay;
		[SerializeField]
		private float delay, interval = 1;

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
