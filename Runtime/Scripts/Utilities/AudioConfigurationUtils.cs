namespace JasonSkillman.AudioPool.Utilities {
	using UnityEngine;
	using AudioConfiguration = JasonSkillman.AudioPool.AudioConfiguration;

	public static class AudioConfigurationUtils {

		public static void ApplyAudioConfig(this AudioSource audioSource, AudioConfiguration audioConfig) => audioSource.ApplyAudioConfig(audioConfig.AudioConfigurationData);

		public static void ApplyAudioConfig(this AudioSource audioSource, in AudioConfigurationData configurationData) {
			audioSource.outputAudioMixerGroup = configurationData.outputAudioMixerGroup;
			audioSource.mute = configurationData.mute;
			audioSource.bypassEffects = configurationData.bypassEffects;
			audioSource.bypassListenerEffects = configurationData.bypassListenerEffects;
			audioSource.bypassReverbZones = configurationData.bypassReverbZones;
			audioSource.priority = configurationData.priority;
			audioSource.volume = configurationData.volume;
			audioSource.pitch = configurationData.pitch;
			audioSource.panStereo = configurationData.panStereo;
			audioSource.spatialBlend = configurationData.spatialBlend;
			audioSource.reverbZoneMix = configurationData.reverbZoneMix;
			audioSource.dopplerLevel = configurationData.dopplerLevel;
			audioSource.spread = configurationData.spread;
			audioSource.rolloffMode = configurationData.rolloffMode;
			audioSource.minDistance = configurationData.minDistance;
			audioSource.maxDistance = configurationData.maxDistance;
			audioSource.ignoreListenerVolume = configurationData.ignoreListenerVolume;
			audioSource.ignoreListenerPause = configurationData.ignoreListenerPause;
		}
	}
}
