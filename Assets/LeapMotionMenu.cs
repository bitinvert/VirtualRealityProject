using UnityEngine;
using System.Collections;

public class LeapMotionMenu : MonoBehaviour {

	LevelController lc;
	bool timerActive;
	
	void Start() {
		lc = this.GetComponent<LevelController>();
		timerActive = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.name.Equals("CheckButton")) {
			lc.Check();
		}
		if(other.name.Equals("TimerButton")) {
			if(timerActive == true) {
				
				lc.TimerStop();
				timerActive = false;
				
			} else {
				
				lc.TimerStart();
				timerActive = true;
				
			}
		}
		if(other.name.Equals("ResetButton")) {
			lc.ResetScene();
		}
		if(other.name.Equals("ExitButton")) {
			Application.Quit();
		}
	}
}
