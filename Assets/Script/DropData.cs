using UnityEngine;
using System.Collections;

public class DropData : MonoBehaviour {
	private int text_number = 0;
	private Vector2 pos = Vector2.zero;
	private int obj_id = 0;

	private bool is_create = false;
	// Use this for initialization
	void Start () {

		// サイズは可変することはない
		float sizeX = GetComponent<SpriteRenderer>().bounds.size.x;
		float sizeY = GetComponent<SpriteRenderer>().bounds.size.y;
		float scelaX = 1.0f / sizeX;
		float scelaY = 1.0f / sizeY;
		//transform.localScale = new Vector2(DropDataManager.DROP_SIZE, DropDataManager.DROP_SIZE);
		transform.localScale = new Vector2(scelaX, scelaY);

		///
		/// めんどくさいので見た目でサイズ決定。
		/// 後々計算でサイズが変わるようにすること
		GetComponent<BoxCollider2D>().size = new Vector2(0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 touch_vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Debug.Log("Mouse：" + Input.mousePosition);
		//Debug.Log("Mouse：" + touch_vec);

		Collider2D collition2d = Physics2D.OverlapPoint(touch_vec);
		if (collition2d)
		{
			Debug.Log(collition2d + "：" +obj_id + "番タッチ");
		}
	}

	/// <summary>
	/// 指定した数値を格納する
	/// ドロップ生成時にのみ使用
	/// </summary>
	/// <param name="in_num"></param>
	/// <param name="in_pos_id"></param>
	public void Create(int in_num, int in_pos_id )
	{
		if( is_create == true )
		{
			Debug.Log("すでに生成済みのドロップに数値を再設定しようとしています");
			return;
		}
		if( in_num < 0 || in_num > 9 )
		{
			Debug.Log("不正な数字を設定しようとしています：" + in_num);
			return;
		}
		if( in_pos_id >= (DropDataManager.DROP_HEIGHT_MAX*DropDataManager.DROP_WIDTH_MAX))
		{
			Debug.Log("不正なIDを設定しようとしています");
			return;
		}
		text_number = in_num;

		obj_id = in_pos_id;

		// 生成するオブジェクトの名前を設定
		// (ここで設定しないとすべてマテリアル名(Clone)になる)
		this.name = "DropMaterial" + obj_id;

		// 3D座標に変換
		Vector2 vec;
		vec.x = (in_pos_id % DropDataManager.DROP_WIDTH_MAX);
		vec.y = (in_pos_id / DropDataManager.DROP_HEIGHT_MAX);
		SetPos(vec);

		setSprite(obj_id);
		is_create = true;
	}

	/// <summary>
	/// 指定したposを設定する
	/// </summary>
	/// <param name="in_pos"></param>
	public void SetPos(Vector2 in_pos)
	{
		pos.x = in_pos.x;
		pos.y = in_pos.y;
		transform.position = in_pos;
	}

	/// <summary>
	/// 指定したIDに応じたスプライトを設定する
	/// </summary>
	/// <param name="in_pos_id"></param>
	public void setSprite(int in_pos_id)
	{
		Sprite image = Resources.Load<Sprite>("Image/TestSprite");
		SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
		sprite_renderer.sprite = image;
	}

	/// <summary>
	/// 数字を返す
	/// </summary>
	/// <returns></returns>
	public int GetNumber()
	{
		return text_number;
	}

	/// <summary>
	/// 位置を返す
	/// </summary>
	/// <returns></returns>
	public Vector2 GetPos()
	{
		return pos;
	}

	/// <summary>
	/// ID番号を返す
	/// </summary>
	/// <returns></returns>
	public int GetPosId()
	{
		return obj_id;
	}
}
