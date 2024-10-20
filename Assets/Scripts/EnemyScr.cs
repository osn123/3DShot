using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour, ICol
{
    GameObject player;
    public float speed = 1f; // �G�̈ړ����x

    public void Col(GameObject other)
    {
        Debug.Log("Enemy");
        Destroy(other.gameObject);
        Destroy(gameObject);
        //player = other;
        //Destroy(gameObject);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player != null)
        {
            // �v���C���[�̕����ֈړ�
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // �I�v�V�����F�v���C���[�̕�������
            transform.LookAt(player.transform);
        }
    }
}