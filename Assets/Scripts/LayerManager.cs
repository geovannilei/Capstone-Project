using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LayerManager : MonoBehaviour {
    // Update is called once per frame
    
	public void LoadLevel (string s) {
        SceneManager.LoadScene(s);
	}
}
