using UnityEngine;
using System.Collections;

public class BondingChecker : MonoBehaviour {

	// the parent of this bonding checker
	public ProtonBond parent;

	// the parent atom collider
	Atom atomCollider;

	void Start(){
		parent = GetComponentInParent<ProtonBond> ();
		atomCollider = GetComponentInParent<Atom> ();
	}

	// checks if this object is colliding with another checker, if so it activates RandomWiggle in its parent
	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "BondingChecker" && atomCollider.atomHitOne == false) {
			parent.RandomWiggle();
		}
	}

	// when this bonder exits collision with another checker, activates the Unbonded function in its parent
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "BondingChecker")
			parent.Unbonded ();
	}

}
