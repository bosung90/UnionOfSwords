using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBarDamageable : MonoBehaviour {

	Image healthBar;
//	public Damageable damageable;
	
	void Start () {
		healthBar = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
//		healthBar.fillAmount = damageable.CurHealth / (float)damageable.MaxHealth;
	}
}
