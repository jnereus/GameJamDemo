using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BackStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnBackStartNoOver()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnBackStartOver()
    {
        int currentIntegral;
        currentIntegral = DataManager.instance.GetIntegral();
        DataManager.instance.SaveIntegral(currentIntegral + GameManager.instance.currentScore);
        DataManager.instance.currentIntegral = DataManager.instance.GetIntegral();
        DataManager.instance.currentFarDis = DataManager.instance.GetCurrentHighScore();
        SceneManager.LoadScene("StartScene");
    }
}
