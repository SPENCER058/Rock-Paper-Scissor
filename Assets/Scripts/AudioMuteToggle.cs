using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMuteToggle : MonoBehaviour
{
	[SerializeField] Toggle toggle;
	[SerializeField] AudioMixer audioMixer;
	[SerializeField] string MasterVolumeParameter;

	private void Awake () {
		int mutePref = PlayerPrefs.GetInt("PAUSE");
		if (mutePref != 0) {
			toggle.isOn = true;
		} else {
			toggle.isOn = false;
		}
	}

	private void Start () {
		audioMixer.GetFloat(MasterVolumeParameter, out var master_db);
		toggle.SetIsOnWithoutNotify(master_db == -80);
	}

	public void SetMute (bool toggleValue) {
		int mute;
		float volumeValue;
		if (toggleValue) {
			volumeValue = -80;
			mute = 1;
		}
        else
        {
			volumeValue = 0;
			mute = 0;
        }
        audioMixer.SetFloat(MasterVolumeParameter, volumeValue);
		PlayerPrefs.SetFloat("PAUSE", mute);
		PlayerPrefs.SetFloat("MASTER_VOL", volumeValue);
		PlayerPrefs.Save();
	}
}
