using UnityEngine;
using System.Collections;

public class collider_cello_major : MonoBehaviour {

	public church_music_master_script church_script;
	
	void OnTriggerEnter(Collider collider){
		church_script.Baroque_Cello_Major_OnClick ();
	}
}

