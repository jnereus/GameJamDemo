using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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
    
    
    //控制全局移动速度
    public float ItemSpeed = -2;
    public float BgRollSpeed = -2;

    public List<GameObject> ItemList = new List<GameObject>();

    public IGameManager Create()
    {
        instance = this;
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
        if(GameState == GameState.GameStart)
        {
            DrawBg();
            DrawPlayer();
            GameState = GameState.GameRunning;
        }

        if(GameState == GameState.GameRunning)
        {
            //Debug.Log(UnityEngine.Random.Range(0,100));
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
}
