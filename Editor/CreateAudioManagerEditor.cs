namespace JasonSkillman.AudioPool.Editor {
	using UnityEditor;
	using UnityEngine;
	
	public class CreateAudioManagerEditor : MonoBehaviour {

		[MenuItem("GameObject/Audio/Audio Manager", false, 3)]
		static void CreateAudioManager(MenuCommand menuCommand) {
			//Check if the manager has already been created
			AudioManager manager = FindObjectOfType<AudioManager>();

			if(manager != null) {
				Debug.LogWarning("Audio Manager has already been created.");
				Selection.activeObject = manager;
				return;
			}

			//Use the asset database to fetch the console prefab
			GameObject consolePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(
				"Packages/com.jasonskillman.audiomanager/Runtime/Prefabs/AudioManager.prefab");

			//Instantiate the prefab in the hierarchy
			PrefabUtility.InstantiatePrefab(consolePrefab);
        
			Selection.activeObject = consolePrefab;
		}
	}
}
