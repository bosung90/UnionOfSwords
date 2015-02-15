using UnityEngine;
using System.Collections;

public class Attack_DR : MonoBehaviour {

	public GameObject Fire;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(AttackInfo AttackInfo){
		GameObject _fire = Instantiate(Fire) as GameObject;
		_fire.transform.position = transform.position;
		Arcane a = _fire.GetComponent<Arcane>();
		a.enemy = AttackInfo.Target;
		a.originalPos = this.transform.position;
		a.finalPos = AttackInfo.Target.transform.position;
		a.attackDamage = AttackInfo.AttackDamage;
	}
}
