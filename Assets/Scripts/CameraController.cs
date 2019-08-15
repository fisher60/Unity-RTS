using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 mouseOriginPoint;
    private Vector3 offset;
    private bool dragging;
    [SerializeField]
    private int speed;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")
                * (10f * Camera.main.orthographicSize * .1f), 2.5f, 20f);
            if (Input.GetMouseButton(2))
            {
                offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                if (!dragging)
                {
                    dragging = true;
                    mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                dragging = false;
            }
            if (dragging)
            {
                transform.position = mouseOriginPoint - offset;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
    }
}
