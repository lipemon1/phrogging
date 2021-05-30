using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phrogging.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Transform _visualTransform;
        CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerInput.PlayerDir == Vector3.zero) return;
            MovePlayer(PlayerInput.PlayerDir);
            RotatePlayer(PlayerInput.PlayerDir);
        }

        void MovePlayer(Vector3 playerDir)
        {
            _characterController.Move(playerDir * _moveSpeed * Time.deltaTime);
        }

        void RotatePlayer(Vector3 playerDir)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerDir, _visualTransform.transform.up);
            _visualTransform.transform.rotation = Quaternion.Slerp(_visualTransform.transform.rotation, newRotation, Time.deltaTime * 8);
        }
    }
}