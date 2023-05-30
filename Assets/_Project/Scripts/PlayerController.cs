using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HeroData hero;
    private Rigidbody2D playerRb;
    private Animator animator;
    private bool isWalk;
    private bool isLookLeft; // true = olhando para a esqueda, false = olhando para a direita
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        hero = Core.Instance.gameManager.selectedHero;

        GameObject myHero = Instantiate(hero.prefab, this.transform);
        animator = myHero.GetComponent<Animator>();

        Instantiate(hero.startingWeapon.prefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        isWalk = moveDirection.sqrMagnitude != 0;

        if (moveDirection.x  > 0 && isLookLeft == true) {
            Flip();
        } else if (moveDirection.x < 0 && isLookLeft == false) {
            Flip();
        }

        playerRb.velocity = moveDirection.normalized * hero.moveSpeed;

        animator.SetBool("isWalk", isWalk);

    }

    public bool GetIsLookLeft() {
        return isLookLeft;
    }

    public Vector2 GetMoveDirection() {
        return moveDirection;
    }

    void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
