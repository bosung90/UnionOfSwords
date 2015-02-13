using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	Image healthBar;
	public Targetable health;
	
	void Start () {
		healthBar = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = health.Health / (float)health.MaxHealth;
	}
}
