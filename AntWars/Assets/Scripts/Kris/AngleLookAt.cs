using UnityEngine;
using System.Collections;

public class AngleLookAt : MonoBehaviour {
	public GameObject CameraFollows;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt(CameraFollows.transform.position);
	}
}