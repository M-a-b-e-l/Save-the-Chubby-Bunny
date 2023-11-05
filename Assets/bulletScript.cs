using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Vector3 bulletMove;

    public float bulletTimer;

    public GMScript gameManagerObject;

    public GameObject gem;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager").GetComponent<GMScript>();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += bulletMove;

        bulletTimer += Time.deltaTime;

        if (bulletTimer >= 1f)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Maze") //If the bullet touches the wall it gets destroyed
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy") // If the bullet touches the Enenmy 
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(gem, collision.gameObject.GetComponent<Transform>().position, Quaternion.identity);

        }

    }
}
