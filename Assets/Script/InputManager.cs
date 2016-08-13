using UnityEngine;
using System.Collections;
using System;

public class InputManager : IGameManager {
    public static InputManager instance;
    private MousePointGet MousePointGet;
    public Camera MainCamera;
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

    void IGameManager.Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pull");
            GameManager.instance.MainPlayer.GetComponent<Player>().Pull();
        }
        if (Input.GetMouseButton(0))
        {
            GameManager.instance.MainPlayer.GetComponent<Player>().Pull();
        }
    }
    

}
