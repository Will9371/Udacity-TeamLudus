using UnityEngine;
using System.Collections;

public class collider_baroque_organ_major : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Baroque_Organ_Major_OnClick ();
	}
}

