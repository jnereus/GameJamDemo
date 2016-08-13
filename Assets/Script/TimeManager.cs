using UnityEngine;
using System.Collections;
using System;

public class TimeManager :IGameManager{
    public static TimeManager instance;
    public float EnemyDeltaTime;
    public float StageDeltaTime;
    public float PlayerDeltaTime;

    public float EnemyDeltaTimeScale = 1;
    public float StageDeltaTimeScale = 1;
    public float PlayerDeltaTimeScale = 1;


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
        EnemyDeltaTime = Time.deltaTime * EnemyDeltaTimeScale;
        PlayerDeltaTime = Time.deltaTime * PlayerDeltaTimeScale;
        StageDeltaTime = Time.deltaTime * PlayerDeltaTimeScale;
    }
    
}
