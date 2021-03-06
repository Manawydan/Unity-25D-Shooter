using UnityEngine;
using System.Collections;

public class HealthBehaviour : MonoBehaviour {
	public int maxHealth = 100;
	public bool IsDead{ get; protected set;}
	public int CurrentHealth{ get; protected set;}
	public delegate void HealthEvent(GameObject source, GameObject attacker, int previusHealth, int currentHealth);
	public static event HealthEvent onHealthOver;
	public static event HealthEvent onHealthChange;

	private void Awake(){
		RestoreFullHealth ();
	}

	public void TakeDamage(int dmg, GameObject attacker)
	{
		if (IsDead) return;
		int previusHealth = CurrentHealth;
		CurrentHealth -= dmg;
		if (CurrentHealth <= 0) {
			CurrentHealth = 0;
			IsDead = true;
			if (onHealthOver != null)
				onHealthOver (gameObject, attacker, previusHealth, CurrentHealth);
			if (onHealthChange != null)
				onHealthChange (gameObject, attacker, previusHealth, CurrentHealth);
		} 
		else 
		{
			if (onHealthChange != null)
				onHealthChange (gameObject, attacker, previusHealth, CurrentHealth);
		}
	}

	public void RestoreHealthAmmount(int ammount){
		int previusHealth = CurrentHealth;
		CurrentHealth += ammount;
		CurrentHealth = Mathf.Clamp (CurrentHealth, 0, maxHealth);
		if (onHealthChange != null)
			onHealthChange (gameObject, null, previusHealth, CurrentHealth);
	}

	public void RestoreFullHealth(bool call_onHealthChange = false){
		int previusHealth = CurrentHealth;
		CurrentHealth = maxHealth;
		IsDead = false;
		if(call_onHealthChange && onHealthChange!=null)
			onHealthChange (gameObject, null, previusHealth, CurrentHealth);
	}
}