using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptBall : MonoBehaviour
{
    public float speed = 10f; // �{�[���̑��x
    private Rigidbody rigid;

    // �v���C���[�̌�����ݒ肷�郁�\�b�h
    public void SetDirection(Vector3 direction)
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = direction.normalized * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        //ICol[] colArr = collision.GetComponentsInChildren<ICol>();
        //foreach (ICol d in colArr)
        //{
        //    d.Col();
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        ICol[] colArr = other.GetComponentsInChildren<ICol>();
        foreach (ICol d in colArr)
        {
            d.Col(this.gameObject);
        }
    }
}
