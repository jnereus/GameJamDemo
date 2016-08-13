using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScrollRoll : MonoBehaviour {
    private Scrollbar Bar;
	// Use this for initialization
	void Start () {
        Bar = GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RollLeft()
    {
        Bar.value = Bar.value - 1 / 8.0f;
    }

    public void RollRight()
    {
        Bar.value = Bar.value + 1 / 8.0f;
    }
}
