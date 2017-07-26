using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour 
{
	//***Singleton code
	public static TransitionManager instance;

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

	public GameObject MainSceneObjects, ReverseSphere;
	public GameObject swapPedestal, glassOrb;
	public GameObject[] imageOrbs;
	public Material[] image360;

	public void OnOrbSelect(GameObject currSelectedOrb)	//transition from main scene to image scene
	{
		MainSceneObjects.SetActive(false);
		ReverseSphere.SetActive(true);
		ReverseSphere.GetComponent<Renderer>().material = currSelectedOrb.GetComponent<Renderer>().material;
		//*Better: 	Move and expand the image orb until it envelops the player
	}

	public void OnOrbExit()
	{
		MainSceneObjects.SetActive(true);
		ReverseSphere.SetActive(false);
	}
}
