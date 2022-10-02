using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float detectionRange = 10;
    public GameObject bullet;
    public Transform fireTr;
    public Animator animator;
    IEnumerator Start()
    {
        while (hp > 0)
        {
            // 플레이어가 공격 범위 안에 들어올 때까지 대기
            var playerTr= Player.instance.transform;
            while (IsInRange(playerTr.position, detectionRange) == false)
                yield return null;
            // 플레이어 방향으로 이동


            // 플레이어를 향해 공격
            animator.SetTrigger("attack");
            var lookAtPos = Player.instance.transform.position;
            lookAtPos.y = transform.position.y;
            transform.LookAt(lookAtPos);
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = fireTr.position;
            newBullet.transform.forward = transform.forward;
            yield return new WaitForSeconds(1); 
        }
    }
    private bool IsInRange(Vector3 position, float checkRange) =>
        Vector3.Distance(transform.position, position) < checkRange;

    public int hp = 1;
    internal void OnDamage()
    {
        if (hp <= 0)
            return;

        hp--;

        if(hp > 0)
            animator.SetTrigger("attacked");
        else
            animator.SetTrigger("die");
    }
}
