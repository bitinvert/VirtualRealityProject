﻿/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/
/*Modified*/
using UnityEngine;
using System.Collections;

public class GrabbableObject : MonoBehaviour {
	
	public GridSnap gs;
	
	
	public bool useAxisAlignment = false;
	public Vector3 rightHandAxis;
	public Vector3 objectAxis;
	
	public bool rotateQuickly = true;
	public bool centerGrabbedObject = false;
	
	public Rigidbody breakableJoint;
	public float breakForce;
	public float breakTorque;

	public float maxSnapHeight = 2.3f;
	
	protected bool grabbed_ = false;
	protected bool hovered_ = false;
	
	public bool IsHovered() {
		return hovered_;
	}
	
	public bool IsGrabbed() {
		return grabbed_;
	}
	
	public virtual void OnStartHover() {
		hovered_ = true;
	}
	
	public virtual void OnStopHover() {
		hovered_ = false;
	}
	
	public virtual void OnGrab() {
		grabbed_ = true;
		hovered_ = false;
		
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = breakForce;
				breakJoint.breakTorque = breakTorque;
			}
		}
		
	}
	
	public virtual void OnRelease() {
		grabbed_ = false;
		
		if (breakableJoint != null) {
			Joint breakJoint = breakableJoint.GetComponent<Joint>();
			if (breakJoint != null) {
				breakJoint.breakForce = Mathf.Infinity;
				breakJoint.breakTorque = Mathf.Infinity;
				
			}
		}

		MeshRenderer m = this.GetComponent<MeshRenderer>();
		Debug.Log(m.bounds.size.x * transform.localScale.x);

		/*
		 * Grid-Snap soll erst wirken, wenn die Form schon relativ nah am Boden ist.
		 * Ansonsten Bewegung einfrieren
		 * */
		if (transform.position.y < maxSnapHeight)
		{
			this.transform.eulerAngles = gs.SnapRotation(this.transform.eulerAngles);
			this.transform.position = gs.SnapToGrid(this.transform.position, this.transform.eulerAngles);
		}
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}
	
}
