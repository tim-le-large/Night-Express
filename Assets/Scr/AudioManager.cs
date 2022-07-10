using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour {
	
		// In das Skript zum Beispiel, wenn Player sich bewegt: 
		// FindObjectOfType<AudioManager>().Play("name des sounds");
	
		public Sound[] sounds;
		
		public static AudioManager instance;
	
		// used for initialization
		void Awake() {
			
			// for each scene it checks if audio manager already exists
			if (instance == null) {
				instance = this;
			} else {
				Destroy(gameObject);
				return;
			}
			
			DontDestroyOnLoad(gameObject);
			
			// loop through sounds and add audio source to sounds
			foreach (Sound s in sounds)
			{

				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				
				s.source.volume = s.volume;
				s.source.pitch = s.pitch;
				s.source.loop = s.loop;
			}
		}
		
		public void Play (string name) {
			Sound s = Array.Find(sounds, sound => sound.name == name);
			if (s == null) {
				Debug.LogWarning("Sound " + name + " not found!"); 
				return;
			}
			s.source.Play();
		}
		public void Stop (string name) {
			Sound s = Array.Find(sounds, sound => sound.name == name);
			if (s == null) {
				Debug.LogWarning("Sound " + name + " not found!"); 
				return;
			}
			s.source.Stop();
		}
		
		// called once per frame
		void Start() {
			Play("Theme");
		}
		
}