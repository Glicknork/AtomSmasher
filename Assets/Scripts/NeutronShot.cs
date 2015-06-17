using UnityEngine;
using System.Collections;

public class NeutronShot : MonoBehaviour {

	Vector3 mousePos;
	Rigidbody rb;
	public int force;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		}
	
	// Update is called once per frame
	void FixedUpdate () {
		mousePos = Input.mousePosition;            
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward );
		transform.rotation = rot;   
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z); 
		transform.LookAt(mousePos);

		if (Input.GetMouseButtonDown(0)) {
			rb.AddForce(transform.forward * force);

		}
	}


}
