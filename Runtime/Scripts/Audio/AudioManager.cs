using System;
using Tevolve.Singleton;
using UnityEngine;

namespace Tevolve.Audio {
	public class AudioManager : SingletonBehavior<AudioManager> {

		[SerializeField] private int initialPoolSize = 1;
		[SerializeField] private AudioEmitter audioEmitterPrefab;

		private AudioEmitterFactory factory;
		private AudioEmitterPool pool;

		protected override void Awake() {
			base.Awake();
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