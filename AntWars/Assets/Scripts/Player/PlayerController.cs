using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;

	private int count;

	
	void start ()		
	{
		count = 0;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");	
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)	
	{
		
		if (other.gameObject.tag == "PickUp") 
			
		{

			Destroy(other.gameObject);
			//other.gameObject.SetActive(false);	
			count += 100;
			
		}
		
	}
	


}
