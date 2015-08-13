using UnityEngine;
using System.Collections;

public class FaceFollow : MonoBehaviour {
	
	public GameObject CameraPosition;
	public GameObject FaceFollows;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = FaceFollows.transform.position;
		
	}
	void LateUpdate () {
		//To know where to "LookAt" based on a position, the position should already be known! Hence "LateUpdate".
		//this.transform.LookAt(CameraPosition.transform.position); //Faces away if Quad, making Quad invisible. 
		//this.transform.rotation = Quaternion.LookRotation(transform.position - target.position); //Could not get syntax to work.



		this.transform.LookAt (2 * this.transform.position - CameraPosition.transform.position);

	}
}