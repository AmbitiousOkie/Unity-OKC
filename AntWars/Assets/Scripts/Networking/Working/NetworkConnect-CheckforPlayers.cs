using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private int playerCount = 0;

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
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server")) {
				LaunchServer ();
			}
			
			if (GUI.Button (new Rect (400, 100, 250, 100), "Join Server")) {
				ConnectToServer ();
			}
		} else {
			if (Network.isServer)
			{
				GUI.Button (new Rect (100, 100, 250, 100), "You have started the server.");
			} else {
			GUI.Button (new Rect (100, 100, 250, 100), "Connected to server.");
			}
		}
	}

	void OnPlayerConnected(NetworkPlayer player)
	{	
//		if (playerCount > 0) {
//			GUI.Button (new Rect (400, 100, 250, 100), "Player " + playerCount + "connected.");
//		}
		Debug.Log ("Birches connected.");
	}

	
	void LaunchServer ()
	{
		bool useNat = !Network.HavePublicAddress ();
		Network.InitializeServer (4, 25000, useNat);
		MasterServer.RegisterHost ("Unity-OKC", "GameRoom", "This is a comment.");
		Debug.Log ("Server created.");
	}
	
	void ConnectToServer() 
	{
		Network.Connect("192.168.40.159", 25000);
		Debug.Log ("Joined the server.");
	}
}