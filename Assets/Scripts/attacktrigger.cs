using UnityEngine;
using System.Collections;

public class attacktrigger : MonoBehaviour
{
    private bool attacking = false;
    public Collider2D attackTriggerright;
    public Collider2D attackTriggerleft;
    public Animator anim;
    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTriggerright.enabled = false;
        attackTriggerleft.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && attacking == false)
        {
            attacking = true;
            attackTriggerright.enabled = true;
            attackTriggerleft.enabled = true;
            anim.SetBool("attack", true);
        }

        if (Input.GetKeyUp(KeyCode.F) && attacking == true)
        {
            attacking = false;
            attackTriggerleft.enabled = false;
            attackTriggerright.enabled = false;
            anim.SetBool("attack", false);
        }
    }
}
