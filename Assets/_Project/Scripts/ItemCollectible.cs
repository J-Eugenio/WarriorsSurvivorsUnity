using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectible : MonoBehaviour
{
    public CollectibleType itemType;
    public float value;
    
    public void SetValue(float value) {
        this.value = value;
    }
}
