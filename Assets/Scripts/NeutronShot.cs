using UnityEngine;
using System.Collections;

public class NeutronShot : MonoBehaviour {

	// the neutron's rigidbody
	Rigidbody rb;

	// the force it is fired at
	public int force;

	AudioSource source;

	Vector3 startingPos;

	public AudioClip launchSound;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();
		startingPos = transform.position;
		}

	void Update () {
	        if (Input.GetMouseButtonDown(0)) {
			Launch ();
			}
	}

	// fuction to control firing the neutron towards the mouse pointer
	void Launch(){
		source.PlayOneShot (launchSound, 1f);
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 dir = new Vector3 (mousePos.x, mousePos.y, transform.position.z) - transform.position;
		rb.AddForce(force * dir.normalized, ForceMode.Impulse);

	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Border") {
			transform.position = startingPos;
			rb.velocity = new Vector3(0,0,0);
		}
	}


}
