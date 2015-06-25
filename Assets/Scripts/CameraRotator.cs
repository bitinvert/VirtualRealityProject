using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

	void Update () {
		
		// Drehung der Kamera: Mit linker / rechter Pfeiltaste kann man die Kamera um die Szene herum fliegen lassen.
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 5f, 0f);
			
		} else if (Input.GetKey (KeyCode.RightArrow))
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y - 5f, 0f);
		{
		}
	}
}
