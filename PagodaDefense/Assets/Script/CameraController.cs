using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ExtensionFunc;

public class CameraController : MonoBehaviour {

    private float startDis;
    // Update is called once per frame
    void Update() {
        if (Application.platform == RuntimePlatform.WindowsEditor) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float m = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log(m);
            transform.Translate(new Vector3(h * GameManager.instance.sideSpeed, -m * GameManager.instance.MouseWheelSpeed, v * GameManager.instance.goSpeed) * Time.deltaTime, Space.World);
        } else if (Application.platform == RuntimePlatform.Android) {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                
            }
            else
            {
                if (Input.touchCount > 0 && Input.touchCount == 1)
                {
                    float h = Input.GetTouch(0).deltaPosition.x * GameManager.instance.sideSpeed;
                    float v = Input.GetTouch(0).deltaPosition.y * GameManager.instance.goSpeed;
                    transform.Translate(new Vector3(-h, 0, -v) * Time.deltaTime, Space.World);
                }
                else if (Input.touchCount > 1)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        startDis = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
                    {
                        Vector2 dis1 = Input.GetTouch(0).position;
                        Vector2 dis2 = Input.GetTouch(1).position;
                        float offsetDis = Vector2.Distance(dis1, dis2);

                        if (offsetDis < startDis)
                        {
                            float offsetY = transform.position.y;
                            offsetY -= GameManager.instance.androidScaleSpeed * Time.deltaTime;
                            transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
                        }
                        else
                        {
                            float offsetY = transform.position.y;
                            offsetY += GameManager.instance.androidScaleSpeed * Time.deltaTime;
                            transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
                        }
                    }
                }
            }
        }
        LimtArea();
    }

    void LimtArea()
    {
        if (transform.position.x < -120)
        {
            transform.position = transform.position.NewX(-120);
        }
        else if (transform.position.x > 120)
        {
            transform.position = transform.position.NewX(120);
        }
        else if (transform.position.y > 160)
        {
            transform.position = transform.position.NewY(160);
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
}
