using System.Data.Common;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioMixer audioMixer;
	public static AudioManager instance;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	private void Start () {
		float bgmSaveValue = PlayerPrefs.GetFloat("BGM_VOL");
		float masterVol = PlayerPrefs.GetFloat("MASTER_VOL");
		audioMixer.SetFloat("BGM_VOL",bgmSaveValue);
		audioMixer.SetFloat("MASTER_VOL",masterVol);
	}

	public void Play (AudioClip audioClip) {
		audioSource.clip = audioClip;
		audioSource.Play();
	}

}
