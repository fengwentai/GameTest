using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Escape
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 10f;
        [SerializeField]
        private float turnSpeed = 10f;
        private PlayerInputs input;
        private CharacterController cc;

        private void Awake()
        {
            input = GetComponentInParent<PlayerInputs>();
            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (input.Move.sqrMagnitude > 0.01f)
            {
                Vector2 move = input.Move.normalized;
                Vector3 velocity = new Vector3(move.x, 0f, move.y) * moveSpeed;
                cc.SimpleMove(velocity);

                Quaternion lookRot = Quaternion.LookRotation(velocity);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, turnSpeed * Time.deltaTime);
            }
        }
    }
}