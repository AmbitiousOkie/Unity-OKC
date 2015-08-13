using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	
	public Transform target;  //gives the camera a target to follow
	
	public float smoothing = 5f;  //variable we'll use to give the camera a small bit of lag to make it look smoother and not so jumpy.
	
	
	Vector3 offset;
	
	
	void Start()
		
	{
		
		offset = transform.position - target.position;
		
	}
	
	
	void FixedUpdate() //using FixedUpdate instead of Update to follow an object.
		
	{
		
		Vector3 targetCamPos = target.position + offset;
		
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime); //Lerps moves between two positions smoothly
		
	}
	
}

