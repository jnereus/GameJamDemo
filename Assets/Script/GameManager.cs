using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState
{
    Pause,
    GameOver,
    GameRunning,
    GameStart
}

public class GameManager : IGameManager {
    public static GameManager instance;
    public GameState GameState = GameState.GameStart;

    public GameObject MainPlayer;

    public float BaseSpeed = 2;
    //控制全局移动速度
    public float ItemSpeed = -2;
    public float BgRollSpeed = -2;

    public int HardLevel = 1;

    public List<GameObject> ItemList = new List<GameObject>();

    public GameObject TopUI;
    public GameObject GameOverUI;
    public GameObject PauseUI;

    public bool PauseUIShow = false;
    public bool GameOverUIShow = false;

    //积分，距离，高度
    //积分=星星积分+距离乘10
    public float currentDistance = 0;
    public int currentScore = 0;
    public float currentHigh = 0;
    public int eatShell = 0;
    public int eatPearl = 0;

    public float StartTime = 0;

    public bool isTimeSlow = false;

    public IGameManager Create()
    {
        instance = this;
        StartTime = Time.time;
        GameState = GameState.GameStart;
        Time.timeScale = 1;
        return instance;
    }

    public void Init()
    {
        throw new NotImplementedException();
    }

    public void Release()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        if (Time.time - StartTime > 13)
        {
            GameState = GameState.GameOver;
        }

        if(GameState == GameState.GameStart)
        {
            DrawBg();
            DrawPlayer();
            DrawUI();
            StartTime = Time.time;
            GameState = GameState.GameRunning;
        }

        if(GameState == GameState.GameRunning)
        {
            if (Time.time - StartTime > 40)
            {
                BgRollSpeed = BgRollSpeed+ (-BaseSpeed) *0.5f;
                StartTime = Time.time;
                HardLevel += 1;
            }
            currentHigh = 5+MainPlayer.transform.position.y;
            currentDistance = -BgRollSpeed * Time.deltaTime + currentDistance;
            currentScore = eatPearl * 50 + eatShell * 200 + (int)currentDistance * 10;
            //Debug.Log(UnityEngine.Random.Range(0,100));
            if (PauseUIShow == true) {
                PauseUI.transform.localScale = Vector3.zero;
            }
        }

        if(GameState == GameState.GameOver)
        {
            //显示死亡UI
            if(GameOverUIShow == false)
            {
                GameOverUI.transform.localScale = Vector3.one;
                if (DataManager.instance.GetCurrentHighScore() < currentDistance)
                {
                    //显示是新纪录
                    GameObject NewHigh = GameOverUI.transform.FindChild("NewHigh").gameObject;
                    NewHigh.transform.localScale = Vector3.one;
                    DataManager.instance.SaveNewHighScore(GameManager.instance.currentDistance);
                }
            }
            Time.timeScale = 0;
        }
        if (GameState == GameState.Pause)
        {
            if (PauseUIShow == false)
            {
                PauseUIShow = true;
                PauseUI.transform.localScale = Vector3.one;
            }
            Time.timeScale = 0;
        }
    }

    public void DrawPlayer()
    {
        MainPlayer = UnityEngine.Object.Instantiate(ResourceManager.instance.MainPlayerPrefab);
    }

    public void DrawEnemy()
    {

    }

    public void DrawItem(ItemType ItemType,Vector3 DrawPosition)
    {
        switch (ItemType)
        {
            case ItemType.ProtectItem:
                ItemList.Add(
                    UnityEngine.Object.Instantiate(ResourceManager.instance.ProtectItemPrefab, 
                                                   DrawPosition, 
                                                   Quaternion.identity
                                                   ) as GameObject
                            );
                break;
            case ItemType.invincibleItem:
                ItemList.Add(
                    UnityEngine.Object.Instantiate(ResourceManager.instance.invincibleItemPrefab,
                                                   DrawPosition,
                                                   Quaternion.identity
                                                   ) as GameObject
                            );
                break;
            case ItemType.TimeSlowItem:
                ItemList.Add(
                    UnityEngine.Object.Instantiate(ResourceManager.instance.TimeSlowItemPrefab,
                                                   DrawPosition,
                                                   Quaternion.identity
                                                   ) as GameObject
                            );
                break;
        }
    }

    public void DrawBg()
    {
        UnityEngine.Object.Instantiate(ResourceManager.instance.Bg_01Prefab);
    }

    public void DrawUI()
    {
        GameObject MainCanvas =  GameObject.Find("Canvas") ;
        TopUI = UnityEngine.Object.Instantiate(ResourceManager.instance.TopUIPrefab);
        GameOverUI = UnityEngine.Object.Instantiate(ResourceManager.instance.GameOverUIPrefab);
        PauseUI = UnityEngine.Object.Instantiate(ResourceManager.instance.PauseUIPrefab);
        TopUI.transform.SetParent(MainCanvas.transform,false);
        GameOverUI.transform.SetParent(MainCanvas.transform,false);
        PauseUI.transform.SetParent(MainCanvas.transform,false);
    }
    
}
