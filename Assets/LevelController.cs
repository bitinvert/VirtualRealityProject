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


	/**
	 * Prüfe die beiden möglichen Anordnungen für Spielobjekte für das Level.
	 * Zeige entsprechend eine Meldung für den Spieler an!
	 **/
	public void Check() {
		if (CheckFirstOption () || CheckSecondOption ()) {
			Debug.Log ("yay");
			// Hier noch eine Meldung für den Spieler anzeigen lassen!
		}
	}

	// Anm.: Bei einem Winkel == 0° muss auch auf 360° geprüft werden, wegen Rundungsproblemen!
	public bool CheckFirstOption() {

		bool tri_Correct = false;
		bool quadC_Correct = false;
		bool quadT_Correct = false;

		// Check TriCorner  -- okay 
		Vector3 tri_Rot = triCorner.transform.eulerAngles;
		Vector3 tri_Pos = triCorner.transform.position;

		if (Mathf.RoundToInt (tri_Rot.x) == 270 && 
		    Mathf.RoundToInt (tri_Rot.y) == 180 && 
		    (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) {

			// Anm.: tri_Pos.z muss eigentlich ~ -1.5 sein, könnte hier also n Problem sein mit der -1, ggf auf -2 runden?
			if(Mathf.RoundToInt (tri_Pos.x) == 2 && Mathf.RoundToInt (tri_Pos.y) == 1 && Mathf.RoundToInt (tri_Pos.z) == -1) {
				tri_Correct = true;
			}

		} else if (Mathf.RoundToInt(tri_Rot.x) == 90 && 
		           Mathf.RoundToInt (tri_Rot.y) == 90 && 
		           (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) { 

			if(Mathf.RoundToInt (tri_Pos.x) == 1 && Mathf.RoundToInt (tri_Pos.y) == 1 && Mathf.RoundToInt (tri_Pos.z) == 0) {
				tri_Correct = true;
			}
		}


		// Check QuadCorner  -- okay
		Vector3 quadC_Rot = quadCorner.transform.eulerAngles;
		Vector3 quadC_Pos = quadCorner.transform.position;

		if (Mathf.RoundToInt (quadC_Rot.x) == 90 && 
			(Mathf.RoundToInt (quadC_Rot.y) == 0 || Mathf.RoundToInt (quadC_Rot.y) == 360) && 
			(Mathf.RoundToInt (quadC_Rot.z) == 0 || Mathf.RoundToInt (quadC_Rot.z) == 360)) {

			if (Mathf.RoundToInt (quadC_Pos.x) == -1 && Mathf.RoundToInt (quadC_Pos.y) == 1 && Mathf.RoundToInt (quadC_Pos.z) == -1) {
				quadC_Correct = true;
			}
		}

		// Check QuadTee -- okay
		Vector3 quadT_Rot = quadTee.transform.eulerAngles;
		Vector3 quadT_Pos = quadTee.transform.position;

		if (Mathf.RoundToInt (quadT_Rot.x) == 270 &&
			Mathf.RoundToInt (quadT_Rot.y) == 270 &&
			(Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {

			// Anm.: quadT_Pos.z muss eigentlich ~ -2.5 sein, könnte hier also n Problem sein mit der -2, ggf auf -3 runden?
			if(Mathf.RoundToInt (quadT_Pos.x) == -2 && Mathf.RoundToInt (quadT_Pos.y) == 1 && Mathf.RoundToInt (quadT_Pos.z) == -2) {
				quadT_Correct = true;
			}

		} else if (Mathf.RoundToInt (quadT_Rot.x) == 90 && 
		           Mathf.RoundToInt (quadT_Rot.y) == 270 && 
		           (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {
		
			// Anm.: quadT_Pos.z muss eigentlich ~ -2.5 sein, könnte hier also n Problem sein mit der -2, ggf auf -3 runden?
			if(Mathf.RoundToInt (quadT_Pos.x) == 0 && Mathf.RoundToInt (quadT_Pos.y) == 1 && Mathf.RoundToInt (quadT_Pos.z) == -2) {
				quadT_Correct = true;
			}
		}

		// Stimmen alle Spielobjekte?
		return (tri_Correct && quadC_Correct && quadT_Correct);
	}


	public bool CheckSecondOption() {
		
		bool tri_Correct = false;
		bool quadC_Correct = false;
		bool quadT_Correct = false;
		
		// Check TriCorner  -- okay 
		Vector3 tri_Rot = triCorner.transform.eulerAngles;
		Vector3 tri_Pos = triCorner.transform.position;
		
		if (Mathf.RoundToInt (tri_Rot.x) == 270 && 
		    Mathf.RoundToInt (tri_Rot.y) == 180 && 
		    (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) {
			
			// Anm.: tri_Pos.z muss eigentlich ~ 0.5 sein, könnte hier also n Problem sein mit der 0, ggf auf 1 runden?
			if(Mathf.RoundToInt (tri_Pos.x) == 1 && Mathf.RoundToInt (tri_Pos.y) == 1 && Mathf.RoundToInt (tri_Pos.z) == 0) {
				tri_Correct = true;
			}
			
		} else if (Mathf.RoundToInt(tri_Rot.x) == 90 && 
		           Mathf.RoundToInt (tri_Rot.y) == 90 && 
		           (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) { 

			// Anm.: tri_Pos.z muss eigentlich ~ 0.5 sein, könnte hier also n Problem sein mit der 1, ggf auf 0 runden?
			if(Mathf.RoundToInt (tri_Pos.x) == 0 && Mathf.RoundToInt (tri_Pos.y) == 1 && Mathf.RoundToInt (tri_Pos.z) == 1) {
				tri_Correct = true;
			}
		}

		
		// Check QuadCorner  -- okay
		Vector3 quadC_Rot = quadCorner.transform.eulerAngles;
		Vector3 quadC_Pos = quadCorner.transform.position;
		
		if (Mathf.RoundToInt (quadC_Rot.x) == 270 && 
		    Mathf.RoundToInt (quadC_Rot.y) == 270 && 
		    (Mathf.RoundToInt (quadC_Rot.z) == 0 || Mathf.RoundToInt (quadC_Rot.z) == 360)) {

			// Wieder Rundungsproblem mit -2 (eigentlich -2.5 gefordert)
			if(Mathf.RoundToInt (quadC_Pos.x) == 0 && Mathf.RoundToInt (quadC_Pos.y) == 1 && Mathf.RoundToInt (quadC_Pos.z) == -2) {
				quadC_Correct = true;
			}
		}

				
		// Check QuadTee  -- okay
		Vector3 quadT_Rot = quadTee.transform.eulerAngles;
		Vector3 quadT_Pos = quadTee.transform.position;
		
		if (Mathf.RoundToInt (quadT_Rot.x) == 270 &&
		    (Mathf.RoundToInt (quadT_Rot.y) == 0 || Mathf.RoundToInt (quadT_Rot.y) == 360) &&
		    (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {
			
			// Anm.: Rundungsproblem weil eigentlich -1.5
			if(Mathf.RoundToInt (quadT_Pos.x) == -1 && Mathf.RoundToInt (quadT_Pos.y) == 1 && Mathf.RoundToInt (quadT_Pos.z) == -1) {
				quadT_Correct = true;
			}

		} else if (Mathf.RoundToInt (quadT_Rot.x) == 90 && 
		           (Mathf.RoundToInt (quadT_Rot.y) == 0 || Mathf.RoundToInt (quadT_Rot.y) == 360) && 
		           (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {
			
			// Anm.: Rundungsproblem weil eigentlich -3.5
			if(Mathf.RoundToInt (quadT_Pos.x) == -1 && Mathf.RoundToInt (quadT_Pos.y) == 1 && Mathf.RoundToInt (quadT_Pos.z) == -3) {
				quadT_Correct = true;
			}
		}

		// Stimmen alle Spielobjekte?
		return (tri_Correct && quadC_Correct && quadT_Correct);
	}
}
