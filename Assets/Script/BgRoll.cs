using UnityEngine;
using System.Collections;

public class BgRoll : MonoBehaviour {
    public float Speed;
    public float changePosition;
    public float changeTargetPosition;
    private Vector3 Movement;
	// Use this for initialization
	void Start () {
        Movement = new Vector3(GameManager.instance.BgRollSpeed*Time.deltaTime,0,0);
        changePosition = -16.49f;
        changeTargetPosition = 16.70f;
    }
	
	// Update is called once per frame
	void Update () {
        Movement = new Vector3(GameManager.instance.BgRollSpeed*Time.deltaTime, 0, 0);
        if (transform.position.x <= changePosition)
        {
            transform.position = new Vector3(changeTargetPosition,0,0);
        }
        transform.Translate(Movement);
	}
}
