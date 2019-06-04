using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class AcceleratePlayer : ScriptableObject, IPlayerCommand
    {
        private float MovementSpeed = 0.25f;
        public void Execute(GameObject gameObject)
        {
            gameObject.GetComponent<TrailRenderer>().startWidth = 0.5f;
            gameObject.GetComponent<TrailRenderer>().endWidth = 0f;
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                rigidBody.transform.position += rigidBody.transform.right * MovementSpeed;
                // gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
