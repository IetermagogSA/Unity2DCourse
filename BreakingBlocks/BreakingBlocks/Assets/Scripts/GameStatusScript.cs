using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusScript : MonoBehaviour {

    [Range(0.1f,20f)]
    [SerializeField] float myTimeScale;

	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = myTimeScale;
	}
}
