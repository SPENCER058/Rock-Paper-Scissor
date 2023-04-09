using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] private float maxHp;
	[SerializeField] private float hp;
	[SerializeField] private float attackDamage;
	[SerializeField] private Unit opponent;

	public Action<float> HPChange;

	public void Initialize () {
		hp = maxHp;
	}

	public void setOpponent (Unit opponentInput) {
		opponent = opponentInput;
	}

	public void Attack () {
		opponent.GetDamaged(attackDamage);
	}

	public void GetDamaged(float damageValue) {
		hp -= damageValue;
		HPValueChange();

		if(hp < 0) {
			// dead 
			Debug.Log(this+"Dead");
		}
	}
	private void HPValueChange () {
		HPChange?.Invoke(hp / maxHp);
	}

	public float GetDamageValue () {
		return attackDamage;
	}

	public float GetHPValue () {
		return hp;
	}


}
