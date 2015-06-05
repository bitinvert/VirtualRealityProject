using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	LevelController lc;

	void Start() {
		lc = this.GetComponent<LevelController>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Debug.Log("Quit");
			Application.Quit();
		}
		if(Input.GetKey(KeyCode.P)) {
			lc.Check();
		}
	}
}
