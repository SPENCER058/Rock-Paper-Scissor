using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] private float hp;
	[SerializeField] private float attackDamage;

	public void GetDamaged(float damageValue) {
		hp -= damageValue;
		if(hp < 0) {
			// dead 
			Debug.Log(this+"Dead");
		}
	}
}
