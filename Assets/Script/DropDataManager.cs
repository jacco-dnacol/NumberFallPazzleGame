using UnityEngine;
using System.Collections;

public class DropDataManager : MonoBehaviour {
	public const int DROP_WIDTH_MAX = 4;
	public const int DROP_HEIGHT_MAX = 4;
	public const int DROP_DATA_DIGIT_MAX = 9; // 0～9の10パターン
	public const float DROP_SIZE = 2;

	GameObject[,] drop_data = new GameObject[DROP_HEIGHT_MAX,DROP_WIDTH_MAX];

	// Use this for initialization
	void Start () {
		GameObject prefab = (GameObject)Resources.Load("Material/DropMaterial");
		for(int i = 0; i < DROP_HEIGHT_MAX; i++)
		{
			for(int j = 0; j < DROP_WIDTH_MAX; j++)
			{
				drop_data[i, j] = (GameObject)Instantiate(prefab, Vector2.zero, Quaternion.identity);
				int digit = Random.Range(0, DROP_DATA_DIGIT_MAX);
				int id = j + (i * DROP_HEIGHT_MAX);
				drop_data[i, j].GetComponent<DropData>().Create(digit, id);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
