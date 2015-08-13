using UnityEngine;
using System.Collections;

public class UnityNetwork : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//Creats the startup GUI
	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server"))
			{
				LaunchServer();
			}

			if (GUI.Button (new Rect (400, 100, 250, 100), "Join Server"))
			{
				ConnectToServer();
			}
		}
	}

	void LaunchServer ()
	{
		bool useNat = !Network.HavePublicAddress ();
		Network.InitializeServer (2, 25000, useNat);
		MasterServer.RegisterHost ("Unity-OKC", "GameRoom", "This is a comment.");
		Debug.Log ("Server created.");
	}

	void ConnectToServer() 
	{
		Network.Connect("127.0.0.1", 25000);
		Debug.Log ("Joined the server.");
	}
}