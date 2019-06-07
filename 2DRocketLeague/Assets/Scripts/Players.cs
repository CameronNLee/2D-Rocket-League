using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
    [SerializeField]
    bool PlayerNumberTwo;
    /// <summary>
    /// flase indicates player number 1 
    /// true for player 2
    /// 
    /// all you have to do is drag the script into the players objects  and if it is player two check the box if
    /// is player 1 make sur the box is unchecked
    /// 
    /// change the lines with the add force function calls with the movements functions 
    ///and the boost lines with the boost function
    /// </summary>
    // Use this for initialization

    
    // Update is called once per frame
    void Update () {

        if (!PlayerNumberTwo)
        {
            ProcessMovementForPlayerOne();
        }else if (PlayerNumberTwo)
        {
            ProcessMovementForPlayerTwo(); 
            
        }

    }
    void ProcessMovementForPlayerTwo()
    {
        if (Input.GetKey(KeyCode.W))  // UP for Player 2
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50),  ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))   // Right for Player 2
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0),  ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.S))  // down for Player 2
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -50),  ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.A))  // LEFt for Player 2
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-50, 0),  ForceMode2D.Force);

        }

        if (Input.GetKeyDown(KeyCode.F))  // Boost for player 2
        {
           // print("boost player 2");
        }
    }
    void ProcessMovementForPlayerOne()
    {
        if (Input.GetKey(KeyCode.UpArrow))  // UP for Player 1
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50),  ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.RightArrow))   // Right for Player 1
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0), ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.DownArrow))  // down for Player 1
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -50), ForceMode2D.Force);

        }
        if (Input.GetKey(KeyCode.LeftArrow))  // LEFt for Player 1
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-50, 0),  ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.L))  // boost for Player 1
        {
           // print("boost player 1");
        }


    }

   



}
