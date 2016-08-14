using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class IconBase : MonoBehaviour,IPointerClickHandler {
    public int IconId;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Buy"+IconId);
        PlayerPrefs.SetInt(""+IconId,1);
    }
}
