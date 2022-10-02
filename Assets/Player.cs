using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        UpdateMove();
    }

    private void UpdateMove()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) // z 앞뒤
            move.z = 1;
        if (Input.GetKey(KeyCode.S))
            move.z = -1;
        if (Input.GetKey(KeyCode.A)) // x 사이드, // 왼쪽.
            move.x = -1;
        if (Input.GetKey(KeyCode.D)) // 오른쪽
            move.x = 1;

        // move 움직임이 있다면 런 애니메이션 해라.
        // 움직임이 없다면 idle애니메이션 해라.
        float forward = move.z;
        float side = move.x;
        move = move * speed * Time.deltaTime;
        transform.Translate(move);
    }
}
