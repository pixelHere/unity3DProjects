using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetSkillNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "×" + GameManager.instance.GetSkillCount(transform.parent.name);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "×" + GameManager.instance.GetSkillCount(transform.parent.name);
	}

}
