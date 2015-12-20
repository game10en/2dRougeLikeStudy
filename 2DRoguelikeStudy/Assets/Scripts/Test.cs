using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	for(int i = 1; i < 11; i++)
        {
            float fAnswer = Mathf.Log(i, 2f);
            int intAnswer1 = (int)fAnswer;
            int intAnswer2 = (int)Mathf.Log(i, 2f);

            Debug.Log(i + " fAnswer=" + fAnswer + ", intAnswer1=" + intAnswer1 + ", intAnswer2=" + intAnswer2);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
