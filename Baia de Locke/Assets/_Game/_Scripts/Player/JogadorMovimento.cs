using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimento : MonoBehaviour
{
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    public Arma arma;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private Vector2 playerDirection;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            arma.Fire();
        }

        playerDirection = new Vector2(directionX, directionY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);

        // Calcula ângulo e rotação do jogador de acordo com a posição do mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

}
