using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resource_P1 : MonoBehaviour {

	Text resource;
	public static int currentResource;

	// Use this for initialization
	void Start () {
		resource = GetComponent<Text> ();
		currentResource = 20;
		resource.text = "Resource : " + currentResource;
		InvokeRepeating ("income", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		resource.text = "Resource : " + currentResource;
	
	}

	private void income() {
		currentResource += 2;
	}
}
