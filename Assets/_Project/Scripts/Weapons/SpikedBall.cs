using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Core.Instance.gameManager.player.position;
        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
    }
}
