#pragma strict

 private var targetPosition : Vector3;
 
 private var directionNavAgent : NavMeshAgent;
 
 function Start() {
     MoveToClosest();
 }
 
 function MoveToClosest()
 { directionNavAgent = GetComponent(NavMeshAgent);
 FindClosestTarget();
 directionNavAgent.destination = targetPosition;
 }
 
 
 
 function FindClosestTarget () : GameObject {
 
 var gos : GameObject[];
 gos = GameObject.FindGameObjectsWithTag("Food"); 
 var closest : GameObject; 
 var distance = Mathf.Infinity; 
 var position = transform.position; 
 
 for (var go : GameObject in gos)  { 
     var diff = (go.transform.position - position);
     var curDistance = diff.sqrMagnitude; 
     if (curDistance < distance) { 
         closest = go; 
         distance = curDistance; 
     } 
 } 
 targetPosition = closest.transform.position;  
 return closest; 
 }