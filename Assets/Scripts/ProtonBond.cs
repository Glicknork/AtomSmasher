using UnityEngine;
using System.Collections;

public class ProtonBond : MonoBehaviour {

	// its rigidbody
	Rigidbody rb;

	// the bonding checker object attached to the proton
	BondingChecker childBondingChecker;

	// the different positions the proton jumps to when using RandomWiggle
	float attachPositionX;
	float attachPositionY;

	// exact position the proton has started at
	Vector3 startingPos;

	// how fast it is ejected when unbonded
	public int ejectForce = 1;

	// the parent atom collider
	Atom atomCollider;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		childBondingChecker = GetComponentInChildren<BondingChecker> ();
		startingPos = transform.position;
		atomCollider = GetComponentInParent<Atom> ();
	}

	// what happens when the proton's bonding checker separates from other bonding checkers
	public void Unbonded(){
		float chanceRoll = Random.Range (0, 10);
		Vector3 dir = new Vector3 (Random.Range (-10,10), Random.Range (-10,10), transform.position.z);
			if (atomCollider.atomHitOne == true && chanceRoll > 3) {
			rb.AddForce(ejectForce * dir.normalized, ForceMode.Impulse);
			}
	}

	// the movement the proton exhibits when it is bonded to others
	public void RandomWiggle(){
			attachPositionX = Random.Range (-0.1f, 0.1f);
			attachPositionY = Random.Range (-0.1f, 0.1f);
			transform.position = startingPos + new Vector3 (attachPositionX, attachPositionY, transform.position.z);
			}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Border") {
			Destroy(gameObject);
			Debug.Log ("destroyed");
		}
	}

}
