
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class changeScene : MonoBehaviour {
	
		
	public void Restart(string changeTheScene){
		print ("yesss");
		SceneManager.LoadScene ("Shift");
	}

}
