using UnityEngine;

namespace Player.Command
{
    public class TurnPlayerLeft : ScriptableObject, IPlayerCommand
    {
        private float TurnSpeed = 180.0f;
        private float TurnAxisMovement;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                TurnAxisMovement = Input.GetAxis("Horizontal");
                var rotation = -TurnAxisMovement * TurnSpeed * Time.deltaTime;
                var turnRotation = Quaternion.Euler(0.0f, 0.0f, rotation);
                rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
                // gameObject.GetComponent<Sprit
            }
        }
    }
}