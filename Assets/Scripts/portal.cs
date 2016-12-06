using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour {
    public string nextscene;
    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.E)))
		{
            SceneManager.LoadScene(nextscene);
        }
    }
	
	void OnTriggerExit2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.E)))
		{
            SceneManager.LoadScene(nextscene);
        }
    }
	
	void OnCollisionEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.E)))
		{
            SceneManager.LoadScene(nextscene);
        }
    }
	
	void OnCollisionExit2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.E)))
		{
            SceneManager.LoadScene(nextscene);
        }
    }
}
