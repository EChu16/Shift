
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class changeScene : MonoBehaviour {

	public void changeToScene(int changeTheScene){
		SceneManager.LoadScene (changeTheScene);
	}

}
