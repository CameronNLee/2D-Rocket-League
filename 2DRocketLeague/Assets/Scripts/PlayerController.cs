using System.Collections;
using System.Collections.Generic;
using Player.Command;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand Forward;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Accelerate;

    public GameObject Energy;
    public Text EnergyText;

    public float KickForce;
    // Start is called before the first frame update
    void Start()
    {
        this.Forward = ScriptableObject.CreateInstance<MoveForward>();
        this.Right = ScriptableObject.CreateInstance<TurnPlayerRight>();
        this.Left = ScriptableObject.CreateInstance<TurnPlayerLeft>();
        this.Accelerate = ScriptableObject.CreateInstance<AcceleratePlayer>();

        this.KickForce = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerate button to actually start moving in direction you are facing.
        if (Input.GetButton("Fire3"))
        {
            var residualEnergy = this.Energy.GetComponent<Image>().fillAmount;
            if (Input.GetButton("Jump") && residualEnergy != 0)
            {
                residualEnergy -= 0.01f;
                var value = (residualEnergy * 100);
                this.Energy.GetComponent<Image>().fillAmount = residualEnergy > 0 ? residualEnergy : 0;
                this.EnergyText.text = (Mathf.Ceil(residualEnergy * 100)).ToString();
                this.Accelerate.Execute(this.gameObject);
            }
            else
            {
                this.Forward.Execute(this.gameObject);
            }       
        }
        
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            this.Right.Execute(this.gameObject);
        }

        if (Input.GetAxis("Horizontal") < -0.01)
        {
            this.Left.Execute(this.gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
        {
            // Here, we handle what happens when the player kicks the ball.
            // Upon doing so, simply get the direction of the player,
            // multiply that by the KickForce (adjustable float declared above),
            // and assign that to be the ball's new velocity.
            if (collision.gameObject.name == "ball" || collision.gameObject.name == "ball(Clone)")
            {
                var rigidBody = collision.gameObject.GetComponent<Rigidbody>();
                if (rigidBody)
                {
                    Debug.Log ("Collision!");
                    Vector3 direction = (collision.transform.position - this.transform.position).normalized;
                    rigidBody.velocity = direction * this.KickForce;
                }
            }
        }
}
