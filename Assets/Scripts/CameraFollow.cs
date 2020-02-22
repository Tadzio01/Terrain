using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private GameObject player; 
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0,0,-10);
    }
}