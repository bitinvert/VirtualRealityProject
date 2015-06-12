using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	//public btnAct btnAct;			// Referenz zu GameObject mit auszuführenden Funktionen
	Transform buttonTrans;			// Transform-Knoten des Buttons selbst
	Vector3 buttonPos;				// speichert Anfangsposition des Buttons
	public float returnSpeed;		// bestimmt, wie schnell der Button zur Anfangsposition zurückkehrt
	public float btnTriggerDelta;	// bestimmt, wie weit Button in Y-Richtung verschoben werden muss, damit der Button als gedrückt gilt
	bool buttonPressed = false;

	// Use this for initialization
	void Start () {
		buttonTrans = GetComponent<Transform> ();
		buttonPos = buttonTrans.position;
		returnSpeed = 10.0f;
		btnTriggerDelta = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		// schiebt Button wieder nach oben
		if (buttonTrans.position.z < buttonPos.z) 
		{
			GetComponent<Rigidbody>().AddForce(0.0f, 0.0f, returnSpeed);
		}
		// stoppt Button-Bewegung nach oben
		else if (buttonTrans.position.z > buttonPos.z)
		{
			buttonTrans.position = buttonPos;
			buttonPressed = false;
		}
		// ruft Skript mit zum Button gehöriger Aktion auf, wenn Button weit genug nach unten gedrückt wurde
		if ( (buttonTrans.position.z <= (buttonPos.z - btnTriggerDelta) ) && (buttonPressed == false) )
		{
			buttonPressed = true;
			//btnAct.btnAction(gameObject.name);
		}
	}
}
