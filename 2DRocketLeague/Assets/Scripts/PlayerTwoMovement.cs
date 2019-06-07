using UnityEngine;

namespace Player.Command
{
    public class PlayerTwoMovement : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject)
        {
            // Quick and dirty way to access the MovementSpeed variable from PlayerController.
            GameObject player = GameObject.Find ("player2");
            var movementSpeed = player.GetComponent<PlayerController>().MovementSpeed;
            
            if (Input.GetKey(KeyCode.W))  // UP for Player 2
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,movementSpeed, 0),  ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.D))   // Right for Player 2
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0),  ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.S))  // down for Player 2
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -movementSpeed, 0),  ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.A))  // LEFt for Player 2
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0),  ForceMode.Force);

            }
        }
    }
}