using UnityEngine;
using System.Collections;

public class lookAtEnemy : MonoBehaviour {

// The target marker.
	public Transform enemy;
	
	// Speed in units per sec.
	public float soldierSpeed;

	
	
	void Update () {


		transform.LookAt (enemy);


		// The step size is equal to speed times frame time.
		var step = soldierSpeed * Time.deltaTime;
		
		// Move our position a step closer to the target.
		transform.position = Vector3.MoveTowards(transform.position, enemy.position, step);


	}
}