using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;


public class church_music_master_script : MonoBehaviour {
	//Choir
	Object[] AudioArray_choir_minor;
	Object[] AudioArray_choir_minor_end;
	bool switch_long;
	public AudioMixer church_mixer;
	//GENERAL
	public float bpm;
	public int beatsPerMeasure = 4;
	private double singleMeasureTime;
	private bool running = false;
	private int i;
	public bool first_run = false;
	int sample_A;
	int sample_B;
	int sample_end;
	public float Intensity = 1;
	
	int random_source;
	public Transform Player;
	public Transform ReferenceObject;
	private float distance;
	public float FadeOutSpeedToDistance = 1;
	public float MinVolumeDistance = 20;
	
	private float nextActionTime = 0.0f;
	private float period = 0.1f;
	private float nextActionTime2 = 0.0f;
	private float volume = 0.0f;
	
	public bool fade_to_distance;
	private float default_bpm = 120.0f;
	
	private bool fadeOut = false;
	private float vol = 1.00f;
	
	public bool fast;
	public bool normal;
	public bool slow;
	private bool stop = false;
	private float default_pitch = 1.0f;
	private float pitch;
	
	private bool dynamic_organ_soft_isPlaying;
	private bool dynamic_organ_medium_isPlaying;
	private bool dynamic_organ_high_isPlaying;
	private bool dynamic_organ_final_isPlaying;
	
	private AudioSource audio_soft_A;
	private AudioSource audio_soft_B;
	
	private AudioSource audio_medium_A;
	private AudioSource audio_medium_B;
	
	private AudioSource audio_high_A;
	private AudioSource audio_high_B;
	
	private AudioSource audio_final_A;
	private AudioSource audio_final_B;
	private AudioSource audio_end;
	
	public float fadeout_speed = 12f;
	public float fadein_speed = 35f;
	
	
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
	
	public bool gregorian_music_isPlaying = false;
	public bool medieval_organ_minor_isPlaying = false;
	public bool medieval_organ_major_isPlaying = false;
	public bool baroque_organ_minor_isPlaying = false;
	public bool baroque_organ_major_isPlaying = false;
	public bool dynamic_organ_isPlaying = false;
	public bool baroque_cello_minor_isPlaying = false;
	public bool baroque_cello_major_isPlaying = false;
	public bool choir_minor_isPlaying = false;
	public bool gregorian_chant_isPlaying = false;
	
	
	
	private AudioSource audio_medieval_organ_minor_A;
	private AudioSource audio_medieval_organ_minor_B;
	private AudioSource audio_medieval_organ_minor_end;
	
	private AudioSource audio_medieval_organ_major_A;
	private AudioSource audio_medieval_organ_major_B;
	private AudioSource audio_medieval_organ_major_end;
	
	private AudioSource audio_baroque_organ_minor_A;
	private AudioSource audio_baroque_organ_minor_B;
	private AudioSource audio_baroque_organ_minor_end;
	
	private AudioSource audio_baroque_organ_major_A;
	private AudioSource audio_baroque_organ_major_B;
	private AudioSource audio_baroque_organ_major_end;
	
	private AudioSource audio_baroque_choir_A;
	private AudioSource audio_baroque_choir_B;
	private AudioSource audio_baroque_choir_end;
	
	private AudioSource audio_gregorian_chant_A;
	private AudioSource audio_gregorian_chant_B;
	private AudioSource audio_gregorian_chant_end;
	
	private AudioSource audio_gregorian_ensemble_A;
	private AudioSource audio_gregorian_ensemble_B;
	private AudioSource audio_gregorian_ensemble_end;
	
	private AudioSource audio_baroque_cello_major_A;
	private AudioSource audio_baroque_cello_major_B;
	private AudioSource audio_baroque_cello_major_end;
	
	
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
	Object[] AudioArray_gregorian_chant;
	
	Object[] AudioArray_medieval_organ_minor_end;
	Object[] AudioArray_medieval_organ_major_end;
	Object[] AudioArray_baroque_organ_minor_end;
	Object[] AudioArray_baroque_organ_major_end;
	Object[] AudioArray_dynamic_organ_end;
	Object[] AudioArray_baroque_cello_minor_end;
	Object[] AudioArray_baroque_cello_major_end;
	
	Object[] AudioArray_gregorian;
	Object[] AudioArray_gregorian_end;
	private double time;
	
	Object[] AudioArray_gregorian_chant_end;
	
	private float medieval_organ_minor_vol;
	private float medieval_organ_major_vol;
	private float baroque_organ_minor_vol;
	private float baroque_organ_major_vol;
	private float dynamic_organ_soft_vol;
	private float dynamic_organ_medium_vol;
	private float dynamic_organ_forte_vol;
	private float dynamic_organ_fortissimo_vol;
	private float  baroque_cello_minor_vol;
	private float baroque_cello_major_vol;
	private float choir_minor_vol;
	private float gregorian_chant_vol;
	private float gregorian_music_vol;
	
	private int y;
	public bool start;
	private bool switch_sources;
	
	// Use this for initialization
	void Start () {
		beatsPerMeasure = 4;
		int i = 0;
		first_run = false;
		
		audio_medieval_organ_minor_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medieval_organ_minor_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medieval_organ_minor_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_medieval_organ_major_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medieval_organ_major_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medieval_organ_major_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_baroque_organ_minor_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_organ_minor_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_organ_minor_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_baroque_organ_major_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_organ_major_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_organ_major_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_baroque_choir_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_choir_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_choir_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_gregorian_chant_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_gregorian_chant_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_gregorian_chant_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_gregorian_ensemble_A = (AudioSource)gameObject.AddComponent <AudioSource> ();
		audio_gregorian_ensemble_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_gregorian_ensemble_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_baroque_cello_major_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_cello_major_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_baroque_cello_major_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_soft_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_soft_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_medium_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_medium_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_high_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_high_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		audio_final_A = (AudioSource)gameObject.AddComponent <AudioSource>();
		audio_final_B = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		
		audio_end = (AudioSource)gameObject.AddComponent <AudioSource>();
		
		AudioArray_choir_minor = Resources.LoadAll("random/minor/4-4/70/choir",typeof(AudioClip));
		AudioArray_choir_minor_end = Resources.LoadAll("random/minor/4-4/70/choir_end",typeof(AudioClip));
		AudioArray_gregorian = Resources.LoadAll("random/minor/4-4/100/gregorian",typeof(AudioClip));
		AudioArray_gregorian_end = Resources.LoadAll("random/minor/4-4/100/gregorian_end",typeof(AudioClip));
		AudioArray_medieval_organ_minor = Resources.LoadAll("random/minor/4-4/130/organ/main",typeof(AudioClip));
		AudioArray_medieval_organ_minor_end = Resources.LoadAll("random/minor/4-4/130/organ/end",typeof(AudioClip));
		AudioArray_medieval_organ_major = Resources.LoadAll("random/major/4-4/80/organ/main",typeof(AudioClip));
		AudioArray_medieval_organ_major_end = Resources.LoadAll("random/major/4-4/80/organ/end",typeof(AudioClip));
		AudioArray_baroque_organ_minor = Resources.LoadAll("random/minor/4-4/100/organ/main",typeof(AudioClip));
		AudioArray_baroque_organ_minor_end = Resources.LoadAll("random/minor/4-4/100/organ/end",typeof(AudioClip));
		AudioArray_baroque_organ_major = Resources.LoadAll("random/major/4-4/110/organ/main",typeof(AudioClip));
		AudioArray_baroque_organ_major_end = Resources.LoadAll("random/major/4-4/110/organ/end",typeof(AudioClip));
		AudioArray_baroque_cello_major = Resources.LoadAll("random/major/4-4/90/cello/main",typeof(AudioClip));
		AudioArray_baroque_cello_major_end = Resources.LoadAll("random/major/4-4/90/cello/end",typeof(AudioClip));
		AudioArray_gregorian_chant = Resources.LoadAll("random/minor/4-4/90/chant",typeof(AudioClip));
		AudioArray_gregorian_chant_end = Resources.LoadAll("random/minor/4-4/90/end",typeof(AudioClip));
		AudioArray_dynamic_organ1 = Resources.LoadAll("random/dynamic/soft",typeof(AudioClip));
		AudioArray_dynamic_organ2 = Resources.LoadAll("random/dynamic/medium",typeof(AudioClip));
		AudioArray_dynamic_organ3 = Resources.LoadAll("random/dynamic/high",typeof(AudioClip));
		AudioArray_dynamic_organ4 = Resources.LoadAll("random/dynamic/final",typeof(AudioClip));
		AudioArray_dynamic_organ_end = Resources.LoadAll("random/dynamic/final_end",typeof(AudioClip));




		audio_soft_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_soft")[0];
		audio_soft_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_soft")[0];

		audio_medium_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_medium")[0];
		audio_medium_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_medium")[0];
		
		audio_high_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_forte")[0];
		audio_high_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_forte")[0];
		
		audio_final_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_fortissimo")[0];	
		audio_final_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_fortissimo")[0];
		audio_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("dynamic_organ_fortissimo")[0];
		
		audio_medieval_organ_minor_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_minor")[0];
		audio_medieval_organ_minor_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_minor")[0];
		audio_medieval_organ_minor_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_minor")[0];
		
		audio_medieval_organ_major_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_major")[0];
		audio_medieval_organ_major_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_major")[0];
		audio_medieval_organ_major_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("medieval_organ_major")[0];
		
		audio_baroque_organ_minor_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_minor")[0];
		audio_baroque_organ_minor_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_minor")[0];
		audio_baroque_organ_minor_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_minor")[0];
		
		audio_baroque_organ_major_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_major")[0];
		audio_baroque_organ_major_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_major")[0];
		audio_baroque_organ_major_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_organ_major")[0];
		
		audio_baroque_choir_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_choir")[0];
		audio_baroque_choir_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_choir")[0];
		audio_baroque_choir_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_choir")[0];
		
		audio_gregorian_chant_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_chant")[0];
		audio_gregorian_chant_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_chant")[0];
		audio_gregorian_chant_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_chant")[0];
		
		audio_gregorian_ensemble_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_ensemble")[0];
		audio_gregorian_ensemble_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_ensemble")[0];
		audio_gregorian_ensemble_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("gregorian_ensemble")[0];
		
		audio_baroque_cello_major_A.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_cello_major")[0];
		audio_baroque_cello_major_B.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_cello_major")[0];
		audio_baroque_cello_major_end.outputAudioMixerGroup = church_mixer.FindMatchingGroups("baroque_cello_major")[0];

		
	}
	
	// Update is called once per frame
	void Update () {
		PlayConditions ();
		
		Volume_Control ();
		
		if (start) {
			if (!first_run) {
				singleMeasureTime = AudioSettings.dspTime + 2.0F;
				Pitch_Set ();
				running = true;
				i = 0;
				y = 0;
			}
			first_run = true;
			if (!running)
				return;
			time = AudioSettings.dspTime;
			
			
			if (choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Choir_Minor_Play ();
			}
			
			if (!choir_minor_isPlaying & medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Medieval_Organ_Minor_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Medieval_Organ_Major_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Baroque_Organ_Minor_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Baroque_Organ_Major_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Dynamic_Organ_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Baroque_Cello_Major_Play ();
			}
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				Gregorian_Chant_Play ();
			}
			
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & gregorian_music_isPlaying){
				Gregorian_Ensemble_Play ();
			}
			
			
			
		}	
		
		
		
	}
	
	public void DetermineBPM(){
		if (choir_minor) {
			if (!medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 70.0f;
			}
		}
		if (medieval_organ_minor) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 130.0f;
			}
		}
		
		if (medieval_organ_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 80.0f;
			}
		}
		
		if (baroque_organ_minor) {
			if (!choir_minor_isPlaying & !medieval_organ_major_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 100.0f;
			}
		}
		
		if (baroque_organ_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 110.0f;
			}
		}
		
		if (baroque_cello_major) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_organ_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 90.0f;
			}
		}
		
		if (gregorian_chant) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 90.0f;
			}
		}
		
		if (dynamic_organ) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying 
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying & !gregorian_music_isPlaying){
				default_bpm = 140.0f;
			}
		}
		
		if (gregorian_music) {
			if (!choir_minor_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying 
			    & !baroque_organ_major_isPlaying & !baroque_cello_major_isPlaying & !dynamic_organ_isPlaying){
				default_bpm = 100.0f;
			}
		}
		Pitch_Set ();
		
	}
	
	public void Choir_Minor_Play(){
		sample_A = Random.Range (0, AudioArray_choir_minor.Length);
		sample_B = Random.Range (0, AudioArray_choir_minor.Length);
		sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				
				if (choir_minor) {
					choir_minor_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_choir_minor.Length);
						audio_baroque_choir_A.clip = AudioArray_choir_minor [sample_A] as AudioClip;
						audio_baroque_choir_A.PlayOneShot (audio_baroque_choir_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_choir_minor.Length);
						audio_baroque_choir_B.clip = AudioArray_choir_minor [sample_B] as AudioClip;
						audio_baroque_choir_B.PlayOneShot (audio_baroque_choir_B.clip, 1.0f);
					}
				}
				if (!choir_minor) {
					choir_minor_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_choir_minor_end.Length);
					audio_baroque_choir_end.clip = AudioArray_choir_minor_end [sample_end] as AudioClip;
					audio_baroque_choir_end.PlayOneShot (audio_baroque_choir_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	public void Gregorian_Ensemble_Play(){
		sample_A = Random.Range (0, AudioArray_gregorian.Length);
		sample_B = Random.Range (0, AudioArray_gregorian.Length);
		sample_end = 0;
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 9) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (gregorian_music) {
					gregorian_music_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_gregorian.Length);
						audio_gregorian_ensemble_A.clip = AudioArray_gregorian [sample_A] as AudioClip;
						audio_gregorian_ensemble_A.PlayOneShot (audio_gregorian_ensemble_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_gregorian.Length);
						audio_gregorian_ensemble_B.clip = AudioArray_gregorian [sample_B] as AudioClip;
						audio_gregorian_ensemble_B.PlayOneShot (audio_gregorian_ensemble_B.clip, 1.0f);
					}
				}
				if (!gregorian_music) {
					gregorian_music_isPlaying = false;
					i = -3;
					sample_end = 0;
					audio_gregorian_ensemble_end.clip = AudioArray_gregorian_end [sample_end] as AudioClip;
					audio_gregorian_ensemble_end.PlayOneShot (audio_gregorian_ensemble_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	
	
	public void Medieval_Organ_Minor_Play(){
		sample_A = Random.Range (0, AudioArray_medieval_organ_minor.Length);
		sample_B = Random.Range (0, AudioArray_medieval_organ_minor.Length);
		sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (medieval_organ_minor) {
					medieval_organ_minor_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_medieval_organ_minor.Length);
						audio_medieval_organ_minor_A.clip = AudioArray_medieval_organ_minor [sample_A] as AudioClip;
						audio_medieval_organ_minor_A.PlayOneShot (audio_medieval_organ_minor_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_medieval_organ_minor.Length);
						audio_medieval_organ_minor_B.clip = AudioArray_medieval_organ_minor [sample_B] as AudioClip;
						audio_medieval_organ_minor_B.PlayOneShot (audio_medieval_organ_minor_B.clip, 1.0f);
					}
				}
				if (!medieval_organ_minor) {
					medieval_organ_minor_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_medieval_organ_minor_end.Length);
					audio_medieval_organ_minor_end.clip = AudioArray_medieval_organ_minor_end [sample_end] as AudioClip;
					audio_medieval_organ_minor_end.PlayOneShot (audio_medieval_organ_minor_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	
	
	public void Medieval_Organ_Major_Play(){
		sample_A = Random.Range (0, AudioArray_medieval_organ_major.Length);
		sample_B = Random.Range (0, AudioArray_medieval_organ_major.Length);
		sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (medieval_organ_major) {
					medieval_organ_major_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_medieval_organ_major.Length);
						audio_medieval_organ_major_A.clip = AudioArray_medieval_organ_major [sample_A] as AudioClip;
						audio_medieval_organ_major_A.PlayOneShot (audio_medieval_organ_major_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_medieval_organ_major.Length);
						audio_medieval_organ_major_B.clip = AudioArray_medieval_organ_major [sample_B] as AudioClip;
						audio_medieval_organ_major_B.PlayOneShot (audio_medieval_organ_major_B.clip, 1.0f);
					}
				}
				if (!medieval_organ_major) {
					medieval_organ_major_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_medieval_organ_major_end.Length);
					audio_medieval_organ_major_end.clip = AudioArray_medieval_organ_major_end [sample_end] as AudioClip;
					audio_medieval_organ_major_end.PlayOneShot (audio_medieval_organ_major_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	public void Baroque_Organ_Minor_Play(){
		sample_A = Random.Range (0, AudioArray_baroque_organ_minor.Length);
		sample_B = Random.Range (0, AudioArray_baroque_organ_minor.Length);
		sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {

			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (baroque_organ_minor) {
					baroque_organ_minor_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_baroque_organ_minor.Length);
						audio_baroque_organ_minor_A.clip = AudioArray_baroque_organ_minor [sample_A] as AudioClip;
						audio_baroque_organ_minor_A.PlayOneShot (audio_baroque_organ_minor_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_baroque_organ_minor.Length);
						audio_baroque_organ_minor_B.clip = AudioArray_baroque_organ_minor [sample_B] as AudioClip;
						audio_baroque_organ_minor_B.PlayOneShot (audio_baroque_organ_minor_B.clip, 1.0f);
					}
				}
				if (!baroque_organ_minor) {
					baroque_organ_minor_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_baroque_organ_minor_end.Length);
					audio_baroque_organ_minor_end.clip = AudioArray_baroque_organ_minor_end [sample_end] as AudioClip;
					audio_baroque_organ_minor_end.PlayOneShot (audio_baroque_organ_minor_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	
	
	public void Baroque_Organ_Major_Play(){
		sample_A = Random.Range (0, AudioArray_baroque_organ_major.Length);
		sample_B = Random.Range (0, AudioArray_baroque_organ_major.Length);
		sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 5) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (baroque_organ_major) {
					baroque_organ_major_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_baroque_organ_major.Length);
						audio_baroque_organ_major_A.clip = AudioArray_baroque_organ_major [sample_A] as AudioClip;
						audio_baroque_organ_major_A.PlayOneShot (audio_baroque_organ_major_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_baroque_organ_major.Length);
						audio_baroque_organ_major_B.clip = AudioArray_baroque_organ_major [sample_B] as AudioClip;
						audio_baroque_organ_major_B.PlayOneShot (audio_baroque_organ_major_B.clip, 1.0f);
					}
				}
				if (!baroque_organ_major) {
					baroque_organ_major_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_baroque_organ_major_end.Length);
					audio_baroque_organ_major_end.clip = AudioArray_baroque_organ_major_end [sample_end] as AudioClip;
					audio_baroque_organ_major_end.PlayOneShot (audio_baroque_organ_major_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	
	
	public void Baroque_Cello_Major_Play(){
		sample_A = Random.Range (0, AudioArray_baroque_cello_major.Length);
		sample_B = Random.Range (0, AudioArray_baroque_cello_major.Length);
		sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 3) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (baroque_cello_major) {
					baroque_cello_major_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_baroque_cello_major.Length);
						audio_baroque_cello_major_A.clip = AudioArray_baroque_cello_major [sample_A] as AudioClip;
						audio_baroque_cello_major_A.PlayOneShot (audio_baroque_cello_major_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_baroque_cello_major.Length);
						audio_baroque_cello_major_B.clip = AudioArray_baroque_cello_major [sample_B] as AudioClip;
						audio_baroque_cello_major_B.PlayOneShot (audio_baroque_cello_major_B.clip, 1.0f);
					}
				}
				if (!baroque_cello_major) {
					baroque_cello_major_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_baroque_cello_major_end.Length);
					audio_baroque_cello_major_end.clip = AudioArray_baroque_cello_major_end [sample_end] as AudioClip;
					audio_baroque_cello_major_end.PlayOneShot (audio_baroque_cello_major_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	public void Gregorian_Chant_Play(){
		sample_A = Random.Range (0, AudioArray_gregorian_chant.Length);
		sample_B = Random.Range (0, AudioArray_gregorian_chant.Length);
		sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
		
		if (i == 0) {
			DetermineBPM();		}
		
		
		if (i == 3) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;
				random_source = Random.Range (0, 16);
				
				if (gregorian_chant) {
					gregorian_chant_isPlaying = true;
					if (switch_sources) {
						sample_A = Random.Range (0, AudioArray_gregorian_chant.Length);
						audio_gregorian_chant_A.clip = AudioArray_gregorian_chant [sample_A] as AudioClip;
						audio_gregorian_chant_A.PlayOneShot (audio_gregorian_chant_A.clip, 1.0f);
					}
					if (!switch_sources) {
						sample_B = Random.Range (0, AudioArray_gregorian_chant.Length);
						audio_gregorian_chant_B.clip = AudioArray_gregorian_chant [sample_B] as AudioClip;
						audio_gregorian_chant_B.PlayOneShot (audio_gregorian_chant_B.clip, 1.0f);
					}
				}
				if (!gregorian_chant) {
					gregorian_chant_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_gregorian_chant_end.Length);
					audio_gregorian_chant_end.clip = AudioArray_gregorian_chant_end [sample_end] as AudioClip;
					audio_gregorian_chant_end.PlayOneShot (audio_gregorian_chant_end.clip, 1.0f);
				}
			}
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	public void Dynamic_Organ_Play(){
		sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
		sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
		sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
		
		
		if (!dynamic_organ & Intensity != 4){
			if (Intensity == 1){
				if (dynamic_organ_soft_vol > -80.0f) {
					dynamic_organ_soft_vol -= fadeout_speed * Time.deltaTime;
				}
				if (dynamic_organ_soft_vol <-70.0f){
					dynamic_organ_isPlaying = false;
					i = -1;
				}
			}
			if (Intensity == 2){
				if (dynamic_organ_medium_vol > -80.0f) {
					dynamic_organ_medium_vol -= fadeout_speed * Time.deltaTime;
				}
				if (dynamic_organ_medium_vol <-70.0f){
					dynamic_organ_isPlaying = false;
					i = -1;
				}
			}
			if (Intensity == 3){
				if (dynamic_organ_forte_vol > -80.0f) {
					dynamic_organ_forte_vol -= fadeout_speed * Time.deltaTime;
				}
				if (dynamic_organ_forte_vol <-70.0f){
					dynamic_organ_isPlaying = false;
					i = -1;
				}
			}
			
			
		}
		
		if (i == 0) {
			DetermineBPM();		}
		
		if (i == 9) {
			if (time + 1.0F > singleMeasureTime) {
				i = 1;
			}
		}
		
		if (time + 1.0F > singleMeasureTime) {
			
			if (i == 1) {
				switch_sources = !switch_sources;

				switch_long = !switch_long;
				if (dynamic_organ) {
					dynamic_organ_isPlaying = true;
					if (Intensity == 1 | Intensity == 2){
						if (switch_long) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
							audio_soft_A.clip = AudioArray_dynamic_organ1 [sample_A] as AudioClip;
							audio_soft_A.PlayOneShot (audio_soft_A.clip, 1.0f);
														
						}
						if (!switch_long) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
							audio_soft_B.clip = AudioArray_dynamic_organ1 [sample_B] as AudioClip;
							audio_soft_B.PlayOneShot (audio_soft_B.clip, 1.0f);

						}

						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);

							audio_medium_A.clip = AudioArray_dynamic_organ2 [sample_A] as AudioClip;
							audio_medium_A.PlayOneShot (audio_medium_A.clip, 1.0f);
							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);

							audio_medium_B.clip = AudioArray_dynamic_organ2 [sample_B] as AudioClip;
							audio_medium_B.PlayOneShot (audio_medium_B.clip, 1.0f);
						}
					}
					if (Intensity == 3){
						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ3.Length);
							audio_high_A.clip = AudioArray_dynamic_organ3 [sample_A] as AudioClip;
							audio_high_A.PlayOneShot (audio_high_A.clip, 1.0f);							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ3.Length);
							audio_high_B.clip = AudioArray_dynamic_organ3 [sample_B] as AudioClip;
							audio_high_B.PlayOneShot (audio_high_B.clip, 1.0f);							
						}
					}
					if (Intensity == 4){
						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ4.Length);
							audio_final_A.clip = AudioArray_dynamic_organ4 [sample_A] as AudioClip;
							audio_final_A.PlayOneShot (audio_final_A.clip, 1.0f);							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ4.Length);
							audio_final_B.clip = AudioArray_dynamic_organ4 [sample_B] as AudioClip;
							audio_final_B.PlayOneShot (audio_final_B.clip, 1.0f);							
						}
					}
					
				}
				
				
				
				if (!dynamic_organ & Intensity == 4) {
					dynamic_organ_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end [sample_end] as AudioClip;
					audio_end.PlayOneShot (audio_end.clip, 1.0f);
				}
				
			}
			
			if (i == 5) {
				switch_sources = !switch_sources;
				
				if (dynamic_organ) {
					dynamic_organ_isPlaying = true;
					if (Intensity == 2){
						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ1.Length);
							audio_medium_A.clip = AudioArray_dynamic_organ2 [sample_A] as AudioClip;
							audio_medium_A.PlayOneShot (audio_medium_A.clip, 1.0f);
							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ1.Length);
							audio_medium_B.clip = AudioArray_dynamic_organ2 [sample_B] as AudioClip;
							audio_medium_B.PlayOneShot (audio_medium_B.clip, 1.0f);
						}
					}
					if (Intensity == 3){
						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ3.Length);
							audio_high_A.clip = AudioArray_dynamic_organ3 [sample_A] as AudioClip;
							audio_high_A.PlayOneShot (audio_high_A.clip, 1.0f);							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ3.Length);
							audio_high_B.clip = AudioArray_dynamic_organ3 [sample_B] as AudioClip;
							audio_high_B.PlayOneShot (audio_high_B.clip, 1.0f);							
						}
					}
					if (Intensity == 4){
						if (switch_sources) {
							sample_A = Random.Range (0, AudioArray_dynamic_organ4.Length);
							audio_final_A.clip = AudioArray_dynamic_organ4 [sample_A] as AudioClip;
							audio_final_A.PlayOneShot (audio_final_A.clip, 1.0f);							
						}
						if (!switch_sources) {
							sample_B = Random.Range (0, AudioArray_dynamic_organ4.Length);
							audio_final_B.clip = AudioArray_dynamic_organ4 [sample_B] as AudioClip;
							audio_final_B.PlayOneShot (audio_final_B.clip, 1.0f);							
						}
					}
					
				}
				if (!dynamic_organ & Intensity == 4) {
					dynamic_organ_isPlaying = false;
					i = -3;
					sample_end = Random.Range (0, AudioArray_dynamic_organ_end.Length);
					audio_end.clip = AudioArray_dynamic_organ_end [sample_end] as AudioClip;
					audio_end.PlayOneShot (audio_end.clip, 1.0f);
				}
				
			}
			
		}
		
		if (time + 1.0F > singleMeasureTime & start) {
			//Debug.Log ("The i int equals  " + i);
			i += 1;
			
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
			
		}
		
	}
	
	
	
	
	private void Pitch_Set(){
		if (!fast & !slow & !normal) {
			bpm = default_bpm;
		}
		if (fast) {
			bpm = default_bpm / 0.9375f;
			audio_soft_A.pitch = default_pitch  / 0.9375f;
			audio_soft_B.pitch = default_pitch  / 0.9375f;
			
			audio_medium_A.pitch = default_pitch  / 0.9375f;
			audio_medium_B.pitch = default_pitch  / 0.9375f;
			
			audio_high_A.pitch = default_pitch  / 0.9375f;
			audio_high_B.pitch = default_pitch  / 0.9375f;
			
			audio_final_A.pitch = default_pitch  / 0.9375f;
			audio_final_B.pitch = default_pitch  / 0.9375f;
			
			audio_medieval_organ_minor_A.pitch = default_pitch  / 0.9375f;
			audio_medieval_organ_minor_B.pitch = default_pitch  / 0.9375f;
			audio_medieval_organ_minor_end.pitch = default_pitch  / 0.9375f;
			
			audio_medieval_organ_major_A.pitch = default_pitch  / 0.9375f;
			audio_medieval_organ_major_B.pitch = default_pitch  / 0.9375f;
			audio_medieval_organ_major_end.pitch = default_pitch  / 0.9375f;
			
			audio_baroque_organ_minor_A.pitch = default_pitch  / 0.9375f;
			audio_baroque_organ_minor_B.pitch = default_pitch  / 0.9375f;
			audio_baroque_organ_minor_end.pitch = default_pitch  / 0.9375f;
			
			audio_baroque_organ_major_A.pitch = default_pitch  / 0.9375f;
			audio_baroque_organ_major_B.pitch = default_pitch  / 0.9375f;
			audio_baroque_organ_major_end.pitch = default_pitch  / 0.9375f;
			
			audio_baroque_choir_A.pitch = default_pitch  / 0.9375f;
			audio_baroque_choir_B.pitch = default_pitch  / 0.9375f;
			audio_baroque_choir_end.pitch = default_pitch  / 0.9375f;
			
			audio_gregorian_chant_A.pitch = default_pitch  / 0.9375f;
			audio_gregorian_chant_B.pitch = default_pitch  / 0.9375f;
			audio_gregorian_chant_end.pitch = default_pitch  / 0.9375f;
			
			audio_gregorian_ensemble_A.pitch = default_pitch  / 0.9375f;
			audio_gregorian_ensemble_B.pitch = default_pitch  / 0.9375f;
			audio_gregorian_ensemble_end.pitch = default_pitch  / 0.9375f;
			
			audio_baroque_cello_major_A.pitch = default_pitch  / 0.9375f;
			audio_baroque_cello_major_B.pitch = default_pitch  / 0.9375f;
			audio_baroque_cello_major_end.pitch = default_pitch  / 0.9375f;
			audio_end.pitch = default_pitch  / 0.9375f;
			
			
		}
		if (slow) {
			bpm = default_bpm * 0.9375f;
			audio_soft_A.pitch = default_pitch  * 0.9375f;
			audio_soft_B.pitch = default_pitch  * 0.9375f;
			
			audio_medium_A.pitch = default_pitch  * 0.9375f;
			audio_medium_B.pitch = default_pitch  * 0.9375f;
			
			audio_high_A.pitch = default_pitch  * 0.9375f;
			audio_high_B.pitch = default_pitch  * 0.9375f;
			
			audio_final_A.pitch = default_pitch  * 0.9375f;
			audio_final_B.pitch = default_pitch  * 0.9375f;
			
			audio_medieval_organ_minor_A.pitch = default_pitch  * 0.9375f;
			audio_medieval_organ_minor_B.pitch = default_pitch  * 0.9375f;
			audio_medieval_organ_minor_end.pitch = default_pitch  * 0.9375f;
			
			audio_medieval_organ_major_A.pitch = default_pitch  * 0.9375f;
			audio_medieval_organ_major_B.pitch = default_pitch  * 0.9375f;
			audio_medieval_organ_major_end.pitch = default_pitch  * 0.9375f;
			
			audio_baroque_organ_minor_A.pitch = default_pitch  * 0.9375f;
			audio_baroque_organ_minor_B.pitch = default_pitch  * 0.9375f;
			audio_baroque_organ_minor_end.pitch = default_pitch  * 0.9375f;
			
			audio_baroque_organ_major_A.pitch = default_pitch  * 0.9375f;
			audio_baroque_organ_major_B.pitch = default_pitch  * 0.9375f;
			audio_baroque_organ_major_end.pitch = default_pitch  * 0.9375f;
			
			audio_baroque_choir_A.pitch = default_pitch  * 0.9375f;
			audio_baroque_choir_B.pitch = default_pitch  * 0.9375f;
			audio_baroque_choir_end.pitch = default_pitch  * 0.9375f;
			
			audio_gregorian_chant_A.pitch = default_pitch  * 0.9375f;
			audio_gregorian_chant_B.pitch = default_pitch  * 0.9375f;
			audio_gregorian_chant_end.pitch = default_pitch  * 0.9375f;
			
			audio_gregorian_ensemble_A.pitch = default_pitch  * 0.9375f;
			audio_gregorian_ensemble_B.pitch = default_pitch  * 0.9375f;
			audio_gregorian_ensemble_end.pitch = default_pitch  * 0.9375f;
			
			audio_baroque_cello_major_A.pitch = default_pitch  * 0.9375f;
			audio_baroque_cello_major_B.pitch = default_pitch  * 0.9375f;
			audio_baroque_cello_major_end.pitch = default_pitch  * 0.9375f;
			audio_end.pitch = default_pitch  * 0.9375f;
			
		}
		if (normal) {
			bpm = default_bpm;
			audio_soft_A.pitch = default_pitch;
			audio_soft_B.pitch = default_pitch;
			
			audio_medium_A.pitch = default_pitch;
			audio_medium_B.pitch = default_pitch;
			
			audio_high_A.pitch = default_pitch;
			audio_high_B.pitch = default_pitch;
			
			audio_final_A.pitch = default_pitch;
			audio_final_B.pitch = default_pitch;
			
			
			audio_medieval_organ_minor_A.pitch = default_pitch;
			audio_medieval_organ_minor_B.pitch = default_pitch;
			audio_medieval_organ_minor_end.pitch = default_pitch;
			
			audio_medieval_organ_major_A.pitch = default_pitch;
			audio_medieval_organ_major_B.pitch = default_pitch;
			audio_medieval_organ_major_end.pitch = default_pitch;
			
			audio_baroque_organ_minor_A.pitch = default_pitch;
			audio_baroque_organ_minor_B.pitch = default_pitch;
			audio_baroque_organ_minor_end.pitch = default_pitch;
			
			audio_baroque_organ_major_A.pitch = default_pitch;
			audio_baroque_organ_major_B.pitch = default_pitch;
			audio_baroque_organ_major_end.pitch = default_pitch;
			
			audio_baroque_choir_A.pitch = default_pitch;
			audio_baroque_choir_B.pitch = default_pitch;
			audio_baroque_choir_end.pitch = default_pitch;
			
			audio_gregorian_chant_A.pitch = default_pitch;
			audio_gregorian_chant_B.pitch = default_pitch;
			audio_gregorian_chant_end.pitch = default_pitch;
			
			audio_gregorian_ensemble_A.pitch = default_pitch;
			audio_gregorian_ensemble_B.pitch = default_pitch;
			audio_gregorian_ensemble_end.pitch = default_pitch;
			
			audio_baroque_cello_major_A.pitch = default_pitch;
			audio_baroque_cello_major_B.pitch = default_pitch;
			audio_baroque_cello_major_end.pitch = default_pitch;
			audio_end.pitch = default_pitch;
		}
		
		
	}
	
	public void Medieval_Organ_Minor_OnClick(){
		start = true;
		
		medieval_organ_minor = true;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
	}
	public void Medieval_Organ_Major_OnClick(){
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = true;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
	}
	public void Baroque_Organ_Minor_OnClick(){
		
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = true;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
	}
	public void Baroque_Organ_Major_OnClick(){
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = true;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
	}
	
	public void Baroque_Organ_Dynamic_OnClick(){
		start = true;
		
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = true;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
		
	}
	public void Baroque_Cello_Minor_OnClick(){
		start = true;
		
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = true;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
	}
	public void Baroque_Cello_Major_OnClick(){
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = true;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		
		
	}
	public void Choir_minor_OnClick(){
		start = true;
		
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = true;
		gregorian_chant = false;
		gregorian_music = false;
		
	}
	public void Gregorian_chant_OnClick(){
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = true;
		gregorian_music = false;
		
	}
	
	public void Gregorian_music_OnClick(){
		start = true;
		
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = true;
		
	}
	
	public void Stop_OnClick(){
		first_run = false;
		start = false;
		medieval_organ_minor = false;
		medieval_organ_major = false;
		baroque_organ_minor = false;
		baroque_organ_major = false;
		dynamic_organ = false;
		baroque_cello_minor = false;
		baroque_cello_major = false;
		choir_minor = false;
		gregorian_chant = false;
		gregorian_music = false;
		i = 100;
		
	}
	
	private void PlayConditions(){
		if (choir_minor & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !gregorian_music_isPlaying){
			
			choir_minor_isPlaying = true;
			stop = false;	
			
		}
		
		if (gregorian_music & !medieval_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			gregorian_music_isPlaying = true;
			stop = false;
			
		}
		
		if (medieval_organ_minor & !gregorian_music_isPlaying & !medieval_organ_major_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			medieval_organ_minor_isPlaying = true;
			stop = false;
			
		}
		
		if (medieval_organ_major & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			medieval_organ_major_isPlaying = true;
			stop = false;
			
		}
		
		if (baroque_organ_major & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_minor_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			
			baroque_organ_major_isPlaying = true;
			stop = false;
			
		}
		
		if (baroque_organ_minor & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_cello_major_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			
			baroque_organ_minor_isPlaying = true;
			stop = false;
			
		}
		
		if (baroque_cello_major & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_organ_minor_isPlaying & !gregorian_chant_isPlaying & !choir_minor_isPlaying){
			
			
			baroque_cello_major_isPlaying = true;
			stop = false;
			
		}
		
		if (gregorian_chant & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !medieval_organ_major_isPlaying & !dynamic_organ_isPlaying 
		    & !baroque_organ_minor_isPlaying & !baroque_cello_major_isPlaying & !choir_minor_isPlaying){
			
			
			gregorian_chant_isPlaying = true;
			stop = false;
			
		}
		
		if (dynamic_organ & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying  
		    & !baroque_organ_minor_isPlaying & !baroque_cello_major_isPlaying & !choir_minor_isPlaying){
			
			
			dynamic_organ_isPlaying = true;
			stop = false;
			
		}
		
		if (!dynamic_organ_isPlaying & !gregorian_music_isPlaying & !medieval_organ_minor_isPlaying & !baroque_organ_major_isPlaying & !medieval_organ_major_isPlaying & !gregorian_chant_isPlaying  
		    & !baroque_organ_minor_isPlaying & !baroque_cello_major_isPlaying & !choir_minor_isPlaying){
			
			if (!dynamic_organ & !gregorian_music & !medieval_organ_minor & !baroque_organ_major & !medieval_organ_major & !gregorian_chant  
			    & !baroque_organ_minor & !baroque_cello_major & !choir_minor){
				stop = true;
				
			}
			
			
		}
		
		if (stop) {
			start = false;
			first_run = false;
			running = false;
			singleMeasureTime = 0;
		}
	}
	
	
	
	private void Volume_Control(){
		
		church_mixer.SetFloat ("medieval_organ_minor", medieval_organ_minor_vol);
		church_mixer.SetFloat ("medieval_organ_major", medieval_organ_major_vol);
		church_mixer.SetFloat ("baroque_organ_minor", baroque_organ_minor_vol);
		church_mixer.SetFloat ("baroque_organ_major", baroque_organ_major_vol);
		church_mixer.SetFloat ("dynamic_organ_soft", dynamic_organ_soft_vol);
		church_mixer.SetFloat ("dynamic_organ_medium", dynamic_organ_medium_vol);
		church_mixer.SetFloat ("dynamic_organ_forte", dynamic_organ_forte_vol);
		church_mixer.SetFloat ("dynamic_organ_fortissimo", dynamic_organ_fortissimo_vol);
		church_mixer.SetFloat ("baroque_cello_major", baroque_cello_major_vol);
		church_mixer.SetFloat ("baroque_choir", choir_minor_vol);
		church_mixer.SetFloat ("gregorian_chant", gregorian_chant_vol);
		church_mixer.SetFloat ("gregorian_ensemble", gregorian_music_vol);
		
		if(ReferenceObject != null){
			distance = Vector3.Distance(Player.position, ReferenceObject.position);
		}
		
		if (Player & fade_to_distance) {
			volume = (-distance*FadeOutSpeedToDistance) + MinVolumeDistance;
			if(volume > 0){
				volume = 0;
			}else if(volume < -80.0f){
				volume = -80.0f;
			}
		}
		
		//Medieval Organ Minor VOLUME CONTROL
		if (fade_to_distance & medieval_organ_minor_isPlaying) {
			
			if (fade_to_distance & medieval_organ_minor){
				medieval_organ_minor_vol = volume;
			}
			
			
			
		}
		
		//Medieval Organ Major VOLUME CONTROL
		if (fade_to_distance & medieval_organ_major_isPlaying) {
			
			if (fade_to_distance & medieval_organ_major){
				medieval_organ_major_vol = volume;
			}
			
			
		}
		
		//Baroque Organ Minor VOLUME CONTROL
		if (fade_to_distance & baroque_organ_minor_isPlaying) {
			
			if (fade_to_distance & baroque_organ_minor){
				baroque_organ_minor_vol = volume;
			}
			
		}
		
		//Baroque Organ Major VOLUME CONTROL
		if (fade_to_distance & baroque_organ_major_isPlaying) {
			
			if (fade_to_distance & baroque_organ_major){
				baroque_organ_major_vol = volume;
			}
			
		}
	
		
		if (dynamic_organ) {
			if (Intensity == 1){
				if (dynamic_organ_soft_vol < 0.0f) {
					dynamic_organ_soft_vol += fadein_speed * Time.deltaTime;
				}
				if (dynamic_organ_medium_vol > -80.0f) {
					dynamic_organ_medium_vol -= fadeout_speed * Time.deltaTime;
				}
			}
			if (Intensity == 2){
				if (dynamic_organ_medium_vol < 0.0f) {
					dynamic_organ_medium_vol += fadein_speed * Time.deltaTime;
				}
				if (dynamic_organ_soft_vol > -80.0f) {
					dynamic_organ_soft_vol -= fadeout_speed * Time.deltaTime;
				}
			}
			if (Intensity == 3){
				if (dynamic_organ_forte_vol < 0.0f) {
					dynamic_organ_forte_vol += fadein_speed * Time.deltaTime;
				}
				if (dynamic_organ_soft_vol > -80.0f) {
					dynamic_organ_soft_vol -= fadeout_speed * Time.deltaTime;
				}
			}
			
		}
		
		
		
		
	}
	
}
