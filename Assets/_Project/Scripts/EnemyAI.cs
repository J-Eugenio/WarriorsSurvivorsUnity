using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;
    private Vector3 target;
    private bool isLookLeft;
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;

    private float currentHealth;
    private float knockBackTime;
    private int knockBackFactor = 1;

    public GameObject hitArea;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = moveDirection.normalized * enemyData.moveSpeed * knockBackFactor;
    }

    IEnumerator IETargetUpdate() {
        while(true) {
            yield return new WaitForSeconds(enemyData.targetUpdateDelay);
            target = Core.Instance.gameManager.player.position;
            moveDirection = target - transform.position;
        }
    }
}
