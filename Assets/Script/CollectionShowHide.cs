using UnityEngine;
using System.Collections;

public class CollectionShowHide : MonoBehaviour {
    public GameObject CollectionPanel;
    private bool isCollectionShow;
	// Use this for initialization
	void Start () {
        isCollectionShow = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void click()
    {
        if (isCollectionShow)
        {
            CollectionPanel.transform.localScale = Vector3.zero;
            isCollectionShow = false;
        }
        else
        {
            CollectionPanel.transform.localScale = Vector3.one;
            isCollectionShow = true;
        }

    }
}
