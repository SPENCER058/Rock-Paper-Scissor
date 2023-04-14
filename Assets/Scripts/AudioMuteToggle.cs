using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMuteToggle : MonoBehaviour
{
	[SerializeField] Toggle toggle;
	[SerializeField] AudioMixer audioMixer;
	[SerializeField] string MasterVolumeParameter;

	private void Start () {
		audioMixer.GetFloat(MasterVolumeParameter, out var master_db);
		toggle.SetIsOnWithoutNotify(master_db == -80);
	}

	public void SetMute (bool value) {
		audioMixer.SetFloat(MasterVolumeParameter, value ? -80 : 0);
	}
}
