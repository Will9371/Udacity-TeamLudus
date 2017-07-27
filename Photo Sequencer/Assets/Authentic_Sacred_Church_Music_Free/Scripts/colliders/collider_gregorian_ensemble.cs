using UnityEngine;
using System.Collections;

public class collider_gregorian_ensemble : MonoBehaviour {

	// Use this for initialization
	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Gregorian_music_OnClick ();
	}
}
