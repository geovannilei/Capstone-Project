using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	public static int playerHealth;

	//Text text;
	public Slider healthBar;

	public bool isDead;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		healthBar = GetComponent<Slider>();

		playerHealth = maxPlayerHealth;

		isDead = false;
			
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead == true) Application.LoadLevel(Application.loadedLevel);
        
        if (playerHealth <= 0 && !isDead)
		{
			playerHealth = 0;
			isDead = true;
		}

		//text.text = "" + playerHealth;
		healthBar.value = playerHealth;
	
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Spike")
        {
            isDead = true;
        }
    }
}
