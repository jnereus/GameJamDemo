using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameKernel : MonoBehaviour {
    public List<IGameManager> IGameManagerList = new List<IGameManager>();
	// Use this for initialization
	void Start () {
        IGameManagerList.Add(new ResourceManager().Create());
        IGameManagerList.Add(new TimeManager().Create());
        IGameManagerList.Add(new GameManager().Create());
        IGameManagerList.Add(new InputManager().Create());
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < IGameManagerList.Count; i++)
        {
            IGameManagerList[i].Update();
        }
	}
}
