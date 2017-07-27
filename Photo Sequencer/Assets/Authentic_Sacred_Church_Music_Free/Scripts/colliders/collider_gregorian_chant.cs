using UnityEngine;
using System.Collections;

public class collider_gregorian_chant : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Gregorian_chant_OnClick ();
	}
}
