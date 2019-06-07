using UnityEngine;

namespace Player.Command
{
    public class PlayerOneMovement : ScriptableObject, IPlayerCommand
    {
        private float TurnSpeed = 180.0f;

        public void Execute(GameObject gameObject)
        {

            // Quick and dirty way to access the MovementSpeed variable from PlayerController.
            GameObject player = GameObject.Find ("player1");
            var movementSpeed = player.GetComponent<PlayerController>().MovementSpeed;
            
            if (Input.GetKey(KeyCode.UpArrow))  // UP for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, movementSpeed, 0),  ForceMode.Force);

                LerpPlayerRotation(gameObject, 90);
            }
            if (Input.GetKey(KeyCode.RightArrow))   // Right for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0), ForceMode.Force);

                LerpPlayerRotation(gameObject, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))  // down for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -movementSpeed, 0), ForceMode.Force);

                LerpPlayerRotation(gameObject, -90);
            }
            if (Input.GetKey(KeyCode.LeftArrow))  // LEFt for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0),  ForceMode.Force);

                LerpPlayerRotation(gameObject, 180);
            }
        }

        void LerpPlayerRotation(GameObject gameObject, float angle)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody>();
            var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            if (rigidBody != null)
            {
                rigidBody.transform.rotation = Quaternion.RotateTowards(rigidBody.transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            }
        }
    }
}