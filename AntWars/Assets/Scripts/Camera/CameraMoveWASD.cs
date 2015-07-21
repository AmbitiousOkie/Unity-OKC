using UnityEngine;
using System.Collections;

public class CameraMoveWASD : MonoBehaviour {

	 public float speed;
	void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");	
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
			
			transform.Translate(movement * speed * Time.deltaTime);
		}
}