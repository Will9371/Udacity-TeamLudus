using UnityEngine;
using System.Collections;

public class collider_baroque_choir : MonoBehaviour {

	public church_music_master_script church_script;

	void OnTriggerEnter(Collider collider){
		church_script.Choir_minor_OnClick ();
	}
}
