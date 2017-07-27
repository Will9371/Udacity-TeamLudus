using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
	[SerializeField] church_music_master_script ChurchMusic;

	void Start () 
	{
		ChurchMusic.choir_minor = true;
		ChurchMusic.start = true;
		ChurchMusic.choir_minor_isPlaying = true;
	}
}
