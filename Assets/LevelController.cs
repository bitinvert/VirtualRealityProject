using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	GameObject triCorner;
	GameObject quadCorner;
	GameObject quadTee;

	void Start() {
		triCorner = GameObject.FindGameObjectWithTag("TriCorner");
		quadCorner = GameObject.FindGameObjectWithTag("QuadCorner");
		quadTee = GameObject.FindGameObjectWithTag("QuadTee");
	}

	public void Check() {
		//First Correct Option
		Vector3 triRot = triCorner.transform.eulerAngles;
		if(Mathf.RoundToInt(triRot.x) == 270 && Mathf.RoundToInt(triRot.y) == 180 && Mathf.RoundToInt(triRot.z) == 0 
		   || Mathf.RoundToInt(triRot.x) == 90 && Mathf.RoundToInt(triRot.y) == 90 && Mathf.RoundToInt(triRot.z) == 0) {
			Debug.Log ("yay :3");
		} else {
			Debug.Log ("meh");
		}

	}
}
