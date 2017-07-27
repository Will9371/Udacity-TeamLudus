using UnityEngine;
using System.Collections;

public class collider_stop_church_music : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Stop_OnClick ();
	}
}

