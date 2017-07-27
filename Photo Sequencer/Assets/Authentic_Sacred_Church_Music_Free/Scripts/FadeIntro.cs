using UnityEngine;
using System.Collections;

public class FadeIntro : MonoBehaviour {

	public void FadeMe(){
		StartCoroutine (DoFade ());
	}

	IEnumerator DoFade(){
		CanvasGroup introcanvas = GetComponent<CanvasGroup> ();
		while (introcanvas.alpha >0) {
			introcanvas.alpha -= Time.deltaTime * 4;
			yield return null;
		}
		yield return null;
	}
}
