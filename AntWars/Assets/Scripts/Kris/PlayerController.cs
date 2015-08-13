using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public GameObject MainCamera;
	private Vector3 cameraVector;
	private Quaternion offsetAngle;
	private Vector3 movementAdjusted;
	public float jumpMax;
	public GameObject ControlledCreature;

	void Update ()
	{
	}
	
	void Start ()
	{
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		cameraVector = MainCamera.transform.position - ControlledCreature.transform.position;
		Vector3 cameraVectorFlatVertical = new Vector3 (cameraVector.x, 0, cameraVector.z);
		Vector3 cameraVectorFlatHorizont;
		cameraVectorFlatHorizont = Quaternion.Euler(0, 90, 0) * cameraVectorFlatVertical;
		ControlledCreature.GetComponent<Rigidbody>().AddForce(moveVertical * -cameraVectorFlatVertical.normalized * speed * Time.deltaTime);
		ControlledCreature.GetComponent<Rigidbody>().AddForce(moveHorizontal * -cameraVectorFlatHorizont.normalized * speed * Time.deltaTime);

		if (Input.GetButton ("Jump")) 
		{
			ControlledCreature.GetComponent<Rigidbody>().AddForce(Vector3.up * speed * Time.deltaTime);
		}
	}
}
