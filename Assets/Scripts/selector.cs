using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selector : MonoBehaviour {

    private List<GameObject> models;
    private static int selectionIndex = 0;
    private  int num = 0;
    // Use this for initialization
    void Start() {

        models = new List<GameObject>();
        foreach (Transform t in transform) {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
    }

    public void left() {
        if (num == 0)
        {
            num = 2;
        }
        else if (num > 0)
            {
            num = num -1;
        }

    }

    public void right() {
        if (num == 2)
        {
            num = 0;
        }
        else {
            num = num +1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (selectionIndex == num)
        {
            models[selectionIndex].SetActive(true);
        }
        else
        {
            models[selectionIndex].SetActive(false);
            selectionIndex = num;
            models[selectionIndex].SetActive(true);
        }
    }

    public static int playerint()
    {
        return selectionIndex;
    }
}
