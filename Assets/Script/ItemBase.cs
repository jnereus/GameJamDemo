using UnityEngine;
using System.Collections;

public enum ItemType
{
    ProtectItem,
    invincibleItem,
    TimeSlowItem
}

public class ItemBase : MonoBehaviour {
    public string ItemName;
    private Vector3 Movement;
    public ItemType ItemType;
	// Use this for initialization
	void Start () {
        Movement = new Vector3(GameManager.instance.ItemSpeed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Movement = new Vector3(GameManager.instance.ItemSpeed, 0, 0);
        transform.Translate(Movement*Time.deltaTime);
	}
}
