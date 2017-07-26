using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to each image orb
public class OrbSelect : MonoBehaviour 
{
	static bool swapEmpty;
	public bool isOnSwap;
	public GameObject swapPedestal, glassOrb;
	GameObject orbClicked;
	public Transform myPedestalLoc; 
	Vector3 newGlassLoc;

	void Start()
	{
		isOnSwap = false;		//true for an orb that is on swap pedestal
		swapEmpty = true;
		swapPedestal = TransitionManager.instance.swapPedestal;
		glassOrb = TransitionManager.instance.glassOrb;
	}

	public void OnPointerClick()
	{
		orbClicked = this.gameObject;
		if (transform.parent.gameObject != swapPedestal)
		{											
			myPedestalLoc = transform.parent;

			swapEmpty = true;		//assume swap pedestal is empty until iteration finds one
			foreach (GameObject orb in TransitionManager.instance.imageOrbs)	//look through each orb
			{
				if (orb != orbClicked && orb.GetComponent<OrbSelect>().isOnSwap)	//if an orb (but not the one selected) is on the swapPedestal
				{
					swapEmpty = false;
					orb.GetComponent<OrbSelect>().MoveToPedestal(orb, orbClicked, myPedestalLoc);//move that orb to the selected regular pedestal
				}
			}
			if(gameObject != glassOrb)
				MoveToSwap();
		}
		else  	//otherwise, transition to image view mode
			TransitionManager.instance.OnOrbSelect(orbClicked);
	}

	void MoveToSwap()
	{
		if(swapEmpty)
		{
			glassOrb.transform.parent = myPedestalLoc;
			glassOrb.transform.localPosition = Vector3.zero + new Vector3 (0f, .88f, 0f);
		}

		transform.parent = swapPedestal.transform;					  //move the selected image orb to the swap pedestal
		transform.localPosition = Vector3.zero + new Vector3 (0f, 1.15f, 0f);
		isOnSwap = true;
	}

	void MoveToPedestal(GameObject orb, GameObject orbClicked, Transform myPedestalLoc)
	{
		if(orbClicked == glassOrb)
		{
			Vector3 newGlassLoc = new Vector3 (transform.position.x, -20f, 3f);	//move the glass orb below the viewable area
			glassOrb.transform.position = newGlassLoc;
			glassOrb.transform.parent = null;			//remove from parent so it does not interfere with CheckOrder method in MainGameManager
		}
			
		orb.transform.parent = myPedestalLoc;						//move the orb that was on the Swap Pedestal to the selected pedestal
		transform.localPosition = Vector3.zero + new Vector3 (0f, 0.88f, 0f);
		isOnSwap = false;

		GameManager.instance.CheckOrder();
	}
}
