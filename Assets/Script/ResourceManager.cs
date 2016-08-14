using UnityEngine;
using System.Collections;
using System;

public class ResourceManager : IGameManager
{
    public static ResourceManager instance;

    public GameObject MainPlayerPrefab;
    //道具
    public GameObject ProtectItemPrefab;
    public GameObject invincibleItemPrefab;
    public GameObject TimeSlowItemPrefab;
    //背景
    public GameObject Bg_01Prefab;
    //UI界面
    public GameObject GameOverUIPrefab;
    public GameObject TopUIPrefab;
    public GameObject PauseUIPrefab;

    public IGameManager Create()
    {
        instance = this;
        Init();
        return instance;
    }

    public void Init()
    {
        instance.LoadPlayer();
        instance.LoadEnemy();
        instance.LoadBg();
        instance.LoadUI();
    }

    public void Release()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        //throw new NotImplementedException();
    }

    public void LoadPlayer()
    {
        MainPlayerPrefab = Resources.Load("Prefabs/Player") as GameObject;
    }

    public void LoadEnemy()
    {

    }

    public void LoadItem()
    {

    }

    public void LoadBg()
    {
        Bg_01Prefab = Resources.Load("Prefabs/Bg_01") as GameObject;
    }

    public void LoadUI()
    {
        TopUIPrefab = Resources.Load("Prefabs/TopUI") as GameObject;
        PauseUIPrefab = Resources.Load("Prefabs/PauseUI") as GameObject;
        GameOverUIPrefab = Resources.Load("Prefabs/GameOverUI") as GameObject;
    }
}
