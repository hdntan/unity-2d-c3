using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : MainMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 drirection = Vector3.right;

    private void Update()
    {
        transform.parent.Translate(this.drirection * this.moveSpeed * Time.deltaTime);
    }
}
