using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	//***Singleton code
	public static GameManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}

	void OnDestroy()
	{
		if (instance == this)
			instance = null;
	}
	//***

	public const int SERIES_LENGTH = 5;
	public GameObject WinScreen, StartScreen;
	GameObject[] orbs = new GameObject[SERIES_LENGTH];
	[SerializeField] GameObject[] pedestals, orbsInOrder;
	[SerializeField] GameObject glassOrb;
	int[] randomSeries = new int[SERIES_LENGTH];

	void Start()  //randomize starting order of orbs on pedestals when game starts
	{
		StartScreen.SetActive(true);
		WinScreen.SetActive(false);
		glassOrb.SetActive(false);

		foreach(GameObject orb in orbsInOrder)
			orb.SetActive(false);
	}

	public void OnStartClick()
	{
		StartScreen.SetActive(false);
		glassOrb.SetActive(true);

		foreach(GameObject orb in orbsInOrder)
			orb.SetActive(true);

		randomSeries = CreateRandomSeries(SERIES_LENGTH);

		int i = 0;
		foreach(GameObject orb in orbsInOrder)	//Iterate through orbsInOrder
		{
			orb.transform.parent = pedestals[randomSeries[i]].transform;	//place each at corresponding random pedestal
			orb.transform.localPosition = Vector3.zero + new Vector3 (0f, 0.88f, 0f);
			i++;
		}
	}

	int[] CreateRandomSeries(int length)
	{
		int[] randomSeries = new int[length];
		bool[] openIntSlot = new bool[length];
		int i, r, x;

		for (i = 0; i < length; i++)			//initialize an array of empty booleans
			openIntSlot[i] = true;				//to keep track of which spaces in the series have already been used

		for(i = 0; i < length; i++)				//iterate through list to be randomized
		{
			r = Random.Range(0, length);		//pick a random number
			x = 0;								//Limit number of iterations in case something goes wrong
			while(!openIntSlot[r] && x < 1000)	//if that number has already been chosen
			{
				r = Random.Range(0, length);	//then pick a different number
				x++;
			}

			randomSeries[i] = r;				//when a suitable number found, save it to the series
			openIntSlot[r] = false;				//and mark that number as unavailable

			if(x == 1000)
				Debug.Log("ERROR: unable to find enough open slots to complete randomized list");
		}

		return randomSeries;
	}

	public void CheckOrder()
	{
		GameObject orb;

		for(int i = 0; i < pedestals.Length; i++)					//look at each pedestal
		{
			Debug.Log("Checking pedestal " + pedestals[i].name);

			orb = pedestals[i].transform.GetChild(1).gameObject;	//see which orb is on the pedestal
			
			if(orb != orbsInOrder[i])								//compare with orb that should be there
			{
				Debug.Log("Mismatch at " + i + ". orb placed = " + orb + ", orb needed = " + orbsInOrder[i]);
				return;												//if no match, stop checking
			}
		}

		GameOver();							//if iteration completes without finding a mismatch, game ends
	}

	void GameOver()
	{
		Debug.Log("You win!");
		WinScreen.SetActive(true);
		gameObject.GetComponent<AudioSource>().Play();
		//Show victory text and give player option to restart game
	}

	public void OnRestartClick()
	{
		WinScreen.SetActive(false);

		randomSeries = CreateRandomSeries(SERIES_LENGTH);

		int i = 0;
		foreach(GameObject orb in orbsInOrder)	//Iterate through orbsInOrder
		{
			orb.transform.parent = pedestals[randomSeries[i]].transform;	//place each at corresponding random pedestal
			orb.transform.localPosition = Vector3.zero + new Vector3 (0f, 0.88f, 0f);
			i++;
		}
	}
}
