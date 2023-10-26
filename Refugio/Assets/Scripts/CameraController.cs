using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 2, 0, -10); // Camera follows the player but 2 to the right
    }
}