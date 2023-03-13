using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCameraBox : MonoBehaviour
{
    private Camera cam;
    private BoxCollider2D  camBox;
    private float sizeX, sizeY, ratio;

    void Start()
    {
        cam = GetComponent<Camera>();
        camBox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        ratio = (float)Screen.width/(float)Screen.height;
        sizeX = cam.orthographicSize * 2;
        sizeY = sizeY * ratio;
        camBox.size = new Vector2(sizeX, sizeY);
    }
}
