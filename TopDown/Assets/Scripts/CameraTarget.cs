using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float threshold;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = player.input.GetCursorScreenToWorldPoint();
        Vector3 targetPos = (player.transform.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.transform.position.x, threshold + player.transform.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.transform.position.y, threshold + player.transform.position.y);

        this.transform.position = targetPos;
    }
}
