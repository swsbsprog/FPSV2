using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 앞으로 이동
    public Rigidbody rb;
    public float speed = 1;
    public GameObject bulletHole;
    public float bulletOffset = 0.001f;
    private void Start()
    {
        //월드 방향으로 로컬로 바꿔서 힘을 주자.
        // 월드 힘이 아니라  -> 로컬 힘을 주자.
        var force = transform.forward * speed;
        rb.AddForce(force, ForceMode.Impulse);
    }

    // 부딪힘 감지
    private void OnCollisionEnter(Collision collision)
    {
        print(collision);
        var newGo = Instantiate(bulletHole);
        var hit = collision.contacts[0];
        newGo.transform.position = hit.point;
        var bulletHoleTr = newGo.transform;
        bulletHoleTr.rotation = Quaternion.FromToRotation(bulletHoleTr.up, hit.normal)
            * bulletHoleTr.rotation;
        bulletHoleTr.Translate(0, bulletOffset, 0);
        bulletHoleTr.SetParent(hit.otherCollider.transform);

        hit.otherCollider.GetComponent<Enemy>().OnDamage();

        Destroy(gameObject);
    }
}
