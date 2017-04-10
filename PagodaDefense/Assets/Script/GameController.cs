using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionFunc;

public class GameController : MonoBehaviour
{

    private static GameController _instance;
    public static GameController getInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<GameController>();
        }
        return _instance;
    }

    public GameObject buildEffect;
    public Transform canvas { get; set; }
    public Transform[] wayPoints;
    private Transform enemySpawn;
    private Transform pagodas;
    private int enemyIndex;

    private Ray ray;
    private RaycastHit rayHit;


    void Start()
    {
        enemySpawn = GameObject.Find("EnemySpawn").transform;
        canvas = GameObject.Find("Canvas").transform;
        pagodas = GameObject.Find("Pagodas").transform;
    }

    void Update()
    {
        if (EnemyNumber.enemyNum == 0)
        {
            CreateEnemy(enemyIndex);
        }
        if (enemySpawn.childCount == 0 && EnemyNumber.enemyNum == GameManager.instance.enemyConfigs[enemyIndex].numberOfCreateEnemy)
        {
            enemyIndex++;
            EnemyNumber.enemyNum = 0;
        }

    }


    /// <summary>
    /// Enemy Spawn
    /// </summary>
    void CreateEnemy(int enemyIndex)
    {
        StartCoroutine(InstantiateEnemy(enemyIndex));
    }

    IEnumerator InstantiateEnemy(int index)
    {
        for (int i = 0; i < GameManager.instance.enemyConfigs[index].numberOfCreateEnemy; )
        {
            GameObject go = Instantiate(GameManager.instance.enemyConfigs[index].enemyPrefab, enemySpawn);
            go.name = GameManager.instance.enemyConfigs[index].enemyPrefab.name;
            EnemyNumber.enemyNum++;
            yield return new WaitForSeconds(GameManager.instance.enemyConfigs[index].rate);
            i++;
        }
    }


    public void RayCheck(string name)
    {
#if UNITY_EDITOR
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject != null && rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Map"))
            {
                if (GameManager.instance.hasChooseSkillImage)
                {
                    rayHit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    GameObject go = Instantiate(GameManager.instance.GetBatteryIndexByName(name).batteryPre, pagodas, false);
                    go.name = name;
                    go.transform.position = rayHit.transform.position.NewY(0.4f);
                    GameManager.instance.getCoins -= GameManager.instance.GetBatteryIndexByName(name).price;
                    if (GameManager.instance.getCoins <= 0)
                    {
                        GameManager.instance.getCoins = 0;
                    }
                    GameObject effect = Instantiate(buildEffect, go.transform.position,Quaternion.identity);
                    Destroy(effect, 1);
                }
                else
                {
                    Debug.Log("金币不足");
                }
            }
        }
#elif UNITY_ANDROID
        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject != null && rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Map"))
            {
                if (GameManager.instance.hasChooseSkillImage)
                {
                    rayHit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    GameObject go = Instantiate(GameManager.instance.GetBatteryIndexByName(name).batteryPre, pagodas, false);
                    go.name = name;
                    go.transform.position = rayHit.transform.position.NewY(0.4f);
                    GameManager.instance.getCoins -= GameManager.instance.GetBatteryIndexByName(name).price;
                    if (GameManager.instance.getCoins <= 0)
                    {
                        GameManager.instance.getCoins = 0;
                    }
                    GameObject effect = Instantiate(buildEffect, go.transform.position,Quaternion.identity);
                    Destroy(effect, 1);
                }
                else
                {
                    Debug.Log("金币不足");
                }
            }
        }
#endif

    }
}
