﻿using UnityEngine;
using UnityEngine.Audio;

namespace Tevolve.Audio {
	[CreateAssetMenu(fileName = "NewAudioConfig", menuName = "Audio/Audio Configuration")]
	public class AudioConfiguration : ScriptableObject {
		public AudioMixerGroup OutputAudioMixerGroup = null;
		public bool Mute = false;
		public bool BypassEffects = false;
		public bool BypassListenerEffects = false;
		public bool BypassReverbZones = false;
		public int Priority = 128;
		public float Volume = 1f;
		public float Pitch = 1f;
		public float PanStereo = 0f;
		public float SpatialBlend = 0f;
		public float ReverbZoneMix = 1f;
		public float DopplerLevel = 1f;
		public float Spread = 0f;
		public AudioRolloffMode RolloffMode = AudioRolloffMode.Logarithmic;
		public float MinDistance = 1f;
		public float MaxDistance = 500f;
		public bool IgnoreListenerVolume = false;
		public bool IgnoreListenerPause = false;
		
		private static AudioConfiguration defaultAudio;
		public static AudioConfiguration DefaultAudio {
			get {
				if(defaultAudio == null)
					defaultAudio = CreateInstance<AudioConfiguration>();
				return defaultAudio;
			}
		}
	}
}