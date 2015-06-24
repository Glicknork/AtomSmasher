using UnityEngine;
using System.Collections;

public class NeutronShot : MonoBehaviour {

	Rigidbody rb;
	public int force;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		}
	
	// Update is called once per frame
	void Update () {
	        if (Input.GetMouseButtonDown(0)) {
			Launch ();
			}
	}

	void Launch(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 dir = new Vector3 (mousePos.x, mousePos.y, transform.position.z) - transform.position;
		rb.AddForce(force * dir.normalized, ForceMode.Impulse);

	}


}
