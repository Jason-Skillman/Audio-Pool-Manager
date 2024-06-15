namespace JasonSkillman.AudioPool {
	using UnityEngine;

	[CreateAssetMenu(fileName = "New Audio Config", menuName = "Audio/Audio Configuration")]
	public class AudioConfiguration : ScriptableObject {

		[SerializeField]
		private AudioConfigurationData audioConfigurationData = AudioConfigurationData.Create();
		public AudioConfigurationData AudioConfigurationData => audioConfigurationData;
	}
}
