using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour {
    public int point=0;
    public Text pointText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pointText.text=("SCORE: "+point);
	}
}
