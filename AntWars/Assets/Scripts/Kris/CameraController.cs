using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject CameraFollows;
	private Vector3 offsetVector;
	
	void Start ()
	{
		offsetVector = this.transform.position;
	}
	
	void Update ()
	{
		//Update camera position:
		//Into the camera's transform position,
		//Take the position of the GameObject you are tracking,
		//And add the modified offset vector.
		this.transform.position = CameraFollows.transform.position + offsetVector;
		
		//Zoom by 10%.
		if (Input.GetKey(KeyCode.I))
		{	 
			offsetVector = offsetVector + Vector3.Scale(offsetVector, new Vector3(0.1f, 0.1f, 0.1f) * -1);
		}
		if (Input.GetKey(KeyCode.K))
		{
			offsetVector = offsetVector + Vector3.Scale(offsetVector, new Vector3(0.1f, 0.1f, 0.1f));
		}
		//Rotate about the y axis.
		if (Input.GetKey (KeyCode.J)) 
		{
			offsetVector = Quaternion.Euler(0, -2, 0) * offsetVector;
		}
		if (Input.GetKey (KeyCode.L)) 
		{
			offsetVector = Quaternion.Euler(0, 2, 0) * offsetVector;
		}
		//Adjust camera vertically.
		if (Input.GetKey (KeyCode.U)) 
		{
			offsetVector = offsetVector + Vector3.up ;
		}
		if (Input.GetKey (KeyCode.O)) 
		{
			offsetVector = offsetVector + Vector3.down ;
			if (offsetVector.y < CameraFollows.transform.position.y)
			{
				offsetVector.y = CameraFollows.transform.position.y;
			}
		}
	}
}
