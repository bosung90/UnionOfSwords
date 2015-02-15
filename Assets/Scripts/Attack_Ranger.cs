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

	void AttackAnimate(AttackInfo _attackInfo){
		GameObject _arrow = Instantiate(arrow) as GameObject;
		_arrow.transform.position = transform.position;
		Arrow a = _arrow.GetComponent<Arrow>();
		a.enemy = _attackInfo.Target;
		a.originalPos = this.transform.position;
		a.finalPos = _attackInfo.Target.transform.position;
		a.attackDamage = _attackInfo.AttackDamage;
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
