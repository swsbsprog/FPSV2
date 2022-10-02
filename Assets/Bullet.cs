using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 앞으로 이동
    public Rigidbody rb;
    public float speed = 1;
    private void Start()
    {
        //월드 방향으로 로컬로 바꿔서 힘을 주자.
        // 월드 힘이 아니라  -> 로컬 힘을 주자.
        var force = transform.forward * speed;
        rb.AddForce(force, ForceMode.Impulse);
    }

    // 부딪힘 감지
    private void OnTriggerEnter(Collider other)
    {
        print(other);
        //
    }
}
