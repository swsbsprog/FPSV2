﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Animator animator;

    void Update()
    {
        UpdateMove();
        UpdateRotation();
        UpdateFire();
    }
    public GameObject bullet;
    public Transform firePos;
    private void UpdateFire()
    {
        if (Input.GetMouseButtonDown(0)) //같다(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // 총알 발사.
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = firePos.position;
            Vector3 screenCenter = new(Screen.width / 2, Screen.height / 2, 0);
            // //카메라 위치에서 클릭한 위치로 레이를 소자.
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            Physics.Raycast(ray, out RaycastHit hit);
            if (hit.transform != null)
            {
                newBullet.transform.LookAt(hit.point);
            }
        }
    }

    private void UpdateRotation()
    {
        var rot = transform.rotation;
        rot.y = Camera.main.transform.rotation.y;
        transform.rotation = rot;
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

        animator.SetFloat("speed", move.magnitude);
        animator.SetFloat("moveX", move.x);
        animator.SetFloat("moveY", move.z);

        // move 움직임이 있다면 런 애니메이션 해라.
        // 움직임이 없다면 idle애니메이션 해라.
        float forward = move.z;
        float side = move.x;
        move = move * speed * Time.deltaTime;
        transform.Translate(move);
    }
}
