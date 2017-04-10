using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour {

    public int flySpeed = 5;

    private Transform target;

    void Start()
    {
        target = transform.parent.parent.GetComponent<CheckEnemy>().bulletTarget.transform;
    }
	// Update is called once per frame
	void Update () {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * flySpeed * Time.deltaTime, target);
	}
}
