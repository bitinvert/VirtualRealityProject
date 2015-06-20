using UnityEngine;
using System.Collections;

public class AdjustableCameraHeight : MonoBehaviour {

	public float min;
	public float max;
	public float step;

	/**
	 * Makes the Camera's height adjustable per PageUp
	 * or PageDown.
	 */
	void Update () {
		Vector3 pos = this.gameObject.transform.position;

		if (Input.GetKey (KeyCode.PageUp) && (pos.y < max)) 
		{
			pos.y += step;

		} else if (Input.GetKey (KeyCode.PageDown) && (pos.y > min)) 
		{
			pos.y -= step;
		}

		this.gameObject.transform.position = pos;
	}
}
