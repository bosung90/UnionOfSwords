using UnityEngine;
using System.Collections;



public class Attack_AM : MonoBehaviour {

	public GameObject arcane;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!animation.isPlaying)
			animation.Play("combat_idle",  PlayMode.StopAll);
	
	}

	void AttackAnimate(AttackInfo AttackInfo){
		GameObject _arcane = Instantiate(arcane) as GameObject;
		_arcane.transform.position = transform.position;
		Arcane a = _arcane.GetComponent<Arcane>();
		a.enemy = AttackInfo.Target;
		a.originalPos = this.transform.position;
		a.finalPos = AttackInfo.Target.transform.position;
		a.attackDamage = AttackInfo.AttackDamage;
		animation.Play ("attack1", PlayMode.StopAll);
	}

	void WalkAnimate(){
		animation.Play ("walk", PlayMode.StopAll);
	}

	void StartAnimation() {
		animation.Play ("combat_idle", PlayMode.StopAll);
	}
}




