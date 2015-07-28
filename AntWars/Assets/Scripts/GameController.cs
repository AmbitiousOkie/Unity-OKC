using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] SoldierArray;
    //public Vector3 rightSideValues; //Allows you to modify the hazard's position when it is instantiated in the unity editor.
    //public Vector3 leftSideValues;
    public Transform rightSpawner;
    public Transform leftSpawner;
    public int antCount;

    public float spawnWait; //after the Spanwer has completed its loop, this is how long it waits before starting again.
    public float startWait; //this causes the initial spawn to wait a set amount of seconds before starting.
    public float waiveWait; //this float makes the coroutine Spawner's while loop to wait until it starts again.
     
    private bool pause;
    private bool start = true; //Do not initalize this variable in start or else when you hit resume, it will bring up the starting menu.

    void Start()
    {
        pause = false;
        //InvokeRepeating("Spawn", spawnTime, spawnTime); //"Method to be invoked", amount of time to wait before invoking the method, amount of time to wait before repeating
        StartCoroutine(Spawner());
        //DontDestroyOnLoad(gameObject);
    }
    public void FixedUpdate()           
    {
             if (Input.GetKeyDown(KeyCode.Escape))
             {
                 pause = true;      //This boolean causes the OnGUI() method to open the pause menu.
             }
    }

    IEnumerator Spawner()             
    {
        yield return new WaitForSeconds(startWait);
        while(pause != true && start == false)
            {
                if (pause == true) { break; }
                for (int i = 0; i< antCount; i++)
                {
					GameObject SoldierPrefab = SoldierArray[Random.Range(0, SoldierArray.Length)];
                    //Vector3 spawnPosition = new Vector3(Random.Range(-rightSideValues.x, rightSideValues.x), rightSideValues.y, rightSideValues.z);         //inserts the values from the unity editor into the hazard's spawnPosition.
                    //Vector3 leftSidePosition = new Vector3(Random.Range(-leftSideValues.x, leftSideValues.x), leftSideValues.y, leftSideValues.z);
                    
                    //Quaternion spawnRotation = Quaternion.identity;     //Means our Ants will have no new rotation.
                    //Quaternion leftSideRotation = Quaternion.Euler(0,180,0);
					GameObject rightSoldier = (GameObject)Instantiate(SoldierPrefab, rightSpawner.position, rightSpawner.rotation);
					GameObject leftSoldier = (GameObject)Instantiate(SoldierPrefab, leftSpawner.position, leftSpawner.rotation);
					
					rightSoldier.gameObject.tag = "rightTeam"; 				//Sets the teams
					leftSoldier.gameObject.tag = "leftTeam";

                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waiveWait);
            }
    }
    
    void OnGUI()
    {
        if (start == true) 
        {
            if (GUI.Button(new Rect(800, 100, 150, 30), "Begin"))
            {
                start = false;
            }
            if (GUI.Button(new Rect(800, 150, 150, 30), "Main Menu"))
            {
                Application.LoadLevel("Main_Menu");
            }
        }
        if (pause == true)
        {
            if (GUI.Button(new Rect(800, 100, 150, 30), "Resume"))
            {
                Start();    //When you hit the "Resume", button it calls the Start() method which causes the bool pause to be false, and calles the coroutine Spawner() to pick up where it left off.
            }
            if (GUI.Button(new Rect(800, 150, 150, 30), "Restart"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(800, 200, 150, 30), "Main Menu"))
            {
                Application.LoadLevel("Main_Menu");
            }
        }
    }
}