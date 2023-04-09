using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Button[] inputButton;
	[SerializeField] private Image playerHPBarFill;
	[SerializeField] private Image enemyHPBarFill;

	public void GetPlayerChoice (int index) {
		foreach (Button button in inputButton) {
			button.interactable = false;
		}
	}

	public void UpdatePlayerHPBar (float hpPercentage) {
		playerHPBarFill.fillAmount = hpPercentage;
	}
	
	public void UpdateEnemyHPBar (float hpPercentage) {
		enemyHPBarFill.fillAmount = hpPercentage;
	}

}
