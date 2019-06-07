using System.Collections;
using System.Collections.Generic;
using Player.Command;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool PlayerNumberTwo;
    
    [SerializeField]
    private float KickForce;

    [SerializeField]
    public float MovementSpeed;

    private float PreviousMovementSpeed;
    
    private IPlayerCommand Forward;
    private IPlayerCommand PlayerTwoMovement;
    private IPlayerCommand PlayerOneMovement;
    private IPlayerCommand Accelerate;

    public GameObject Energy;
    public Text EnergyText;



    // Start is called before the first frame update
    void Start()
    {
        this.Forward = ScriptableObject.CreateInstance<MoveForward>();
        this.PlayerTwoMovement = ScriptableObject.CreateInstance<PlayerTwoMovement>();
        this.PlayerOneMovement = ScriptableObject.CreateInstance<PlayerOneMovement>();
        this.Accelerate = ScriptableObject.CreateInstance<AcceleratePlayer>();

        // Default values if not setting the SerializeField vars.
        // this.KickForce = 30.0f;
        // this.MovementSpeed = 50.0f;
        this.PreviousMovementSpeed = this.MovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Player 1 uses arrow key movements while Player 2 uses WASD.
        if (!PlayerNumberTwo)
        {
            this.PlayerOneMovement.Execute(this.gameObject);
        }
        else
        {
            this.PlayerTwoMovement.Execute(this.gameObject);
            
        }
        
        // Accelerate button to actually start moving in direction you are facing.
        if (Input.GetButton("Fire3"))
        {
            var residualEnergy = this.Energy.GetComponent<Image>().fillAmount;
            if (residualEnergy != 0)
            {
                residualEnergy -= 0.01f;
                var value = (residualEnergy * 100);
                this.Energy.GetComponent<Image>().fillAmount = residualEnergy > 0 ? residualEnergy : 0;
                this.EnergyText.text = (Mathf.Ceil(residualEnergy * 100)).ToString();
                // this.Accelerate.Execute(this.gameObject);
                this.MovementSpeed = this.PreviousMovementSpeed * 2;
            }
            else
            {
                this.MovementSpeed = this.PreviousMovementSpeed;
            }
        }

        if (Input.GetButtonUp("Fire3"))
        {
            this.MovementSpeed = this.PreviousMovementSpeed;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(10);
        }
        if (collision.gameObject.tag == "MediumEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(20);
        }
        if (collision.gameObject.tag == "LargeEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(50);
        }
        
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
    
    void EnergyChange(int amount)
    {
        float currentEnergyFillAmount = this.Energy.GetComponent<Image>().fillAmount;
        var addEnergyAmount = 0.01f * amount;
   
        this.Energy.GetComponent<Image>().fillAmount = (currentEnergyFillAmount+addEnergyAmount) < 1 ? (currentEnergyFillAmount + addEnergyAmount) : 1;
        int energy = int.Parse(EnergyText.text);
        EnergyText.text = ((energy + amount) < 100 ? (energy + amount) : 100).ToString();
        EnergySpawner.count--;
    }
}
