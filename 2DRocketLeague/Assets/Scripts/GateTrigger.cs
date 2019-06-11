using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject newBall;
    public Text teamScore;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            ScrollTextManager.Instance.CreateText(player.transform.position, "+1", Color.yellow, 20);

            // Instantiate a new ball
            Vector3 startPoint = new Vector3(0, 0, -1);
            Instantiate(newBall, startPoint, Quaternion.identity);

            // Destory the current ball
            Destroy(collision.gameObject);
            SoundManager.Singleton.Play("score2");

            // Update team score
            int score = int.Parse(teamScore.text);
            score++;
            teamScore.text = score.ToString();
        }
    }
}