using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionFunc;
using UnityEngine.EventSystems;


public class JoyStickControlCamera : MonoBehaviour {

    public RectTransform leftJoyStick;
    public RectTransform rightJoyStick;

    public float moveSpeed = 20;
    public float rotateSpeed = 6;
    public float selfYSpeed = 20;

    private bool isCanMove;
    private bool isCanRoate;

    void Update()
    {
        if (isCanMove)
        {
            transform.Translate(new Vector3(leftJoyStick.anchoredPosition.normalized.x, 0, leftJoyStick.anchoredPosition.normalized.y) * moveSpeed * Time.deltaTime, Space.World);
        }

        if (isCanRoate)
        {
            if (rightJoyStick.anchoredPosition.normalized.y > -0.3 && rightJoyStick.anchoredPosition.normalized.y < 0.3)
            {
                transform.Rotate(Vector3.right * rightJoyStick.anchoredPosition.normalized.x, Time.deltaTime * rotateSpeed, Space.Self);
            }
            else if (rightJoyStick.anchoredPosition.normalized.x > -0.3 && rightJoyStick.anchoredPosition.normalized.x < 0.3)
            {
                transform.Translate(new Vector3(0, rightJoyStick.anchoredPosition.normalized.y, 0) * selfYSpeed * Time.deltaTime, Space.World);
            }
            
            
        }

        LimitArea();
        LimitRotation();
    }

    public void CanMove()
    {
        isCanMove = true;
    }
    public void StopMove()
    {
        isCanMove = false;
    }

    public void CanRotate()
    {
        isCanRoate = true;
    }
    public void StopRotate()
    {
        isCanRoate = false;
    }

    void LimitArea()
    {
        if (transform.position.x < -120)
        {
            transform.position = transform.position.NewX(-120);
        }
        else if (transform.position.x > 120)
        {
            transform.position = transform.position.NewX(120);
        }
        else if (transform.position.y > 80)
        {
            transform.position = transform.position.NewY(80);
        }
        else if (transform.position.y < 20)
        {
            transform.position = transform.position.NewY(20);
        }
        else if (transform.position.z > 110)
        {
            transform.position = transform.position.NewZ(110);
        }
        else if (transform.position.z < -40)
        {
            transform.position = transform.position.NewZ(-40);
        }
    }

    void LimitRotation()
    {
        if (transform.localEulerAngles.x < 20)
        {
            transform.rotation = Quaternion.Euler(new Vector3(20, transform.rotation.y, transform.rotation.z));
        }
        else if (transform.localEulerAngles.x > 80)
        {
            transform.rotation = Quaternion.Euler(new Vector3(80, transform.rotation.y, transform.rotation.z));
        }
    }
}
