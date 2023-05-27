using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField]
    private float moveSpeed;
    private bool isLookLeft; // true = olhando para a esqueda, false = olhando para a direita


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.velocity = moveDirection.normalized * moveSpeed;

        if(moveDirection.x  > 0 && isLookLeft == true) {
            Flip();
        } else if (moveDirection.x < 0 && isLookLeft == false) {
            Flip();
        }


    }

    void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
