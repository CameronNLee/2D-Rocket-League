using System.Collections;
using System.Collections.Generic;
using Player.Command;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand Forward;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Accelerate;
    // Start is called before the first frame update
    void Start()
    {
        this.Forward = ScriptableObject.CreateInstance<MoveForward>();
        this.Right = ScriptableObject.CreateInstance<TurnPlayerRight>();
        this.Left = ScriptableObject.CreateInstance<TurnPlayerLeft>();
        this.Accelerate = ScriptableObject.CreateInstance<AcceleratePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerate button to actually start moving in direction you are facing.
        if (Input.GetButton("Fire3"))
        {
            if (Input.GetButton("Jump"))
            {
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
}
