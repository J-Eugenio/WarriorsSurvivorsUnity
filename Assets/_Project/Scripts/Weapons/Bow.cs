using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject projectile;
    public float delayAttack;
    public float arrowSpeed;

    public Transform arrowPivot;
    private PlayerController player;

    [SerializeField]
    private Vector2 shotDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        StartCoroutine(nameof(IEBow));
        shotDirection = Vector2.right;
    }

    private void FixedUpdate() {
        if(player.GetMoveDirection().sqrMagnitude != 0) {
            shotDirection = player.GetMoveDirection();
        }
    }

    IEnumerator IEBow() {
        while(true) {
            yield return new WaitForSeconds(delayAttack);
            ShotArrow();
        }
    }

    private void ShotArrow() {
        GameObject arrow = Instantiate(projectile);
        arrow.transform.position = arrowPivot.position;

        float angle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

        arrow.GetComponent<Rigidbody2D>().velocity = shotDirection * arrowSpeed;
        Destroy(arrow, 5);
    }
}
