using UnityEngine;

namespace Player.Command
{
    public class PlayerOneMovement : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject)
        {
            // Quick and dirty way to access the MovementSpeed variable from PlayerController.
            GameObject player = GameObject.Find ("player1");
            var movementSpeed = player.GetComponent<PlayerController>().MovementSpeed;
            
            if (Input.GetKey(KeyCode.UpArrow))  // UP for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, movementSpeed, 0),  ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.RightArrow))   // Right for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0), ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.DownArrow))  // down for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -movementSpeed, 0), ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.LeftArrow))  // LEFt for Player 1
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0),  ForceMode.Force);
            }
        }
    }
}