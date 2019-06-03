using UnityEngine;

namespace Player.Command
{
    public class AcceleratePlayer : ScriptableObject, IPlayerCommand
    {
        private float MovementSpeed = 1.0f;
        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                rigidBody.transform.position += rigidBody.transform.right * MovementSpeed;
                // gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}