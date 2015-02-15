using UnityEngine;
using System.Collections;

public class Attack_MG : MonoBehaviour {



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AttackAnimate(AttackInfo attackInfo){
		attackInfo.Target.SendMessage ("ApplyDamage", attackInfo.AttackDamage, SendMessageOptions.DontRequireReceiver);
	}
}
