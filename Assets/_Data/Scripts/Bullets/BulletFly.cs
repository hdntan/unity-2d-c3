using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int moveSpeed = 1;
    [SerializeField] protected Vector3 drirection = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(this.drirection * this.moveSpeed * Time.deltaTime);
    }
}
