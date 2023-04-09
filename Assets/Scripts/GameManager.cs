using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Unit player;
    [SerializeField] private Unit enemy;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Button[] inputButton;

    private ActionType playerAction;
    private ActionType enemyAction;

	private void Start () {
        player.Initialize();
        enemy.Initialize();
		player.setOpponent(enemy);
        enemy.setOpponent(player);

		player.HPChange += OnUIPlayerHPChange;
		enemy.HPChange += OnUIEnemyHPChange;

	}

	// Player Input
	public void InputAction (int index) {
        foreach (Button button in inputButton) {
            button.interactable = false;
        }

        switch (index) {
            case 0:
                playerAction = ActionType.Rock;
                Debug.Log("Player Choice : " + playerAction);
                break;
            case 1:
                playerAction = ActionType.Paper;
                Debug.Log("Player Choice : " + playerAction);
                break;
            case 2:
                playerAction = ActionType.Scissor;
                Debug.Log("Player Choice : " + playerAction);
                break;
        }

        // Enemy Randomizer
        int enemyRandom = Random.Range(0, 3);
        enemyAction = (ActionType)enemyRandom;
        Debug.Log("Enemy Choice : " + enemyAction);

        // Result Processor
        RoundResult roundResult = RoundResult.Draw;

        if (playerAction == enemyAction) {
            roundResult = RoundResult.Draw;

			// if player action 0 and enemy 2 (player win)
		} else if (playerAction == (ActionType)0 && enemyAction == (ActionType)2) {
			roundResult = RoundResult.PlayerVictory;

			// if player action 2 and enemy 0 (enemy win)
		} else if (playerAction == (ActionType)2 && enemyAction == (ActionType)0) {
			roundResult = RoundResult.PlayerLose;

		} else if (playerAction > enemyAction) {
			roundResult = RoundResult.PlayerVictory;

		} else {
			roundResult = RoundResult.PlayerLose;

		}

        // Final Result
        Debug.Log(roundResult);
        switch (roundResult) {
            case RoundResult.PlayerVictory:
                player.Attack();
                break;
            case RoundResult.Draw:
                break;
            case RoundResult.PlayerLose:
                enemy.Attack();
                break;
        }

        StartCoroutine(CombatSequence());
    }

	private void OnUIPlayerHPChange (float percentageHp) {
		uiManager.UpdatePlayerHPBar(percentageHp);
	}

	private void OnUIEnemyHPChange (float percentageHp) {
		uiManager.UpdateEnemyHPBar(percentageHp);
	}

	private IEnumerator CombatSequence () {
        yield return new WaitForSeconds(1f);
        foreach (Button button in inputButton) {
            button.interactable = true;
        }
    }

}
