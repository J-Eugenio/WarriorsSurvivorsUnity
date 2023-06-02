using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public EnemyData enemyData;
    private Vector3 target;
    private bool isLookLeft;
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;

    private float currentHealth;
    private float knockBackTime;
    private float knockBackFactor = 1;

    public GameObject hitArea;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
        StartCoroutine(nameof(IEAttack));
        currentHealth = enemyData.maxHealth;

        hitArea.GetComponent<MobHitArea>().data = enemyData;
        target = Core.Instance.gameManager.player.position;
        moveDirection = target - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackTime > 0) {
            knockBackFactor = enemyData.knockBackWeakness;
            knockBackTime -= Time.deltaTime;
        } else {
            knockBackFactor = 1;
        }

        if(moveDirection.x > 0 && isLookLeft == true) {
            Flip();
        }else if (moveDirection.x < 0 && isLookLeft == false) { 
            Flip(); 
        }
        _rigidbody.velocity = moveDirection.normalized * enemyData.moveSpeed * knockBackFactor;
    }

    IEnumerator IETargetUpdate() {
        while(true) {
            yield return new WaitForSeconds(enemyData.targetUpdateDelay);
            target = Core.Instance.gameManager.player.position;
            moveDirection = target - transform.position;
        }
    }

    IEnumerator IEAttack() {
        while (true) {
            hitArea.SetActive(false);
            yield return new WaitForSeconds(enemyData.timeBetweenAttacks);
            hitArea.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void TakeDamage(float value, float knockBack) {
        currentHealth -= value;
        knockBackTime = knockBack;
        if(currentHealth <= 0) {
            GameObject xp = Instantiate(enemyData.xpBallPrefab);
            xp.GetComponent<ItemCollectible>().SetValue(enemyData.xp);
            xp.transform.position = transform.position;
            Core.Instance.waveManager.EnemyUnregister(enemyData);
            Destroy(this.gameObject);
        }
    }

    void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
