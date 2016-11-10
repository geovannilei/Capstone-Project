using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour {
    public string nextscene;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
            SceneManager.LoadScene(nextscene);
        }
    }
}
