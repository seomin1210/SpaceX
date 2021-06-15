using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private int score = 10;

    private GameManager gameManager = null;
    private Collider2D col = null;
    private bool isDead = false;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y < gameManager.minPosition.y)
        {
            Destroy(gameObject);
            gameManager.AddScore(score);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            if (isDead) return;
            Destroy(collision.gameObject);
            isDead = true;
            col.enabled = false;
            Destroy(gameObject);
            gameManager.AddScore(score*5);
        }
    }
}
