using UnityEngine;
using System.Collections;

public class collider_dynamic_organ_medium : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Baroque_Organ_Dynamic_OnClick ();
		church_script.Intensity = 2;
	}
}
