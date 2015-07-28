using UnityEngine;
using System.Collections;

public class moveToEnemy : MonoBehaviour {

	public Transform rightTarget;
	public Transform leftTarget;
	Transform target;
	Vector3 destination;
	NavMeshAgent agent;
	
	void Start () {
		// Cache agent component and destination
		agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;

		if (this.gameObject.tag == "rightTeam") {
			target = rightTarget;
		} else {
			target = leftTarget;
		}

	}
	
	void Update () {
		// Update destination if the target moves one unit
		if (Vector3.Distance (destination, target.position) > 1.0f) {
			destination = target.position;
			agent.destination = destination;
		}
	}
}