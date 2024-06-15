namespace JasonSkillman.AudioPool {
	using System;
	using UnityEngine;
	using UnityEngine.Audio;
	using Random = UnityEngine.Random;

	/// <summary>A struct representing all of the data in an audio source. Use <see cref="Create"/> to create a new struct.</summary>
	[Serializable]
	public struct AudioConfigurationData {

		public AudioMixerGroup outputAudioMixerGroup;
		public bool mute;
		public bool bypassEffects;
		public bool bypassListenerEffects;
		public bool bypassReverbZones;
		public int priority;
		public float volume;
		public float pitch;
		public float panStereo;
		public float spatialBlend;
		public float reverbZoneMix;
		public float dopplerLevel;
		public float spread;
		public AudioRolloffMode rolloffMode;
		public float minDistance;
		public float maxDistance;
		public bool ignoreListenerVolume;
		public bool ignoreListenerPause;

		/// <summary>Creates a new AudioConfigurationData with default settings.</summary>
		public static AudioConfigurationData Create() =>
			new() {
				mute = false,
				bypassEffects = false,
				bypassListenerEffects = false,
				bypassReverbZones = false,
				priority = 128,
				volume = 1.0f,
				pitch = 1.0f,
				panStereo = 0.0f,
				spatialBlend = 0.0f,
				reverbZoneMix = 1.0f,
				dopplerLevel = 1.0f,
				spread = 0.0f,
				rolloffMode = AudioRolloffMode.Logarithmic,
				minDistance = 1.0f,
				maxDistance = 500.0f,
				ignoreListenerVolume = false,
				ignoreListenerPause = false,
			};

		public void RandomPitch(in Vector3 pitchRange) {
			float randomPitch = Random.Range(pitchRange.x, pitchRange.y);
			pitch = randomPitch;
		}
	}
}
