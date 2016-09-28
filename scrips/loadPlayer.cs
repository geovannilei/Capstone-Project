using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class loadPlayer : MonoBehaviour {
    private List<GameObject> models;

    void Start () {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        models[selector.playerint()].SetActive(true);
    }
}
