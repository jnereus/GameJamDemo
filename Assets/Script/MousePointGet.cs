using UnityEngine;
using System.Collections;

public class MousePointGet : MonoBehaviour {
    public Vector3 MousePosition;
    public GameObject Wire;
    public float offset =4;
	// Use this for initialization
	void Start () {
        offset = 4;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        MousePosition = new Vector3(ray.origin.x, -offset, -1);
        Vector3 direction = Wire.transform.position - MousePosition;
        Wire.transform.rotation =  Quaternion.AngleAxis( Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI-90,new Vector3(0, 0, 1));
    }
}
