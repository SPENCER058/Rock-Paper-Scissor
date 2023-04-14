using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] private float maxHp;
	[SerializeField] private float hp;
	[SerializeField] private float attackDamage;

	public Action<float> HPChange;
	public Action UnitDead;

	public void Initialize () {
		hp = maxHp;
	}

	public void Attack (Unit opponent) {
		opponent.GetDamaged(attackDamage);
	}

	public void GetDamaged(float damageValue) {
		hp -= damageValue;
		HPValueChange();

		if(hp < 0) {
			// dead 
			UnitDead?.Invoke();
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
