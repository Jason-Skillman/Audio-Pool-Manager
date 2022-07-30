namespace AudioPool {
	using System;
	using System.Collections;
	using UnityEngine;
	
	[RequireComponent(typeof(AudioSource))]
	public class AudioEmitter : MonoBehaviour {

		private AudioSource audioSource;

		private Coroutine coroutineFinishPlaying;

		public event Action<AudioEmitter> OnFinished;

		private void Awake() {
			audioSource = GetComponent<AudioSource>();
		}

		private void Start() {
			audioSource.playOnAwake = false;
		}

		public void PlayAudio(AudioClip clip, Vector3 position, AudioConfiguration audioConfig = null) {
			audioSource.clip = clip;
			transform.position = position;
			
			//Setup settings
			if(audioConfig == null)
				audioConfig = AudioConfiguration.DefaultConfig;
			ApplySettings(audioConfig);
			
			//Set 2D or 2D spatial blend
			if(position == Vector3.zero) {
				audioConfig.SpatialBlend = 0.0f;
			} else {
				audioConfig.SpatialBlend = 1.0f;
			}
			
			audioSource.Play();
			
			coroutineFinishPlaying = StartCoroutine(FinishedPlaying(clip.length));
		}

		public void StopAudio() {
			audioSource.Stop();

			if(coroutineFinishPlaying != null)
				StopCoroutine(coroutineFinishPlaying);
		}

		private void ApplySettings(AudioConfiguration settings) {
			audioSource.outputAudioMixerGroup = settings.OutputAudioMixerGroup;
			audioSource.mute = settings.Mute;
			audioSource.bypassEffects = settings.BypassEffects;
			audioSource.bypassListenerEffects = settings.BypassListenerEffects;
			audioSource.bypassReverbZones = settings.BypassReverbZones;
			audioSource.priority = settings.Priority;
			audioSource.volume = settings.Volume;
			audioSource.pitch = settings.Pitch;
			audioSource.panStereo = settings.PanStereo;
			audioSource.spatialBlend = settings.SpatialBlend;
			audioSource.reverbZoneMix = settings.ReverbZoneMix;
			audioSource.dopplerLevel = settings.DopplerLevel;
			audioSource.spread = settings.Spread;
			audioSource.rolloffMode = settings.RolloffMode;
			audioSource.minDistance = settings.MinDistance;
			audioSource.maxDistance = settings.MaxDistance;
			audioSource.ignoreListenerVolume = settings.IgnoreListenerVolume;
			audioSource.ignoreListenerPause = settings.IgnoreListenerPause;
		}

		private IEnumerator FinishedPlaying(float clipLength) {
			yield return new WaitForSeconds(clipLength);

			OnFinished?.Invoke(this);
		}
	}
}
