using UnityEngine;
using System.Collections;

public class IgnoreButtonCollision : MonoBehaviour {

	/**
	 * Disable Collision between the MenuButtons (Layer 8)
	 * and the GamingPieces (Layer 9) in order to prevent
	 * unintentional "Button-Pushing".
	 * Also: Disable Collision between MenuButtons (Layer 8)
	 * and the ColliderWall in Front of the Camera (Layer 10)
	 * in order to prevent the Menu Button being stuck behind
	 * the ColliderWall if the player is successful in
	 * pushing it through (which would be a bug).
	 */
	void Start () {
		Physics.IgnoreLayerCollision (8, 9);
		Physics.IgnoreLayerCollision (8, 10);
	}
	

}
