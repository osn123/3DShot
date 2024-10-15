using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject player;
    public float spawnDistance = 1.0f; // �v���C���[�̑O���̐�������

    private Tutorial3D tutorial3;


    void Start()
    {
        tutorial3 = new Tutorial3D();
        tutorial3.Enable();
    }
    void Update()
    {

        //if (Input.GetMouseButtonDown(1))
        //if (Input.GetKeyDown(KeyCode.PageDown))
        if (tutorial3.Player.Shot.triggered)
        {

            // �v���C���[�̈ʒu�ƑO�������擾
            Vector3 playerPosition = player.transform.position;
            Vector3 playerForward = player.transform.forward;

            // �e�̔��a���擾�i���̃R���C�_�[��z��j
            float bulletRadius = ballPrefab.GetComponent<SphereCollider>().radius;

            // �����ʒu���v�Z�i�v���C���[�̏����O���j
            Vector3 spawnPosition = playerPosition + (
                playerForward * (spawnDistance + bulletRadius) +
                player.transform.up * (bulletRadius)
                    );

            // �{�[���𐶐�
            GameObject spawnedBall = Instantiate(ballPrefab, spawnPosition, player.transform.rotation);

            // �{�[���̕�����ݒ�
            ScriptBall ballScript = spawnedBall.GetComponent<ScriptBall>();
            if (ballScript != null)
            {
                ballScript.SetDirection(playerForward);
            }

            //Instantiate(ballPrefab, player.transform.position, Quaternion.identity);
            //Instantiate(ballPrefab, player.transform.position, player.transform.rotation);

        }
    }
}
