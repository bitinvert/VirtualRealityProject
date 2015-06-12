using UnityEngine;
using System.Collections;

public class btnAct : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void btnAction (string btn)
	{
		switch (btn) {
		case "Button 1":
			Debug.Log("Button 1 pressed");
			break;
		case "Button 2":
			Debug.Log("Button 2 pressed");
			break;
		case "Button 3":
			Debug.Log("Button 3 pressed");
			break;
		}
	}
}
