using UnityEngine;
using System.Collections;

public class EscapeGame : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("escape"))
		{
			Debug.Log("Quit");
			Application.Quit();
		}
	}
}
