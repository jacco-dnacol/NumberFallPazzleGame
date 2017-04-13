using UnityEngine;
using System.Collections;

public class TouchSystem : MonoBehaviour {
	private const int MOUSE_CLICK_LEFT = 0;
	private const int MOUSE_CLICK_RIGHT = 1;
	private const int MOUSE_CLICK_WHEEL = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(MOUSE_CLICK_LEFT) == true)
		{
			Debug.Log("Mouse：" + Input.mousePosition);
		}
	}
}
