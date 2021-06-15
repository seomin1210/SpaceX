using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float bulletDelay = 5f;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;

    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    private bool isDamaged = false;
    private SpriteRenderer spriteRenderer = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPosition.x > 0f && targetPosition.x < 3f)
            {
                if (Mathf.Approximately(transform.position.x,2)) return;
                transform.Translate(1, 0, 0);

            }
            else if (targetPosition.x < 0f && targetPosition.x > -3f)
            {
                if (Mathf.Approximately(transform.position.x, -2)) return;
                    transform.Translate(-1, 0, 0);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //여기에 사망 처리
            if (isDamaged) return;
            StartCoroutine(Damaged());
        }
    }

    private IEnumerator Damaged()
    {
        if (!isDamaged)
        {
            isDamaged = true;
            gameManager.Dead();
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            isDamaged = false;
        }
    }
    private IEnumerator Fire()
    {
        GameObject bullet = null;
        while (true)
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
