﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public void changemenuscene()
	{
		Debug.Log ("hit1");
		Application.LoadLevel ("Bed Intro Level");
		Debug.Log ("hit");
	}
}
