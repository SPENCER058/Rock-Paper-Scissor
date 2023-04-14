using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadMainMenuScene () {
		SceneManager.LoadScene("MainMenu");
	}

	public void OnApplicationQuit () {
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}
}
