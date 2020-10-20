using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public float cameraHeight;

    void Update()
    {
        Vector3 position = player.transform.position;
        position.y += cameraHeight;
        transform.position = position;
    }
}
