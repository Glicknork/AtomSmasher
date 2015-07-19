using UnityEngine;
using System.Collections;

public class Atom : MonoBehaviour {

	// the atom's colliders for different hit levels
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
			StartCoroutine("AtomHitReset");
		}
	}

	IEnumerator AtomHitReset(){
		yield return new WaitForSeconds (0.1f);
		atomHitOne = false;
	}
}