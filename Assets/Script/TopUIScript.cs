using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TopUIScript : MonoBehaviour {
    public Text DistanceText;
    public Text HighText;
    public Text ScoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DistanceText.text = GameManager.instance.currentDistance.ToString("f1")+"丈";
        HighText.text = GameManager.instance.currentHigh.ToString("f1") + "丈";
        ScoreText.text = GameManager.instance.currentScore + "分";
	}
}
