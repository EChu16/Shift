using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=0HwZQt94uHQ&t=41s
public class Fading : MonoBehaviour {
	public Texture2D FadeOutTexture;
	public float fadeSpeed = 0.8f;
	public int DrawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;    //direction to fade

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force clamp the number between 0 and 1 
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); 
		GUI.depth = DrawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), FadeOutTexture);

	}

	public float BeginFade (int direction) {
		fadeDir = direction;
		return(fadeSpeed);
	
	
	}



	void OnLevelWasLoaded() {
		BeginFade (-1);



	}




}
