using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum PlayerBuffType
{
    Invincible,
    Protect
}

public class PlayerBuff
{
    public PlayerBuffType PlayerBuffType;
    public float BuffLifeTime;
    public PlayerBuff(PlayerBuffType playerBuffType,float BuffLifeTime)
    {
        PlayerBuffType = playerBuffType;
        this.BuffLifeTime = BuffLifeTime;
    }
}


public class Player : MonoBehaviour {

    public float flyUpSpeed;
    public float MoveMent;
    public float PullSpeed;
    public Vector3 MousePosition;
    
    public GameObject Wire;
    public float offset = 4;

    public List<PlayerBuff> PlayerBuffList = new List<PlayerBuff>(); 

    public void Pull()
    {
        Vector3 Pull =  transform.position - MousePosition;
        Vector3 PullDir = Pull.normalized;
        transform.position = Vector3.Lerp(transform.position, -PullDir * PullSpeed + transform.position,0.1f);
    }


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,flyUpSpeed*TimeManager.instance.PlayerDeltaTime,0));
        WireToMouse();
    }

    void WireToMouse()
    {
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        MousePosition = new Vector3(ray.origin.x, -offset, -1);
        Vector3 direction = Wire.transform.position - MousePosition;
        Wire.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90, new Vector3(0, 0, 1));
    }

    void UpdateBuff()
    {

        for(int i = 0; i < PlayerBuffList.Count; i++)
        {
            PlayerBuffList[i].BuffLifeTime = PlayerBuffList[i].BuffLifeTime - Time.deltaTime;
        }

        for(int i = PlayerBuffList.Count-1; i >= 0; i--)
        {
            if (PlayerBuffList[i].BuffLifeTime < 0)
            {
                PlayerBuffList.RemoveAt(i);
            }
        }
    }

    bool haveBuff(PlayerBuffType PlayerBuffType)
    {
        for (int i = 0; i < PlayerBuffList.Count; i++)
        {
            if(PlayerBuffList[i].PlayerBuffType == PlayerBuffType)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 在玩家的buff列表中新增buff，如果重复则刷新持续时间，如果不存在则添加
    /// </summary>
    /// <param name="PlayerBuffType">buff类型</param>
    /// <param name="BuffLifeTime">持续时间</param>
    void AddBuff(PlayerBuffType PlayerBuffType,float BuffLifeTime)
    {
        bool haveThisBuff = false;
        for(int i = 0; i < PlayerBuffList.Count; i++)
        {
            if(PlayerBuffList[i].PlayerBuffType == PlayerBuffType)
            {
                PlayerBuffList[i].BuffLifeTime = BuffLifeTime;
                haveThisBuff = true;
            }
        }
        if(haveThisBuff == false)
        {
            PlayerBuffList.Add(new PlayerBuff(PlayerBuffType,BuffLifeTime));
        }
    }
    /// <summary>
    /// 按照类型在玩家的buff列表中移除buff
    /// </summary>
    /// <param name="PlayerBuffType">buff类型</param>
    void RemoveBuff(PlayerBuffType PlayerBuffType)
    {
        for (int i = PlayerBuffList.Count - 1; i >= 0; i--)
        {
            if (PlayerBuffList[i].PlayerBuffType == PlayerBuffType)
            {
                PlayerBuffList.RemoveAt(i);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Enemy")
        {
            //判断是否存在抵挡效果，若不存在则结束游戏
            if (!haveBuff(PlayerBuffType.Invincible) && !haveBuff(PlayerBuffType.Protect))
            {
                GameManager.instance.GameState = GameState.GameOver;
            }
            //判断存在的是无敌还是抵挡一次攻击，如果只存在抵挡一次攻击则将抵挡效果消除
            if (!haveBuff(PlayerBuffType.Invincible))
            {
                if (haveBuff(PlayerBuffType.Protect))
                {
                    RemoveBuff(PlayerBuffType.Protect);
                }
            }
        }

        if(c.tag == "DmgProtectItem")
        {
            AddBuff(PlayerBuffType.Protect, 9999.0f);
        }
        if(c.tag == "InvincibleItem")
        {
            AddBuff(PlayerBuffType.Invincible, 5.0f);
        }
    }
}
