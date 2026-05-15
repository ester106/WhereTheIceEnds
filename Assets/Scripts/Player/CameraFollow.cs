using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject Player;
    private GameObject Background;
    private Vector3 offset = new Vector3(0f, 1f, -1f);

    void Awake()
    {
        Player = GameObject.Find("Player");
        Background = GameObject.Find("background");
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x,
            Player.transform.position.y, 0) + offset;
        Background.transform.position = new Vector3(transform.position.x, transform.position.y, Background.transform.position.z);
    }
}
