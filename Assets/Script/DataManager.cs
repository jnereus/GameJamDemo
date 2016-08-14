using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {
    public static DataManager instance;
    // Use this for initialization
    public static bool _haveOne = false;

    public int currentIntegral;
    public float currentFarDis;

    void Start () {
        if (!_haveOne)
        {
            instance = this;
            DontDestroyOnLoad(this);
            _haveOne = true;
        }
        currentIntegral = GetIntegral();
        currentFarDis = GetCurrentHighScore();

    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    /// <summary>
    /// 保存高分
    /// </summary>
    public void SaveNewHighScore(float HighScore)
    {
        float CurrentHighScore = 0;
        CurrentHighScore = PlayerPrefs.GetFloat("HighScore",0);
        if(CurrentHighScore == 0)
        {
            PlayerPrefs.SetFloat("HighScore",HighScore);
        }
        else if (CurrentHighScore < HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", HighScore);
        }
    }

    /// <summary>
    /// 保存积分
    /// </summary>
    public void SaveIntegral(int Integral)
    {
        PlayerPrefs.SetInt("Integral", Integral);
    }
    
    public int GetIntegral()
    {
        return PlayerPrefs.GetInt("Integral", 0);
    }

    public float GetCurrentHighScore()
    {
        float CurrentHighScore = 0;
        CurrentHighScore = PlayerPrefs.GetFloat("HighScore",0.0f);
        if(CurrentHighScore == 0)
        {
            return 0;
        }
        else
        {
            return CurrentHighScore;
        }
    }
}
