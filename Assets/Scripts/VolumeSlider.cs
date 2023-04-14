using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
	[SerializeField] Slider slider;
	[SerializeField] AudioMixer audioMixer;
	[SerializeField] string parameter;

	Dictionary<string, float> playerPrefDist = new Dictionary<string, float>();

	private void Awake () {
		float db = PlayerPrefs.GetFloat("BGM_VOL");
		slider.value = DbToValue(db);
	}

	private void OnDestroy () {
		var db = ValueToDb(slider.value);
		PlayerPrefs.SetFloat("BGM_VOL", db);
		PlayerPrefs.Save();
	}

	public void SetAttenuation (float value) {
		var db = ValueToDb(value);
		audioMixer.SetFloat(parameter, db);
		PlayerPrefs.SetFloat("BGM_VOL", db);
		playerPrefDist["BGM_VOL"] = db;
	}

	public float ValueToDb (float value) {
		return value == 0 ? -80f : 20f * Mathf.Log10(value);
	}

	public float DbToValue (float db) {
		return db == -80 ? 0 : Mathf.Pow(10, db / 20f);
	}
}
