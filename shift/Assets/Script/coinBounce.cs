using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBounce : MonoBehaviour
{
	public float thrust;
	public Rigidbody rb;
	public bool coinup;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		coinup = true;
	}

	void FixedUpdate()
	{
		if (coinup == true) {
			rb.AddForce (transform.forward * -thrust);
			rb.AddForce (transform.right * thrust/5) ;
			coinup = false;
		}

	}
}