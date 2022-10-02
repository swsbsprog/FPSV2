using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float detectionRange;
    public GameObject bullet;
    public Transform fireTr;
    IEnumerator Start()
    {
        while (true)
        {
            // 플레이어가 공격 범위 안에 들어올 때가지 대기
            var playerTr= Player.instance.transform;
            while (IsInRange(playerTr.position, detectionRange) == false)
                yield return null;
            // 플레이방향으로 이동


            // 플레이어를 향해 공격
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
}
