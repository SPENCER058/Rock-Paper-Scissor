using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	[SerializeField] private Button[] inputButton;

	[Header("HP Bar Fill")]
	[SerializeField] private Image playerHPBarFill;
	[SerializeField] private Image enemyHPBarFill;

	[Header("In Game Text")]
	[SerializeField] private TMP_Text battleResultText;
	[SerializeField] private TMP_Text playerChoiceText;
	[SerializeField] private TMP_Text enemyChoiceText;

	[Header("In Game Component")]
	[SerializeField] private Button pauseButton;

	[Header("Panel Text")]
	[SerializeField] private TMP_Text panelText;
	[SerializeField] private TMP_Text textRestartPlayAgain;

	[Header("Panel Component")]
	[SerializeField] private GameObject resumeButton;
	[SerializeField] private Button restartPlayAgain;

	public Action<int> UserInput;

	public void Initialize() {
		SetResultTextEmpty();
		DisableChoiceButton();
		SetPausePanel();
	}

	public void ButtonClicked (int index) {
		UserInput?.Invoke(index);
	}

	public void SetResultTextEmpty () {
		battleResultText.text = " ";
		playerChoiceText.text = " ";
		enemyChoiceText.text = " ";
	}

	public void SetPausePanel () {
		panelText.text="PAUSE";
		if (!resumeButton.activeSelf) {
			resumeButton.SetActive(true);
		}
		textRestartPlayAgain.text = "Restart";

	}

	public void SetResultPanel (string result) {
		panelText.text = result + " WIN";
		resumeButton.SetActive(false);
		textRestartPlayAgain.text = "Play Again";
		pauseButton.onClick.Invoke();
	}

	public void SetBattleResultText (string text) {
		battleResultText.text = text;
	}	
	
	public void SetPlayerChoiceText (string text) {
		playerChoiceText.text = text;
	}	
	
	public void SetEnemyChoiceText (string text) {
		enemyChoiceText.text = text;
	}

	public void EnableChoiceButton () {
		foreach (Button button in inputButton) {
			button.interactable = true;
		}
	}

	public void DisableChoiceButton () {
		foreach (Button button in inputButton) {
			button.interactable = false;
		}
	}

	public void EnablePauseButton () {
		pauseButton.interactable = true;
	}

	public void DisablePauseButton () {
		pauseButton.interactable = false;
	}

	public void UpdatePlayerHPBar (float hpPercentage) {
		playerHPBarFill.fillAmount = hpPercentage;
	}
	
	public void UpdateEnemyHPBar (float hpPercentage) {
		enemyHPBarFill.fillAmount = hpPercentage;
	}

}
