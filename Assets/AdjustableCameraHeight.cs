using UnityEngine;
using System.Collections;

public class AdjustableCameraHeight : MonoBehaviour {
	
	/**
	 * Makes the Camera's height adjustable per PageUp
	 * or PageDown.
	 */
	void Update () {
		Vector3 pos = this.gameObject.transform.position;

		if (Input.GetKey (KeyCode.PageUp) && (pos.y < 8f)) 
		{
			pos.y += 0.1f;

		} else if (Input.GetKey (KeyCode.PageDown) && (pos.y > 5f)) 
		{
			pos.y -= 0.1f;
		}

		this.gameObject.transform.position = pos;
	}
}
