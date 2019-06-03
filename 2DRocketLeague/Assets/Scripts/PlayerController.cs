using System.Collections;
using System.Collections.Generic;
using Player.Command;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand Accelerate;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    // Start is called before the first frame update
    void Start()
    {
        this.Accelerate = ScriptableObject.CreateInstance<AcceleratePlayer>();
        this.Right = ScriptableObject.CreateInstance<TurnPlayerRight>();
        this.Left = ScriptableObject.CreateInstance<TurnPlayerLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerate button to actually start moving in direction you are facing.
        if (Input.GetButton("Fire3"))
        {
            this.Accelerate.Execute(this.gameObject);
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
