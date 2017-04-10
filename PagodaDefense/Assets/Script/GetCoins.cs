using UnityEngine;
using UnityEngine.UI;

public class GetCoins : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "金币：" + GameManager.instance.getCoins;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "金币：" + GameManager.instance.getCoins;
	}
}
