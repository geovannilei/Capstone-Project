using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LayerManager : MonoBehaviour {
    public void LoadLevel(string s) {
        SceneManager.LoadScene(s);
    }



}
