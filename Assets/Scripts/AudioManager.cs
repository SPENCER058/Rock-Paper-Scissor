using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[SerializeField] AudioSource audioSource;
	public static AudioManager instance;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void Play (AudioClip audioClip) {
		audioSource.clip = audioClip;
		audioSource.Play();
	}

}
