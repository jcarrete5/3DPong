using UnityEngine;

public class PlaySoundOnCollide : MonoBehaviour {
	AudioSource sound;

	void Start() {
		sound = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		sound.PlayOneShot(sound.clip, 1.0f);
	}
}
