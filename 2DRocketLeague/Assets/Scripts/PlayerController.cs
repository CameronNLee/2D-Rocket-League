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
    private float PreviousKickForce;
    
    private IPlayerCommand Forward;
    private IPlayerCommand PlayerTwoMovement;
    private IPlayerCommand PlayerOneMovement;
    private IPlayerCommand Accelerate;

    public GameObject Energy;
    public Text EnergyText;
    
    private enum Phase {Boost, Normal, None};
    private Phase CurrentPhase;

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
        this.PreviousKickForce = this.KickForce;
        this.CurrentPhase = Phase.None;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Player 1 uses arrow key movements while Player 2 uses WASD.
        if (!PlayerNumberTwo)
        {
            this.PlayerOneBoost();
            this.PlayerOneMovement.Execute(this.gameObject);
        }
        else
        {
            this.PlayerTwoBoost();
            this.PlayerTwoMovement.Execute(this.gameObject);
            
        }
        
        // Accelerate button to actually start moving in direction you are facing.

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(10);
            SoundManager.Singleton.Play("pickup1");
        }
        if (collision.gameObject.tag == "MediumEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(20);
            SoundManager.Singleton.Play("pickup1");
        }
        if (collision.gameObject.tag == "LargeEnergyBall")
        {
            Destroy(collision.gameObject);
            EnergyChange(50);
            SoundManager.Singleton.Play("pickup1");
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
                SoundManager.Singleton.Play("ball_kick1");
            }
        }

        if (collision.gameObject.name == "player2" || collision.gameObject.name == "player1")
        {
            Debug.Log("Player collision");
            SoundManager.Singleton.Play("car_collision");
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

    private void PlayerOneBoost()
    {
        // Only so that the boost sound effect plays once when you hold the button.
        // Probably a better idea to use the enum Phase and play the sound effect
        // based on what phase you're in instead.
        if (Input.GetButtonDown("Jump"))
        {
            var residualEnergy = this.Energy.GetComponent<Image>().fillAmount;
            if (residualEnergy != 0)
            {
                SoundManager.Singleton.Play("boost1");
                this.gameObject.GetComponent<TrailRenderer>().emitting = true;
                this.KickForce = this.PreviousKickForce * 2;
            }
        }
        
        if (Input.GetButton("Jump"))
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
                this.KickForce = this.PreviousKickForce;
                this.gameObject.GetComponent<TrailRenderer>().emitting = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            this.MovementSpeed = this.PreviousMovementSpeed;
            this.KickForce = this.PreviousKickForce;
            this.gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
    }

    private void PlayerTwoBoost()
    {
        // Only so that the boost sound effect plays once when you hold the button.
        // Probably a better idea to use the enum Phase and play the sound effect
        // based on what phase you're in instead.
        if (Input.GetButtonDown("Fire3"))
        {
            var residualEnergy = this.Energy.GetComponent<Image>().fillAmount;
            if (residualEnergy != 0)
            {
                this.gameObject.GetComponent<TrailRenderer>().emitting = true;
                this.KickForce = this.PreviousKickForce * 2;
                SoundManager.Singleton.Play("boost1");
            }
        }
        
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
                this.KickForce = this.PreviousKickForce;
                this.gameObject.GetComponent<TrailRenderer>().emitting = false;
            }
        }

        if (Input.GetButtonUp("Fire3"))
        {
            this.MovementSpeed = this.PreviousMovementSpeed;
            this.KickForce = this.PreviousKickForce;
            this.gameObject.GetComponent<TrailRenderer>().emitting = false;
        }        
    }
}
