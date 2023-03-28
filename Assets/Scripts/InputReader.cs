﻿using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerEntity _playerEntity;

    private float _direction;

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            _playerEntity.JumpButton();
        }
    }

    private void FixedUpdate()
    {
        _playerEntity.Move(_direction);
    }
}

 