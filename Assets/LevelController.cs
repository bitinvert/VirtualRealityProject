using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	GameObject triCorner;
	GameObject quadCorner;
	GameObject quadTee;
	GameObject firework;


	public GameObject winText;
	public Text timerText;

	void Start() {
		triCorner = GameObject.FindGameObjectWithTag("TriCorner");
		quadCorner = GameObject.FindGameObjectWithTag("QuadCorner");
		quadTee = GameObject.FindGameObjectWithTag("QuadTee");

		firework = GameObject.FindGameObjectWithTag("Fire");
		firework.GetComponent<ParticleSystem>().Stop();
	}

	/**
	 * Lade die Szene neu, im Falle von Fehlern etc.
	 */
	public void ResetScene() {
		Application.LoadLevel(Application.loadedLevelName);
	}

	// Die aktuelle Timerzeit
	private float timerTime;

	/**
	 * Starte den Timer und setze ihn zu Beginn auf 0.
	 */
	public void TimerStart() {
		timerTime = 0.0f;

		StartCoroutine("UpdateTimer");
	}

	/**
	 * Füge jedes Frame die vergangene Zeit zu dem Timer hinzu.
	 */
	IEnumerator UpdateTimer() {
		while(true) {
			timerText.text = "Timer: " + timerTime.ToString();
			timerTime = timerTime + Time.deltaTime;
			yield return null;
		}
		yield return null;
	}

	/**
	 * Halte den Timer an.
	 */ 
	public void TimerStop() {
		StopCoroutine("UpdateTimer");
	}

	/**
	 * Prüfe die beiden möglichen Anordnungen für Spielobjekte für das Level.
	 * Zeige entsprechend eine Meldung für den Spieler an!
	 **/
	public void Check() {
		if (CheckFirstOption () || CheckSecondOption ()) {
			firework.GetComponent<ParticleSystem>().Play();
			winText.SetActive(true);
		}
	}

	bool InIntervall(float z, float num) {
		float delta = 0.4f;
		
		return ((z > (num - delta)) && (z < (num + delta)));
	}

	// Anm.: Bei einem Winkel == 0° muss auch auf 360° geprüft werden, wegen Rundungsproblemen!
	// Anm2.: Die z-Koordinate wird hier auf einen Bereich geprüft, da Unity Rundungsprobleme verursacht!
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

			if(Mathf.RoundToInt (tri_Pos.x) == 2 && Mathf.RoundToInt (tri_Pos.y) == 1 && InIntervall(tri_Pos.z, -1.5f)) {
				tri_Correct = true;
			}

		} else if (Mathf.RoundToInt(tri_Rot.x) == 90 && 
		           Mathf.RoundToInt (tri_Rot.y) == 90 && 
		           (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) { 

			if(Mathf.RoundToInt (tri_Pos.x) == 1 && Mathf.RoundToInt (tri_Pos.y) == 1 &&  InIntervall(tri_Pos.z, -0.5f)) {
				tri_Correct = true;
			}
		}

		Debug.Log ("1TriPosition: " + tri_Pos);

		// Check QuadCorner  -- okay
		Vector3 quadC_Rot = quadCorner.transform.eulerAngles;
		Vector3 quadC_Pos = quadCorner.transform.position;

		if (Mathf.RoundToInt (quadC_Rot.x) == 90 && 
			(Mathf.RoundToInt (quadC_Rot.y) == 0 || Mathf.RoundToInt (quadC_Rot.y) == 360) && 
			(Mathf.RoundToInt (quadC_Rot.z) == 0 || Mathf.RoundToInt (quadC_Rot.z) == 360)) {

			if (Mathf.RoundToInt (quadC_Pos.x) == -1 && Mathf.RoundToInt (quadC_Pos.y) == 1 && InIntervall(quadC_Pos.z, -1.5f)) {
				quadC_Correct = true;
			}
		}

		Debug.Log ("1QuadC_Pos: " + quadC_Pos);

		// Check QuadTee -- okay
		Vector3 quadT_Rot = quadTee.transform.eulerAngles;
		Vector3 quadT_Pos = quadTee.transform.position;

		if (Mathf.RoundToInt (quadT_Rot.x) == 270 &&
			Mathf.RoundToInt (quadT_Rot.y) == 270 &&
			(Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {

			if(Mathf.RoundToInt (quadT_Pos.x) == -2 && Mathf.RoundToInt (quadT_Pos.y) == 1 && InIntervall(quadT_Pos.z, -2.5f)) {
				quadT_Correct = true;
			}

		} else if (Mathf.RoundToInt (quadT_Rot.x) == 90 && 
		           Mathf.RoundToInt (quadT_Rot.y) == 270 && 
		           (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {
		
			if(Mathf.RoundToInt (quadT_Pos.x) == 0 && Mathf.RoundToInt (quadT_Pos.y) == 1 && InIntervall(quadT_Pos.z, -2.5f)) {
				quadT_Correct = true;
			}
		}

		Debug.Log ("1QuadT_Pos: " + quadT_Pos);

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

			if(Mathf.RoundToInt (tri_Pos.x) == 1 && Mathf.RoundToInt (tri_Pos.y) == 1 && InIntervall (tri_Pos.z, -0.5f)) {
				tri_Correct = true;
			}
			
		} else if (Mathf.RoundToInt(tri_Rot.x) == 90 && 
		           Mathf.RoundToInt (tri_Rot.y) == 90 && 
		           (Mathf.RoundToInt (tri_Rot.z) == 0 || Mathf.RoundToInt (tri_Rot.z) == 360)) { 

			if(Mathf.RoundToInt (tri_Pos.x) == 0 && Mathf.RoundToInt (tri_Pos.y) == 1 && InIntervall (tri_Pos.z, 0.5f)) {
				tri_Correct = true;
			}
		}

		Debug.Log ("2TriPosition: " + tri_Pos);
		
		// Check QuadCorner  -- okay
		Vector3 quadC_Rot = quadCorner.transform.eulerAngles;
		Vector3 quadC_Pos = quadCorner.transform.position;
		
		if (Mathf.RoundToInt (quadC_Rot.x) == 270 && 
		    Mathf.RoundToInt (quadC_Rot.y) == 270 && 
		    (Mathf.RoundToInt (quadC_Rot.z) == 0 || Mathf.RoundToInt (quadC_Rot.z) == 360)) {

			if(Mathf.RoundToInt (quadC_Pos.x) == 0 && Mathf.RoundToInt (quadC_Pos.y) == 1 && InIntervall (quadC_Pos.z, -2.5f)) {
				quadC_Correct = true;
			}
		}

		Debug.Log ("2QuadC_Pos: " + quadC_Pos);
				
		// Check QuadTee  -- okay
		Vector3 quadT_Rot = quadTee.transform.eulerAngles;
		Vector3 quadT_Pos = quadTee.transform.position;
		
		if (Mathf.RoundToInt (quadT_Rot.x) == 270 &&
		    (Mathf.RoundToInt (quadT_Rot.y) == 0 || Mathf.RoundToInt (quadT_Rot.y) == 360) &&
		    (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {

			if(Mathf.RoundToInt (quadT_Pos.x) == -1 && Mathf.RoundToInt (quadT_Pos.y) == 1 && InIntervall (quadT_Pos.z, -1.5f)) {
				quadT_Correct = true;
			}

		} else if (Mathf.RoundToInt (quadT_Rot.x) == 90 && 
		           (Mathf.RoundToInt (quadT_Rot.y) == 0 || Mathf.RoundToInt (quadT_Rot.y) == 360) && 
		           (Mathf.RoundToInt (quadT_Rot.z) == 0 || Mathf.RoundToInt (quadT_Rot.z) == 360)) {

			if(Mathf.RoundToInt (quadT_Pos.x) == -1 && Mathf.RoundToInt (quadT_Pos.y) == 1 && InIntervall (quadT_Pos.z, -3.5f)) {
				quadT_Correct = true;
			}
		}

		Debug.Log ("2QuadT_Pos: " + quadT_Pos);

		// Stimmen alle Spielobjekte?
		return (tri_Correct && quadC_Correct && quadT_Correct);
	}
}
