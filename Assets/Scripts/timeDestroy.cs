using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float LifeTime = 2f;

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }
}
