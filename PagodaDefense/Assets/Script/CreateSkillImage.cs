using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateSkillImage : MonoBehaviour {

    public int index;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(() => CreateImage());
	}
	
	void CreateImage() {
        if (GameManager.instance.getCoins >= GameManager.instance.GetBatteryIndex(index).price && !GameManager.instance.hasChooseSkillImage)
        {
            Image go = Instantiate(GameManager.instance.templateImage, GameController.getInstance().canvas, true);
            go.rectTransform.position = transform.position;
            go.rectTransform.localScale = new Vector3(1, 1, 1);
            go.name = transform.name;
            go.sprite = GameManager.instance.GetItemSprite(gameObject.name);
            GameManager.instance.hasChooseSkillImage = true;
        }

    }

}
