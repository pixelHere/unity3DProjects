using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyMode {
    Enemy1,
    Enemy2,
    Enemy3
}

[System.Serializable]
public class EnemyConfig {
    public GameObject enemyPrefab;
    public int coin;
    public int socre;
    public int health;
    public float rate;
    public int numberOfCreateEnemy;
}
[System.Serializable]
public class EnemyNumber
{
    public static int enemyNum;
}

[System.Serializable]
public class SkillNumberConfig
{
    public string typeName;
    public int skillCount;
}

[System.Serializable]
public class BatteryConfig
{
    public GameObject batteryPre;
    public string name;
    public int price;
    public float existTime;
}
[System.Serializable]
public class BulletConfig
{
    public GameObject bulletPre;
    public GameObject bulletEffect;
    public int Damage;
}
[System.Serializable]
public class ShellConfig
{
    public GameObject shellPre;
    public GameObject shellEffect;
    public int Damage;
}

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public float goSpeed = 10;
    public float sideSpeed = 10;
    public float MouseWheelSpeed = 500;
    public float androidScaleSpeed = 20;

    public float enemy1Speed = 8.0f;
    public float enemy2Speed = 12.0f;
    public float enemy3Speed = 16.0f;

    public EnemyConfig[] enemyConfigs;
    public BatteryConfig[] batteryConfig;
    public BulletConfig[] bulletConfig;
    public ShellConfig[] shellConfig;

    public Image templateImage;
    public SkillNumberConfig[] skill;
    private int skillCount;
    private BatteryConfig batteryIndex;
    public bool hasChooseSkillImage { set; get; }
    public int bulletIndex { set; get; }
    public int shellIndex { set; get; }

    private int Coins = 1000;
    public int getCoins
    {
        set { Coins = value; }
        get { return Coins; }
    }

    private Dictionary<string, Sprite> pagodaIcons = new Dictionary<string, Sprite>();

    void Awake () {
        instance = this;
	}
    void Start()
    {
        LoadPagodasSprite();
    }

    void LoadPagodasSprite()
    {
        Sprite[] sp = Resources.LoadAll<Sprite>("Sprites");

        foreach (Sprite item in sp)
        {
            pagodaIcons.Add(item.name, item);
        }

    }

    public void SubSkillCount(string skillName)
    {
        foreach (var item in skill)
        {
            if (item.typeName == skillName)
            {
                item.skillCount--;
            }
        }

    }

    public int GetSkillCount(string skillName)
    {
        foreach (var item in skill)
        {
            if (item.typeName == skillName)
            {
                skillCount = item.skillCount;
            }
        }
        return skillCount;
    }

    public Sprite GetItemSprite(string imageName)
    {
        if (pagodaIcons.ContainsKey(imageName))
        {
            return pagodaIcons[imageName];
        }
        return null;
    }
    public BatteryConfig GetBatteryIndexByName(string objName)
    {
        switch (objName)
        {
            case "type1":
                batteryIndex = batteryConfig[0];
                break;
            case "type2":
                batteryIndex = batteryConfig[1];
                break;
            case "type3":
                batteryIndex = batteryConfig[2];
                break;
        }
        return batteryIndex;
    }

    public BatteryConfig GetBatteryIndex(int index){
        return batteryConfig[index];
    }

}
