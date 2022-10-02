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
        //transform
        //transform.forward; -> 월드 방향으로 바꿔서 힘을 주자.
        //rb.AddForce(0, 0, speed, ForceMode.Impulse);
    }
    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // 부딪힘 감지
    private void OnTriggerEnter(Collider other)
    {
        print(other);
    }
}
