using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject projectile;
    public float delayAttack;
    public Transform slashPivot;
    private PlayerController player;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        StartCoroutine(nameof(IESwordSlash));
    }
    IEnumerator IESwordSlash() {
        while (true) {
            yield return new WaitForSeconds(delayAttack);
            GameObject slash = Instantiate(projectile);
            slash.transform.position = slashPivot.position;
            if (player.GetIsLookLeft()) {
                Flip(slash.transform);
            }
            Destroy(slash, 0.5f);
        }
    }

    private void Flip(Transform t) {
        t.localScale = new Vector3(t.localScale.x * -1, t.localScale.y, t.localScale.z);
    }
}
