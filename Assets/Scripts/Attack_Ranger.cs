using UnityEngine;
using System.Collections;

public class Attack_Ranger : MonoBehaviour {

	public GameObject arrow;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(AttackInfo AttackInfo){
		GameObject _arrow = Instantiate(arrow) as GameObject;
		_arrow.transform.position = transform.position;
		Arrow a = _arrow.GetComponent<Arrow>();
		a.enemy = AttackInfo.Target;
		a.originalPos = this.transform.position;
		a.finalPos = AttackInfo.Target.transform.position;
		a.attackDamage = AttackInfo.AttackDamage;
	}
	void StartAnimation() {
		animation.Play ("001-01_idle01", PlayMode.StopAll);
	}
	void WalkAnimate(){
		animation.Play("002_walk01",PlayMode.StopAll);
	}
}

public class AttackInfo {

	public GameObject Target;
	public int AttackDamage;

	public AttackInfo (GameObject target, float AttackDamage) {
		this.Target = target.gameObject;
		this.AttackDamage = (int) AttackDamage;
	}

}
