using UnityEngine;
using System.Collections;

public class ObjectInformation : MonoBehaviour {

	public Vector3 globalPos;

	public Rigidbody joint;

	// Use this for initialization
	void Start () {
		this.globalPos = this.transform.position;
		Debug.Log(globalPos);
	}
}
