namespace JasonSkillman.AudioPool {
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

		public void PlayAudio(AudioClip clip, in Vector3 position, in AudioConfigurationData audioConfig) {
			audioSource.clip = clip;
			
			//Only set position if audio is spacial
			if(audioConfig.spatialBlend > 0.0f)
				transform.position = position;
			
			//Setup settings
			ApplySettings(audioConfig);
			
			audioSource.Play();
			
			IEnumerator FinishedPlayingCoroutine(float clipLength) {
				yield return new WaitForSeconds(clipLength);

				OnFinished?.Invoke(this);
			}
			
			coroutineFinishPlaying = StartCoroutine(FinishedPlayingCoroutine(clip.length));
		}

		public void StopAudio() {
			audioSource.Stop();

			if(coroutineFinishPlaying != null)
				StopCoroutine(coroutineFinishPlaying);
		}

		private void ApplySettings(in AudioConfigurationData settings) {
			audioSource.outputAudioMixerGroup = settings.outputAudioMixerGroup;
			audioSource.mute = settings.mute;
			audioSource.bypassEffects = settings.bypassEffects;
			audioSource.bypassListenerEffects = settings.bypassListenerEffects;
			audioSource.bypassReverbZones = settings.bypassReverbZones;
			audioSource.priority = settings.priority;
			audioSource.volume = settings.volume;
			audioSource.pitch = settings.pitch;
			audioSource.panStereo = settings.panStereo;
			audioSource.spatialBlend = settings.spatialBlend;
			audioSource.reverbZoneMix = settings.reverbZoneMix;
			audioSource.dopplerLevel = settings.dopplerLevel;
			audioSource.spread = settings.spread;
			audioSource.rolloffMode = settings.rolloffMode;
			audioSource.minDistance = settings.minDistance;
			audioSource.maxDistance = settings.maxDistance;
			audioSource.ignoreListenerVolume = settings.ignoreListenerVolume;
			audioSource.ignoreListenerPause = settings.ignoreListenerPause;
		}
	}
}
