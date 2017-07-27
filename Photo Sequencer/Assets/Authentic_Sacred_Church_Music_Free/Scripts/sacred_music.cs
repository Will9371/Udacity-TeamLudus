using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sacred_music : MonoBehaviour {
	//Choir
	Object[] AudioArray_choir_minor;
	Object[] AudioArray_choir_minor_end;
	
	public bool fade_to_distance;
	public float fadeout_speed = 7f;
	public float fadein_speed = 25f;
	
	private bool fadeOut = false;
	private float vol = 1.00f;

	//GENERAL
	public float bpm;
	public int beatsPerMeasure = 4;
	private double singleMeasureTime;
	private double delayEvent;
	private bool running = false;
	private int i;
	private bool first_run = false;
	int sample_A;
	int sample_B;
	int sample_end;
	float Intensity = 1;

	public bool fast;
	public bool normal;
	public bool slow;
	
	public bool dynamic_organ_soft_isPlaying;
	public bool dynamic_organ_medium_isPlaying;
	public bool dynamic_organ_high_isPlaying;
	public bool dynamic_organ_final_isPlaying;
	
	private AudioSource audio_soft_A;
	private AudioSource audio_soft_B;
	
	private AudioSource audio_medium_A;
	private AudioSource audio_medium_B;
	
	private AudioSource audio_high_A;
	private AudioSource audio_high_B;
	
	private AudioSource audio_final_A;
	private AudioSource audio_final_B;

	private float default_pitch = 1.0f;
	private float pitch;
	
	public bool medieval_organ_minor;
	public bool medieval_organ_major;
	public bool baroque_organ_minor;
	public bool baroque_organ_major;
	public bool dynamic_organ;
	public bool baroque_cello_minor;
	public bool baroque_cello_major;
	public bool choir_minor;
	public bool gregorian_chant;
	public bool gregorian_music;

	public bool gregorian_music_isPlaying;
	public bool medieval_organ_minor_isPlaying = false;
	public bool medieval_organ_major_isPlaying = false;
	public bool baroque_organ_minor_isPlaying = false;
	public bool baroque_organ_major_isPlaying = false;
	public bool dynamic_organ_isPlaying = false;
	public bool baroque_cello_minor_isPlaying = false;
	public bool baroque_cello_major_isPlaying = false;
	public bool choir_minor_isPlaying = false;
	public bool gregorian_chant_isPlaying = false;

	private float medieval_organ_minor_vol;
	private float medieval_organ_major_vol;
	private float baroque_organ_minor_vol;
	private float baroque_organ_major_vol;
	private float dynamic_organ_vol;
	private float  baroque_cello_minor_vol;
	private float baroque_cello_major_vol;
	private float choir_minor_vol;
	private float gregorian_chant_vol;
	private float gregorian_music_vol;
	
	public AudioSource audio_A;
	public AudioSource audio_B;
	public AudioSource audio_end;
	public AudioSource audio_demo;
	
	Object[] AudioArray_medieval_organ_minor;
	Object[] AudioArray_medieval_organ_major;
	Object[] AudioArray_baroque_organ_minor;
	Object[] AudioArray_baroque_organ_major;
	Object[] AudioArray_dynamic_organ1;
	Object[] AudioArray_dynamic_organ2;
	Object[] AudioArray_dynamic_organ3;
	Object[] AudioArray_dynamic_organ4;
	Object[] AudioArray_baroque_cello_minor;
	Object[] AudioArray_baroque_cello_major;
	Object[] AudioArray_demo;
	Object[] AudioArray_gregorian_chant;

	Object[] AudioArray_gregorian;
	Object[] AudioArray_gregorian_end;
	
	Object[] AudioArray_medieval_organ_minor_end;
	Object[] AudioArray_medieval_organ_major_end;
	Object[] AudioArray_baroque_organ_minor_end;
	Object[] AudioArray_baroque_organ_major_end;
	Object[] AudioArray_dynamic_organ_end;
	Object[] AudioArray_baroque_cello_minor_end;
	Object[] AudioArray_baroque_cello_major_end;
	
	Object[] AudioArray_gregorian_chant_end;
	
	// Use this for initialization
	void Start () {
		
		beatsPerMeasure = 4;
		int i = 0;
		first_run = false;
		audio_demo = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_soft_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_soft_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_medium_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medium_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_high_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_high_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_final_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_final_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		
		audio_end = (AudioSource)gameObject.AddComponent <AudioSource>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (choir_minor | choir_minor_isPlaying) {
			if (!medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				
				Choir_Minor_Play();
				
			}
			
		}
		
		if (medieval_organ_minor | medieval_organ_minor_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				
				Medieval_Organ_Minor_Play();
				
			}
			
		}
		
		if (medieval_organ_major | medieval_organ_major_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				
				Medieval_Organ_Major_Play();
				
			}
			
		}
		
		if (baroque_organ_major | baroque_organ_major_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				
				Baroque_Organ_Major_Play();
				
			}
			
		}
		
		if (baroque_organ_minor | baroque_organ_minor_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				
				Baroque_Organ_Minor_Play();
				
			}
			
		}
		
		if (baroque_cello_major | baroque_cello_major_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !gregorian_chant_isPlaying){
				
				Baroque_Cello_Major_Play();
				
			}
			
		}
		
		if (gregorian_chant | gregorian_chant_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying){
				
				Gregorian_Chant_Play();
				
			}
			
		}
		
		if (dynamic_organ | dynamic_organ_isPlaying) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying){
				Dynamic_Organ_Play();
				
			}
			
		}
		
		if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying 
		    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying) {

			if (Intensity == 2 & dynamic_organ) {
				if (audio_soft_A.volume > 0 | audio_soft_B.volume > 0) {
					audio_soft_A.volume -= fadeout_speed * Time.deltaTime;
					audio_soft_B.volume -= fadeout_speed * Time.deltaTime;
					Debug.Log ("The soft A volume is  " + audio_soft_A.volume + " The soft B volume is " + audio_soft_B.volume);
					
				}
				
				if (audio_medium_A.volume < 1 | audio_medium_B.volume < 1) {
					audio_medium_A.volume += fadeout_speed * Time.deltaTime;
					audio_medium_B.volume += fadeout_speed * Time.deltaTime;
					Debug.Log ("The medium A volume is  " + audio_medium_A.volume + " The medium B volume is " + audio_medium_B.volume);
				}
				
			}
			
			
			
			if (Intensity == 1 & dynamic_organ) {
				if (audio_medium_A.volume > 0 | audio_medium_B.volume > 0) {
					audio_medium_A.volume -= fadeout_speed * Time.deltaTime;
					audio_medium_B.volume -= fadeout_speed * Time.deltaTime;
					Debug.Log ("The medium A volume is  " + audio_medium_A.volume + " The medium B volume is " + audio_medium_B.volume);
				}
				
				if (audio_soft_A.volume < 1 | audio_soft_B.volume < 1) {
					audio_soft_A.volume += fadeout_speed * Time.deltaTime;
					audio_soft_B.volume += fadeout_speed * Time.deltaTime;
					Debug.Log ("The soft A volume is  " + audio_soft_A.volume + " The soft B volume is " + audio_soft_B.volume);
				}
			}
			
			
			
			
			if (Intensity == 1 | Intensity == 2 | Intensity == 3) {
				if (!dynamic_organ & dynamic_organ_isPlaying) {
					if (audio_medium_A.volume > 0 | audio_medium_B.volume > 0 | audio_soft_A.volume > 0 | audio_soft_B.volume > 0 | audio_high_A.volume > 0 | audio_high_B.volume > 0) {
						audio_medium_A.volume -= (fadeout_speed / 3) * Time.deltaTime;
						audio_medium_B.volume -= (fadeout_speed / 3) * Time.deltaTime;
						audio_soft_A.volume -= (fadeout_speed / 3) * Time.deltaTime;
						audio_soft_B.volume -= (fadeout_speed / 3) * Time.deltaTime;
						audio_high_A.volume -= (fadeout_speed / 3) * Time.deltaTime;
						audio_high_B.volume -= (fadeout_speed / 3) * Time.deltaTime;
					}
					if (audio_medium_A.volume == 0 & audio_medium_B.volume == 0 & audio_soft_A.volume == 0 & audio_soft_B.volume == 0 & audio_high_A.volume == 0 & audio_high_B.volume == 0) {
						audio_medium_A.Stop ();
						audio_medium_B.Stop ();
						audio_soft_A.Stop ();
						audio_soft_B.Stop ();
						audio_high_A.Stop ();
						audio_high_B.Stop ();
						
						audio_high_A.volume = 1.0f;
						audio_high_B.volume = 1.0f;
						
						dynamic_organ_isPlaying = false;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = false;
						i = 0;
						first_run = false;
						DetermineBPM();
					}
				}
				
				
				
			}
		}
		
	}
	
	public void Medieval_Organ_Minor_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = true;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
	}
	public void Medieval_Organ_Major_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		//bpm = 80.0F;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = true;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
		
	}
	public void Baroque_Organ_Minor_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		//bpm = 100.0F;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = true;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
	}
	public void Baroque_Organ_Major_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		//bpm = 110.0F;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = true;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
	}
	
	public void Baroque_Organ_Dynamic_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		audio_medium_A.volume = 0.0f;
		audio_medium_B.volume = 0.0f;
		audio_soft_A.volume = 0.0f;
		audio_soft_B.volume = 1.0f;
		audio_high_A.volume = 1.0f;
		audio_high_B.volume = 1.0f;
		first_run = true;
		//bpm = 140.0F;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = true;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
		
	}
	public void Baroque_Cello_Minor_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = true;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
	}
	public void Baroque_Cello_Major_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		//bpm = 90.0F;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeIn();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = true;
		choir_minor = false;
		gregorian_chant = false;
		DetermineBPM ();
		
	}
	public void Choir_minor_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = true;
		gregorian_chant = false;
		DetermineBPM ();
	}
	public void Gregorian_chant_OnClick(){
		if (!first_run) {
			singleMeasureTime = AudioSettings.dspTime + 2.0F;
			running = true;
		}
		first_run = true;
		GameObject go = GameObject.Find("Organ");
		go.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go2 = GameObject.Find("Intro");
		go2.GetComponent<FadeIntro>().FadeMe();
		
		GameObject go3 = GameObject.Find("Organ_dynamic");
		go3.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go4 = GameObject.Find("Choir");
		go4.GetComponent<FadeOrgan>().FadeMeOut();
		
		GameObject go5 = GameObject.Find("Chant");
		go5.GetComponent<FadeOrgan>().FadeMeIn();
		
		GameObject go6 = GameObject.Find("Cello");
		go6.GetComponent<FadeOrgan>().FadeMeOut();
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = true;
		DetermineBPM ();
	}
	
	public void DetermineBPM(){
		if (choir_minor) {
			if (!medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 70.0f;
			}
		}
		if (medieval_organ_minor) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 130.0f;
			}
		}
		
		if (medieval_organ_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 80.0f;
			}
		}
		
		if (baroque_organ_minor) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 100.0f;
			}
		}
		
		if (baroque_organ_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 110.0f;
			}
		}
		
		if (baroque_cello_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !gregorian_chant_isPlaying){
				bpm = 90.0f;
			}
		}
		
		if (gregorian_chant) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying){
				bpm = 90.0f;
			}
		}
		
		if (dynamic_organ) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying & !baroque_cello_minor_isPlaying
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying){
				bpm = 140.0f;
			}
		}
		
	}
	
	public void Choir_Minor_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			choir_minor_isPlaying = true;
			AudioArray_choir_minor = Resources.LoadAll("random/minor/4-4/70/choir",typeof(AudioClip));
			AudioArray_choir_minor_end = Resources.LoadAll("random/minor/4-4/70/choir_end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_choir_minor.Length);
			sample_B = Random.Range (0, AudioArray_choir_minor.Length);
			sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
			
		}
		if (i==1|i==9|i==17|i==25|i==33) {
			if (time + 1.0F > singleMeasureTime) {
				if (choir_minor){
					sample_A = Random.Range (0, AudioArray_choir_minor.Length);
					audio_A.clip = AudioArray_choir_minor[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					//audio_demo.PlayScheduled (time);
					choir_minor_isPlaying = true;
				}
				
				if (!choir_minor) {
					sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
					audio_end.clip = AudioArray_choir_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		if (i==5|i==13|i==21|i==29|i==37){
			if (time + 1.0F > singleMeasureTime) {
				if (choir_minor){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_choir_minor.Length);
					audio_B.clip = AudioArray_choir_minor[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					choir_minor_isPlaying = true;
				}
				
				if (!choir_minor) {
					sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
					audio_end.clip = AudioArray_choir_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			if (choir_minor_isPlaying){
				i +=1;
			}
			Debug.Log ("The i int equals  " + i);
			if (i==42){
				sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
				audio_end.clip = AudioArray_choir_minor_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==46){
				if (!choir_minor){
					choir_minor_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	public void Medieval_Organ_Minor_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			medieval_organ_minor_isPlaying = true;
			AudioArray_medieval_organ_minor = Resources.LoadAll("random/minor/4-4/130/organ/main",typeof(AudioClip));
			AudioArray_medieval_organ_minor_end = Resources.LoadAll("random/minor/4-4/130/organ/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_medieval_organ_minor.Length);
			sample_B = Random.Range (0, AudioArray_medieval_organ_minor.Length);
			sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
			
		}
		if (i==1|i==9|i==17|i==25|i==33) {
			if (time + 1.0F > singleMeasureTime) {
				if (medieval_organ_minor){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_medieval_organ_minor.Length);
					audio_A.clip = AudioArray_medieval_organ_minor[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					medieval_organ_minor_isPlaying = true;
				}
				
				if (!medieval_organ_minor) {
					sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
					audio_end.clip = AudioArray_medieval_organ_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		if (i==5|i==13|i==21|i==29|i==37){
			if (time + 1.0F > singleMeasureTime) {
				if (medieval_organ_minor){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_medieval_organ_minor.Length);
					audio_B.clip = AudioArray_medieval_organ_minor[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					medieval_organ_minor_isPlaying = true;
				}
				
				if (!medieval_organ_minor) {
					sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
					audio_end.clip = AudioArray_medieval_organ_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			Debug.Log ("The i int equals  " + i);
			if (medieval_organ_minor_isPlaying){
				i +=1;
			}
			
			if (i==42){
				sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
				audio_end.clip = AudioArray_medieval_organ_minor_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==46){
				if (!medieval_organ_minor){
					medieval_organ_minor_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			Debug.Log("The single measure time is " + singleMeasureTime);
		}
		
		
	}
	
	public void Medieval_Organ_Major_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			medieval_organ_major_isPlaying = true;
			AudioArray_medieval_organ_major = Resources.LoadAll("random/major/4-4/80/organ/main",typeof(AudioClip));
			AudioArray_medieval_organ_major_end = Resources.LoadAll("random/major/4-4/80/organ/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_medieval_organ_major.Length);
			sample_B = Random.Range (0, AudioArray_medieval_organ_major.Length);
			sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
			
		}
		if (i==1|i==9|i==17|i==25|i==33) {
			if (time + 1.0F > singleMeasureTime) {
				if (medieval_organ_major){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_medieval_organ_major.Length);
					audio_A.clip = AudioArray_medieval_organ_major[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					medieval_organ_major_isPlaying = true;
				}
				
				if (!medieval_organ_major) {
					sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
					audio_end.clip = AudioArray_medieval_organ_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		if (i==5|i==13|i==21|i==29|i==37){
			if (time + 1.0F > singleMeasureTime) {
				if (medieval_organ_major){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_medieval_organ_major.Length);
					audio_B.clip = AudioArray_medieval_organ_major[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					medieval_organ_major_isPlaying = true;
				}
				
				if (!medieval_organ_major) {
					sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
					audio_end.clip = AudioArray_medieval_organ_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			Debug.Log ("The i int equals  " + i);
			if (medieval_organ_major_isPlaying){
				i +=1;
			}
			
			if (i==42){
				sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
				audio_end.clip = AudioArray_medieval_organ_major_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==46){
				if (!medieval_organ_major){
					medieval_organ_major_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	public void Baroque_Organ_Minor_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			baroque_organ_minor_isPlaying = true;
			AudioArray_baroque_organ_minor = Resources.LoadAll("random/minor/4-4/100/organ/main",typeof(AudioClip));
			AudioArray_baroque_organ_minor_end = Resources.LoadAll("random/minor/4-4/100/organ/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_baroque_organ_minor.Length);
			sample_B = Random.Range (0, AudioArray_baroque_organ_minor.Length);
			sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
			
		}
		if (i==1|i==9|i==17|i==25|i==33) {
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_organ_minor){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_baroque_organ_minor.Length);
					audio_A.clip = AudioArray_baroque_organ_minor[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					baroque_organ_minor_isPlaying = true;
				}
				
				if (!baroque_organ_minor) {
					sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
					audio_end.clip = AudioArray_baroque_organ_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		if (i==5|i==13|i==21|i==29|i==37){
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_organ_minor){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_baroque_organ_minor.Length);
					audio_B.clip = AudioArray_baroque_organ_minor[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					baroque_organ_minor_isPlaying = true;
				}
				
				if (!baroque_organ_minor) {
					sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
					audio_end.clip = AudioArray_baroque_organ_minor_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			Debug.Log ("The i int equals  " + i);
			if (baroque_organ_minor_isPlaying){
				i +=1;
			}
			
			if (i==42){
				sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
				audio_end.clip = AudioArray_baroque_organ_minor_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==46){
				if (!baroque_organ_minor){
					baroque_organ_minor_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	
	public void Baroque_Organ_Major_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			baroque_organ_major_isPlaying = true;
			AudioArray_baroque_organ_major = Resources.LoadAll("random/major/4-4/110/organ/main",typeof(AudioClip));
			AudioArray_baroque_organ_major_end = Resources.LoadAll("random/major/4-4/110/organ/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_baroque_organ_major.Length);
			sample_B = Random.Range (0, AudioArray_baroque_organ_major.Length);
			sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
			
		}
		if (i==1|i==9|i==17|i==25|i==33) {
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_organ_major){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_baroque_organ_major.Length);
					audio_A.clip = AudioArray_baroque_organ_major[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					baroque_organ_major_isPlaying = true;
				}
				
				if (!baroque_organ_major) {
					sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
					audio_end.clip = AudioArray_baroque_organ_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		if (i==5|i==13|i==21|i==29|i==37){
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_organ_major){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_baroque_organ_major.Length);
					audio_B.clip = AudioArray_baroque_organ_major[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					baroque_organ_major_isPlaying = true;
				}
				
				if (!baroque_organ_major) {
					sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
					audio_end.clip = AudioArray_baroque_organ_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			Debug.Log ("The i int equals  " + i);
			if (baroque_organ_major_isPlaying){
				i +=1;
			}
			
			if (i==42){
				sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
				audio_end.clip = AudioArray_baroque_organ_major_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==46){
				if (!baroque_organ_major){
					baroque_organ_major_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	public void Baroque_Cello_Major_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			baroque_cello_major_isPlaying = true;
			AudioArray_baroque_cello_major = Resources.LoadAll("random/major/4-4/90/cello/main",typeof(AudioClip));
			AudioArray_baroque_cello_major_end = Resources.LoadAll("random/major/4-4/90/cello/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_baroque_cello_major.Length);
			sample_B = Random.Range (0, AudioArray_baroque_cello_major.Length);
			sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
			
		}
		if (i==4|i==8|i==12|i==16|i==20|i==24|i==28) {
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_cello_major){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_baroque_cello_major.Length);
					audio_A.clip = AudioArray_baroque_cello_major[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					baroque_cello_major_isPlaying = true;
				}
				
				if (!baroque_cello_major) {
					sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
					audio_end.clip = AudioArray_baroque_cello_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 33;
				}
			}
		}
		if (i==2|i==6|i==10|i==14|i==18|i==22|i==26|i==30){
			if (time + 1.0F > singleMeasureTime) {
				if (baroque_cello_major){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_baroque_cello_major.Length);
					audio_B.clip = AudioArray_baroque_cello_major[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					baroque_cello_major_isPlaying = true;
				}
				
				if (!baroque_cello_major) {
					sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
					audio_end.clip = AudioArray_baroque_cello_major_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 33;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			if (baroque_cello_major_isPlaying){
				i +=1;
			}
			Debug.Log ("The i int equals  " + i);
			if (i==33){
				sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
				audio_end.clip = AudioArray_baroque_cello_major_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==37){
				if (!baroque_cello_major){
					baroque_cello_major_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	public void Gregorian_Chant_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			gregorian_chant_isPlaying = true;
			AudioArray_gregorian_chant = Resources.LoadAll("random/minor/4-4/90/chant",typeof(AudioClip));
			AudioArray_gregorian_chant_end = Resources.LoadAll("random/minor/4-4/90/end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_gregorian_chant.Length);
			sample_B = Random.Range (0, AudioArray_gregorian_chant.Length);
			sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
			
		}
		if (i==4|i==8|i==12|i==16|i==20|i==24|i==28) {
			if (time + 1.0F > singleMeasureTime) {
				if (gregorian_chant){
					//audio_demo.PlayScheduled (time);
					sample_A = Random.Range (0, AudioArray_gregorian_chant.Length);
					audio_A.clip = AudioArray_gregorian_chant[sample_A] as AudioClip;
					audio_A.PlayScheduled (time);
					gregorian_chant_isPlaying = true;
				}
				
				if (!gregorian_chant) {
					sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
					audio_end.clip = AudioArray_gregorian_chant_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 33;
				}
			}
		}
		if (i==2|i==6|i==10|i==14|i==18|i==22|i==26|i==30){
			if (time + 1.0F > singleMeasureTime) {
				if (gregorian_chant){
					//audio_demo.PlayScheduled (time);
					sample_B = Random.Range (0, AudioArray_gregorian_chant.Length);
					audio_B.clip = AudioArray_gregorian_chant[sample_B] as AudioClip;
					audio_B.PlayScheduled(time);
					gregorian_chant_isPlaying = true;
				}
				
				if (!gregorian_chant) {
					sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
					audio_end.clip = AudioArray_gregorian_chant_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 33;
				}
			}
		}
		
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			if (gregorian_chant_isPlaying){
				i +=1;
			}
			Debug.Log ("The i int equals  " + i);
			if (i==33){
				sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
				audio_end.clip = AudioArray_gregorian_chant_end[sample_end] as AudioClip;
				audio_end.PlayScheduled (time);
			}
			
			if (i==37){
				if (!gregorian_chant){
					gregorian_chant_isPlaying = false;
					DetermineBPM ();
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
	}
	
	public void Dynamic_Organ_Play(){
		if (!running)
			return;
		double time = AudioSettings.dspTime;
		if (i == 0) {
			dynamic_organ_isPlaying = true;
			AudioArray_dynamic_organ1 = Resources.LoadAll("random/dynamic/soft",typeof(AudioClip));
			AudioArray_dynamic_organ2 = Resources.LoadAll("random/dynamic/medium",typeof(AudioClip));
			AudioArray_dynamic_organ3 = Resources.LoadAll("random/dynamic/high",typeof(AudioClip));
			AudioArray_dynamic_organ4 = Resources.LoadAll("random/dynamic/final",typeof(AudioClip));
			AudioArray_dynamic_organ_end = Resources.LoadAll("random/dynamic/final_end",typeof(AudioClip));
			
			sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
			sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
			sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
			
		}
		
		if (i == 1) {
			if (time + 1.0F > singleMeasureTime) {
				//audio_demo.PlayScheduled (time);
				if (dynamic_organ | dynamic_organ_isPlaying){
					
					if (Intensity == 1 | Intensity == 2) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = true;
						dynamic_organ_medium_isPlaying = true;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = false;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_soft_A.clip = AudioArray_dynamic_organ1[sample_A] as AudioClip;
						audio_soft_A.PlayScheduled (time);
						audio_medium_A.clip = AudioArray_dynamic_organ2[sample_A] as AudioClip;
						audio_medium_A.PlayScheduled (time);
						
					}
					if (Intensity == 3) {
						if (dynamic_organ){
							audio_high_A.volume = 1.0f;
							audio_high_B.volume = 1.0f;
						}
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = true;
						dynamic_organ_final_isPlaying = false;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_A.clip = AudioArray_dynamic_organ3[sample_A] as AudioClip;
						audio_high_A.PlayScheduled (time);						
					}
					if (Intensity == 4 & dynamic_organ) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = true;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_A.clip = AudioArray_dynamic_organ4[sample_A] as AudioClip;
						audio_high_A.PlayScheduled (time);						
					}
				}
				if (Intensity == 4 & dynamic_organ_isPlaying & !dynamic_organ) {
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
					
				}
			}
		}
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				//audio_demo.PlayScheduled (time);
				if (dynamic_organ | dynamic_organ_isPlaying){
					
					if (Intensity == 1 | Intensity == 2) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = true;
						dynamic_organ_medium_isPlaying = true;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = false;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_medium_B.clip = AudioArray_dynamic_organ2[sample_B] as AudioClip;
						audio_medium_B.PlayScheduled (time);
						
					}
					if (Intensity == 3) {
						if (dynamic_organ){
							audio_high_A.volume = 1.0f;
							audio_high_B.volume = 1.0f;
						}
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = true;
						dynamic_organ_final_isPlaying = false;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_B.clip = AudioArray_dynamic_organ3[sample_B] as AudioClip;
						audio_high_B.PlayScheduled (time);						
					}
					if (Intensity == 4 & dynamic_organ) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = true;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_B.clip = AudioArray_dynamic_organ4[sample_B] as AudioClip;
						audio_high_B.PlayScheduled (time);						
					}
				}
				if (Intensity == 4 & dynamic_organ_isPlaying & !dynamic_organ) {
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
					
				}
			}
		}
		
		if (i == 9) {
			if (time + 1.0F > singleMeasureTime) {
				//audio_demo.PlayScheduled (time);
				if (dynamic_organ | dynamic_organ_isPlaying){
					
					if (Intensity == 1 | Intensity == 2) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = true;
						dynamic_organ_medium_isPlaying = true;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = false;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_soft_B.clip = AudioArray_dynamic_organ1[sample_B] as AudioClip;
						audio_soft_B.PlayScheduled (time);
						audio_medium_A.clip = AudioArray_dynamic_organ2[sample_A] as AudioClip;
						audio_medium_A.PlayScheduled (time);
						
					}
					if (Intensity == 3) {
						if (dynamic_organ){
							audio_high_A.volume = 1.0f;
							audio_high_B.volume = 1.0f;
						}
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = true;
						dynamic_organ_final_isPlaying = false;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_A.clip = AudioArray_dynamic_organ3[sample_A] as AudioClip;
						audio_high_A.PlayScheduled (time);						
					}
					if (Intensity == 4 & dynamic_organ) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = true;	
						sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_A.clip = AudioArray_dynamic_organ4[sample_A] as AudioClip;
						audio_high_A.PlayScheduled (time);						
					}
				}
				if (Intensity == 4 & dynamic_organ_isPlaying & !dynamic_organ) {
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
					
				}
			}
		}
		
		if (i == 13) {
			if (time + 1.0F > singleMeasureTime) {
				if (dynamic_organ | dynamic_organ_isPlaying){
					//audio_demo.PlayScheduled (time);
					if (Intensity == 1 | Intensity == 2) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = true;
						dynamic_organ_medium_isPlaying = true;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = false;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_medium_B.clip = AudioArray_dynamic_organ2[sample_B] as AudioClip;
						audio_medium_B.PlayScheduled (time);
						
					}
					if (Intensity == 3) {
						if (dynamic_organ){
							audio_high_A.volume = 1.0f;
							audio_high_B.volume = 1.0f;
						}
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = true;
						dynamic_organ_final_isPlaying = false;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_B.clip = AudioArray_dynamic_organ3[sample_B] as AudioClip;
						audio_high_B.PlayScheduled (time);						
					}
					if (Intensity == 4 & dynamic_organ) {
						dynamic_organ_isPlaying = true;
						dynamic_organ_soft_isPlaying = false;
						dynamic_organ_medium_isPlaying = false;
						dynamic_organ_high_isPlaying = false;
						dynamic_organ_final_isPlaying = true;	
						sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
						audio_high_B.clip = AudioArray_dynamic_organ4[sample_B] as AudioClip;
						audio_high_B.PlayScheduled (time);						
					}
				}
				if (Intensity == 4 & dynamic_organ_isPlaying & !dynamic_organ) {
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end[sample_end] as AudioClip;
					audio_end.PlayScheduled (time);
					i = 42;
					
				}
			}
		}			
		
		
		
		
		
		if (i==16){
			i = 0;
		}
		
		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			Debug.Log ("The i int equals  " + i);
			if (dynamic_organ_isPlaying){
				i +=1;
			}
			
			if (i==46){
				if (!dynamic_organ){
					dynamic_organ_isPlaying = false;
					dynamic_organ_soft_isPlaying = false;
					dynamic_organ_medium_isPlaying = false;
					dynamic_organ_high_isPlaying = false;
					dynamic_organ_final_isPlaying = false;	
					DetermineBPM ();
					first_run = false;
				}
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}
		
		
		
	}
	
	public void OnValueChanged(float value_slider)
	{
		//GameObject goslider = GameObject.Find("Slider");
		//goslider = GetComponent<OnValueChanged>().OnValueChanged2();
		//go2.GetComponent<FadeIntro>().FadeMe();
		//organSlider = gameObject.GetComponent<Slider> ();
		//organSlider = GetComponentInChildren<Slider> ();
		//organSlider = GameObject.FindGameObjectWithTag("Slider");
		Intensity = value_slider;
		Debug.Log ("The Slider Intensity is  " + Intensity);
		
	}
	
}
