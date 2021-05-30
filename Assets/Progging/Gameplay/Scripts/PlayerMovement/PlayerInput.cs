using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phrogging.PlayerMovement
{
    public class PlayerInput : MonoBehaviour
    {
        public static Vector3 PlayerDir;

        Transform _playerCamTransform;

        //cache variables
        float horizontalValue;
        float verticalValue;

        private void Awake()
        {
            _playerCamTransform = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");

            //PlayerDir = new Vector3(horizontalValue, 0f, verticalValue);
            var forward = _playerCamTransform.forward;
            forward.y = 0f;

            var right = _playerCamTransform.right;
            right.y = 0f;

            PlayerDir = forward * verticalValue + right * horizontalValue;
        }
    }
}