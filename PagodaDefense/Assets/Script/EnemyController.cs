using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnemyMode enemyMode;
    private float speed;
    private int wayIndex;
    // Use this for initialization
    void Start() {
        EnemySpeed();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }


    void EnemySpeed() {
        if (enemyMode == EnemyMode.Enemy1) {
            speed = GameManager.instance.enemy1Speed;
        } else if (enemyMode == EnemyMode.Enemy2) {
            speed = GameManager.instance.enemy2Speed;
        } else if (enemyMode == EnemyMode.Enemy3) {
            speed = GameManager.instance.enemy3Speed;
        }
    }

    void Move() {
        if (wayIndex >= GameController.getInstance().wayPoints.Length) return;
        transform.Translate((GameController.getInstance().wayPoints[wayIndex].position - transform.position).normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, GameController.getInstance().wayPoints[wayIndex].position) < 0.2f) {
            wayIndex++;
        }
    }
    void OnDestroy() {

    }
}
