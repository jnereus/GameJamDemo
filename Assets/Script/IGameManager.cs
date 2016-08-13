using UnityEngine;
using System.Collections;

public interface IGameManager {
    //创造Manager
    IGameManager Create();
    //初始化Manager
    void Init();
    //释放资源
    void Release();

    void Update();
}
