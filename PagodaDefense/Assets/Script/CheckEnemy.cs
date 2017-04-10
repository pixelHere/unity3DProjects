using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour {

    
    private List<GameObject> enemyList = new List<GameObject>();

    private float currentTime;
    private float timer = 0.3f;
    private GameObject ammunition;

    public Transform fire;
    
    public GameObject bulletTarget;

    void Start()
    {
        currentTime = timer;
        ChooseAmmunition();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer && enemyList.Count > 0)
        {
            currentTime = 0;
            CreateAmmunition();
        }
        if (enemyList.Count > 0)
        {
            bulletTarget = enemyList[0];
        }
    }


    void CreateAmmunition()
    {
        GameObject go = GameObject.Instantiate(ammunition, fire.position, Quaternion.identity);
        go.transform.SetParent(transform.FindChild("Ammunitions"));
    }


    void ChooseAmmunition()
    {
        switch (gameObject.name)
        {
            case "type1":
                ammunition=GameManager.instance.bulletConfig[GameManager.instance.bulletIndex].bulletPre;
                break;
            case "type2":
                ammunition = GameManager.instance.shellConfig[GameManager.instance.shellIndex].shellPre;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyList.Remove(other.gameObject);
        }
    }


}
