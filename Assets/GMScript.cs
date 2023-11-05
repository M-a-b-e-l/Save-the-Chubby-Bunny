using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public float timer;

    public int Gems;

    // Enemy positions
    public Vector3 enemyPos1;
    public Vector3 enemyPos2;
    public Vector3 enemyPos3;
    public Vector3 enemyPos4;
    public Vector3 enemyPos5;
    public Vector3 enemyPos6;
    public Vector3 enemyPos7;
    public Vector3 enemyPos8;

    public TextMeshProUGUI gemText;
    public TextMeshProUGUI WinOrLose;
    public TextMeshProUGUI informationText;

    public GameObject enemy;

    public playerMovementScript gameManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("Player").GetComponent<playerMovementScript>();

        //enemies appear at different points of the game
        Instantiate(enemy, enemyPos1, Quaternion.identity);
        Instantiate(enemy, enemyPos2, Quaternion.identity);
        Instantiate(enemy, enemyPos3, Quaternion.identity);
        Instantiate(enemy, enemyPos4, Quaternion.identity);
        Instantiate(enemy, enemyPos5, Quaternion.identity);
        Instantiate(enemy, enemyPos6, Quaternion.identity);
        Instantiate(enemy, enemyPos7, Quaternion.identity);
        Instantiate(enemy, enemyPos8, Quaternion.identity);

        informationText.text = "Collect 3 Gems by defeating the guards then solve the maze all in 120 seconds to save the Chubby Bunny.";

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Change the text to gems 
        gemText.text = "Gems: " + Gems + "\nTimer: " + (int)timer;

        //If the timer is greater than 60 and the player han't won yet, the player looses. 
        if (timer >= 120f && gameManagerObject.playerWon == false)
        {
            WinOrLose.text = "Time ran out. You lose :(";
            Debug.Log("You lose");
        }
        
    }
}
