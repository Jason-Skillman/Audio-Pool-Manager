namespace AudioPool {
	using UnityEngine;
	
	public class AudioManager : MonoBehaviour {

		public static AudioManager Instance { get; private set; }
		
		[SerializeField] 
		private int initialPoolSize = 1;
		[SerializeField] 
		private AudioEmitter audioEmitterPrefab = default;

		private AudioEmitterFactory factory;
		private AudioEmitterPool pool;

		public AudioEmitter SetAudioEmitter {
			set => audioEmitterPrefab = value;
		}

		private void Awake() {
			if(Instance != null) {
				Destroy(gameObject);
				return;
			}
			
			Instance = this;
			DontDestroyOnLoad(gameObject);
			
			InitPool();
		}

		private void InitPool() {
			factory = ScriptableObject.CreateInstance<AudioEmitterFactory>();
			factory.prefab = audioEmitterPrefab;

			pool = ScriptableObject.CreateInstance<AudioEmitterPool>();
			pool.name = "AudioEmitterPool";
			pool.Parent = transform;
			pool.Factory = factory;
			pool.InitialPoolSize = initialPoolSize;
		}

		public void PlayAudio(AudioClip clip, AudioConfiguration audioConfig = null) {
			PlayAudio(clip, Vector3.zero, audioConfig);
		}

		public void PlayAudio(AudioClip clip, Vector3 position, AudioConfiguration audioConfig = null) {
			AudioEmitter audioEmitter = pool.Request();
			if(audioEmitter) {
				audioEmitter.PlayAudio(clip, position, audioConfig);
				audioEmitter.OnFinished += AudioEmitter_FinishedPlaying;
			}
		}

		private void AudioEmitter_FinishedPlaying(AudioEmitter soundEmitter) {
			soundEmitter.OnFinished -= AudioEmitter_FinishedPlaying;
			soundEmitter.StopAudio();
			pool.Return(soundEmitter);
		}
	}
}
