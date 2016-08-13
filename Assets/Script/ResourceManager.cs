using UnityEngine;
using System.Collections;
using System;

public class ResourceManager : IGameManager
{
    public static ResourceManager instance;

    public GameObject MainPlayerPrefab;

    public GameObject ProtectItemPrefab;
    public GameObject invincibleItemPrefab;
    public GameObject TimeSlowItemPrefab;

    public GameObject Bg_01Prefab;

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
}
