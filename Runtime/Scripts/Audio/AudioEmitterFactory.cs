using System;
using Factory;
using UnityEditor;
using UnityEngine;

namespace Audio {
	//[CreateAssetMenu(fileName = "New SoundEmitter Factory", menuName = "Factory/SoundEmitter Factory")]
	public class AudioEmitterFactory : FactorySO<AudioEmitter> {
		
		//private const string objectName = "AudioEmitter";
		
		public AudioEmitter prefab;

		private void Awake() {
			/*var gameObject = new GameObject();
			gameObject.AddComponent<AudioEmitter>();
			prefab = gameObject.GetComponent<AudioEmitter>();*/
		}

		public override AudioEmitter Create() {
			/*if(prefab == null) {
				var gameObject = new GameObject(objectName);
				gameObject.AddComponent<AudioEmitter>();
				prefab = gameObject.GetComponent<AudioEmitter>();
				return prefab;
			}*/
			return Instantiate(prefab);
		}
		
	}
}