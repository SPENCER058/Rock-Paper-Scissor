using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Unit player;
    [SerializeField] private Unit enemy;
    [SerializeField] private UIManager uiManager;

    private ActionType playerAction;
    private ActionType enemyAction;

	private void Start () {
        uiManager.Initialize();

        player.Initialize();
        enemy.Initialize();

		uiManager.UserInput += InputAction;
		player.HPChange += OnUIPlayerHPChange;
		enemy.HPChange += OnUIEnemyHPChange;		
		player.UnitDead += OnPlayerDead;
		enemy.UnitDead += OnEnemyDead;

		StartCoroutine(Countdown(4));
		DontDestroyOnLoad(gameObject);
	}

	private void OnDestroy () {
		uiManager.UserInput -= InputAction;
		player.HPChange -= OnUIPlayerHPChange;
		enemy.HPChange -= OnUIEnemyHPChange;
		player.UnitDead -= OnPlayerDead;
		enemy.UnitDead -= OnEnemyDead;
	}


	// Player Input
	public void InputAction (int index) {
        uiManager.DisableChoiceButton();

        switch (index) {
            case 0:
                playerAction = ActionType.Rock;
                uiManager.SetPlayerChoiceText("Player Choice : " + playerAction);
                break;
            case 1:
                playerAction = ActionType.Paper;
				uiManager.SetPlayerChoiceText("Player Choice : " + playerAction);
				break;
            case 2:
                playerAction = ActionType.Scissor;
				uiManager.SetPlayerChoiceText("Player Choice : " + playerAction);
				break;
        }

        // Enemy Randomizer
        int enemyRandom = Random.Range(0, 3);
        enemyAction = (ActionType)enemyRandom;
		uiManager.SetEnemyChoiceText("Enemy Choice : " + enemyAction);

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
				uiManager.SetBattleResultText("Player Victory");
				player.Attack(enemy);
                break;
            case RoundResult.Draw:
				uiManager.SetBattleResultText("Draw");
				break;
            case RoundResult.PlayerLose:
				uiManager.SetBattleResultText("Player Lose");
				enemy.Attack(player);
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

	private void OnEnemyDead () {
		throw new System.NotImplementedException();
	}

	private void OnPlayerDead () {
		throw new System.NotImplementedException();
	}

	private IEnumerator CombatSequence () {
        yield return new WaitForSeconds(3f);
        uiManager.EnableChoiceButton();
        uiManager.SetResultTextEmpty();

	}

	private IEnumerator Countdown (int seconds) {
		int count = seconds;

		while (count > 0) {

			// display something...
			yield return new WaitForSeconds(1);
			count--;
			if (count == 0) {
				uiManager.SetBattleResultText("BATTLE START");
			} else {
				uiManager.SetBattleResultText(count.ToString());
			}

		}

		yield return new WaitForSeconds(1);
		uiManager.SetResultTextEmpty();
		uiManager.EnableChoiceButton();

	}

}
