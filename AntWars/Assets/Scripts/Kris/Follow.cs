using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public GameObject Follows;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Follows.transform.position;
		
	}
}
