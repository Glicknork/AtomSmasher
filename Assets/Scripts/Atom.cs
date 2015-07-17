using UnityEngine;
using System.Collections;

public class Atom : MonoBehaviour {

	// this atom's collider
	public Collider atomColliderOne;
	public Collider atomColliderTwo;

	// a bool to determine which layer of tha atom's core has been hit
	public bool atomHitOne = false;

	// Use this for initialization
	void Start () {

	}

	// if the collider is hit, set the appropriate bool
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Neutron") {
			atomHitOne = true;
		}
	}
}