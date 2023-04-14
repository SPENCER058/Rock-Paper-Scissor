using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
	public void Restart () {
		BattleManager battleManager = FindObjectOfType<BattleManager>();
		if (battleManager != null) {
			Destroy(battleManager.gameObject);
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
