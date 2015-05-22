using UnityEngine;
using System.Collections;

public class GridSnap : MonoBehaviour {

	private GameObject[] tiles; 
	
	
	//	Vector2 Max = new Vector2(-3f, 3f);
	//	Vector2 Min = new Vector2(-1f, 1f);
	//Renderer rend;
	//GameObject grid;
	
	// Use this for initialization
	void Start () {
		//grid = GameObject.FindGameObjectWithTag("grid");
		//rend = grid.GetComponent<Renderer>();
		tiles = GameObject.FindGameObjectsWithTag("grid");
	}
	
	
	// Setzt die "Bounciness" der Würfel auf 0 beim Fallenlassen
	void FixedUpdate() {
		this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
	}
	
	public Vector3 SnapToGrid(Vector3 position) {
		Vector3 result = new Vector3(0f,1.01f,0f);
		RaycastHit hitInfo = new RaycastHit();
		
		if(Physics.Raycast (this.transform.position , -Vector3.up, out hitInfo)){
			foreach(GameObject tile in tiles){
				if(tile.name == hitInfo.collider.name){
					result.x = tile.transform.position.x;
					result.z = tile.transform.position.z;
				}
			}
		}
		return result;
	}
	
	/*
	public Vector3 SnapToGrid(Vector3 position){
		
		if(! grid){
			return position;
		}
		Vector2 gridSize = rend.material.mainTextureScale;

		//Vector3 gridPosition = grid.transform.InverseTransformPoint(position);
		Vector3 gridPosition = position;
		Debug.Log("GridPosition: " +gridPosition);
		gridPosition.x = Mathf.Round(gridPosition.x *gridSize.x)/gridSize.x;
		gridPosition.z = Mathf.Round(gridPosition.z *gridSize.y)/gridSize.y;

		gridPosition.x = Mathf.Min (4f, Mathf.Max (-4f, gridPosition.x));
		gridPosition.z = Mathf.Min (4f, Mathf.Max (-4f, gridPosition.z));
		gridPosition.y = 0.53f;
		position = grid.transform.TransformPoint(gridPosition);
		position.z -= this.GetComponent<Collider>().bounds.extents.z;
		position.x -= this.GetComponent<Collider>().bounds.extents.x;
		Debug.Log (""+position.ToString());
		return position;
	}*/
	

}
