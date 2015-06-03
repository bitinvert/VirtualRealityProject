using UnityEngine;
using System.Collections;

public class GridSnap : MonoBehaviour {

	private GameObject[] tiles; 
	private ObjectInformation obj;
		
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag("grid");
		obj = GetComponent<ObjectInformation>();
	}
		
	// Setzt die "Bounciness" der Würfel auf 0 beim Fallenlassen
	void FixedUpdate() {
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
	
	public Vector3 SnapToGrid(Vector3 position, Vector3 rotation) {
		Vector3 result = obj.globalPos;//new Vector3(0f,1.01f,0f);
		RaycastHit hitInfo = new RaycastHit();
		
		if(Physics.Raycast (this.transform.position , -Vector3.up, out hitInfo)){
			foreach(GameObject tile in tiles){

				/**
				 * Wenn das Spielobjekt über dem Spielfeld (tile) losgelassen wird,
				 * raste dieses an der Position des spezifischen Tiles ein.
				 * Ansonsten setze das Spielobjekt an seine Ursprungsposition zurück
				 * und Verbinde wieder den Joint.
				 **/
				if(tile.name == hitInfo.collider.name){
					result.x = tile.transform.position.x;
					result.z = tile.transform.position.z;

					result.y = setY(rotation);
	
				} else {
					
					//result = obj.globalPos;
					/*FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
					joint.connectedBody = obj.joint;
					joint.breakForce = 5000;*/
				}
			}
		} 
		return result;
	}

	// Anmerkung: WICHTIG!!! x und z auf INTEGER casten!!! Nicht fragen warum!!!! Klingt komisch, Is aber einfach so!
	//UND KEINE DISKUSSIONEN!!!!!!!!!!!!!!!!!
	public float setY(Vector3 rotation) {
		Debug.Log(rotation);

		int x = (int)rotation.x;
		int z = (int)rotation.z;

		if(this.tag.Equals("QuadCorner")){
			if((x == 180 && z == 0) || (x == 0 && z == 180)) {
				return 3.01f;
			} else if((x == 0 && z == 270) || (x == 180 && z == 90)) {
				return 2.01f;
			}
		}

		if(this.tag.Equals("QuadTee")) {
			if((x == 180 && z == 0) || (x == 0 && z ==  180)) {
				return 3.01f;
			} else if ((x == 180 && z == 270) || (x == 0 && z == 90)) {
				return 2.01f;
			}
		}

		if(this.tag.Equals("Duo")) {
			if((x == 0 && z == 180) || (x == 180 && z == 0)) {
				return 2.01f;
			}
		}

		if(this.tag.Equals("TriCorner")) {
			if((x == 0 && (z == 180 || z == 270)) || (x == 180 && (z == 0 || z == 90))) {
				return 2.01f;
			}
		}

		return 1.01f;
	}

	public Vector3 SnapRotation(Vector3 rotation) {
		return new Vector3(
			SetRightAngle((int)rotation.x),
			SetRightAngle((int)rotation.y),
			SetRightAngle((int)rotation.z));
	}

	public float SetRightAngle(int val) {

		if (0 <= val && val <= 45) return 0f; 
		if (45 < val && val <= 90) return 90f; 
		if (90 < val && val <= 135) return 90f;
		if (135 < val && val <= 180) return 180f;
		if (180 < val && val <= 225) return 180f; 
		if (225 < val && val <= 270) return 270f; 
		if (270 < val && val <= 315) return 270f;
		if (315 < val && val <= 360) return 0f;
		return 0f;
	}
	
}
