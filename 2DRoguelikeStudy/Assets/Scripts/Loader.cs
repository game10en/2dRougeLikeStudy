using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
    public GameManager gamemanager;
	// Use this for initialization
	void Awake () {
        if(GameManager.instance==null)
        {
            Instantiate(gamemanager);
        }
	
	}
	
}
