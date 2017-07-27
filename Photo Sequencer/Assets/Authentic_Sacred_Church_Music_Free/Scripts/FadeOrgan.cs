using UnityEngine;
using System.Collections;

public class FadeOrgan : MonoBehaviour {

	public void FadeMeOut(){
			StartCoroutine (DoFadeOut ());
	}
	
	IEnumerator DoFadeOut(){
		CanvasGroup introcanvas = GetComponent<CanvasGroup> ();
		while (introcanvas.alpha >0) {
			introcanvas.alpha -= Time.deltaTime * 4;
			yield return null;
		}
		yield return null;
	}

	public void FadeMeIn(){
		StartCoroutine (DoFadeIn ());
	}
	
	IEnumerator DoFadeIn(){
		CanvasGroup introcanvas = GetComponent<CanvasGroup> ();
		while (introcanvas.alpha <1) {
			introcanvas.alpha += Time.deltaTime * 4;
			yield return null;
		}
		yield return null;
	}
}
