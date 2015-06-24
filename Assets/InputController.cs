using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	LevelController lc;
	bool timerActive;


	void Start () {
		lc = this.GetComponent<LevelController>();
		timerActive = false;
	}


	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Debug.Log("Quit");
			Application.Quit();
		}

		if (Input.GetKeyUp(KeyCode.P)) 
		{
			lc.Check();
		}

		if (Input.GetKeyUp(KeyCode.R)) 
		{
			lc.ResetScene();
		}

		if (Input.GetKeyUp(KeyCode.T))
		{
			if (timerActive == true)
			{
				lc.TimerStop();
				timerActive = false;
	
			} else {
				lc.TimerStart();
				timerActive = true;
			}
		}

	}
}
