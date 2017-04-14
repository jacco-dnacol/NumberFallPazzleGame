using UnityEngine;
using UnityEngine.UI;
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
		// マウス押下中
		if(Input.GetMouseButton(MOUSE_CLICK_LEFT) == true)
		{
			// 座標変換
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log("Mouse：" + pos);
		}

		// マウスが押下状態から非押下状態になった時
		if(Input.GetMouseButtonUp(MOUSE_CLICK_LEFT) == true)
		{
			///
			/// 非押下状態になった時の処理
			///
		}
	}
}
