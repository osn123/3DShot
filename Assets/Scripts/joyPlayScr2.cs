using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyPlayerScp2 : MonoBehaviour
{
    #region prop
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;
    Animator animator;

    private Camera mainCamera;
    private CharacterController controller;
    private Vector3 movement;

    public VariableJoystick joystick;
    Vector3 moveDirection;
    #endregion

    void Start()
    {
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();

        //animator.applyRootMotion = false;
    }

    void Update()
    {
        // ���͂̏���
        ProcessInput();


    }

    void LateUpdate()
    {
        // �ړ������̌v�Z
        CalculateMovement();

        // �L�����N�^�[�̈ړ��Ɖ�]
        MoveAndRotateCharacter();

        // �d�͂̓K�p
        ApplyGravity();

    }

    void ProcessInput()
    {
        // �W���C�X�e�B�b�N���͂̏���
        Vector2 joystickInput = joystick.Direction;

        // �L�[�{�[�h���͂̏���
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �W���C�X�e�B�b�N���͂ƃL�[�{�[�h���͂�g�ݍ��킹��
        moveDirection = new Vector3(joystickInput.x + horizontalInput, 0, joystickInput.y + verticalInput).normalized;

        // �ړ����͂����邩�`�F�b�N
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        //bool isMoving = Input.GetAxis("Horizontal") >= 0.5 || Input.GetAxis("Vertical") >= 0.5;

        // �A�j���[�^�[��bool�p�����[�^�[��ݒ�
        //animator.SetBool("Turn", isMoving);
    }

    void CalculateMovement()
    {
        // �J�����̌�������ɂ����ړ������̌v�Z
        Vector3 forward = Vector3.ProjectOnPlane(mainCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward);

        // �ړ��x�N�g���̌v�Z
        movement = (forward * moveDirection.z + right * moveDirection.x).normalized;
    }

    void MoveAndRotateCharacter()
    {
        if (movement.magnitude > 0.1f)
        {
            // �ړ�����������
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);

            // �ړ��̓K�p
            Vector3 motion = movement * moveSpeed * Time.deltaTime;
            controller.Move(motion);

            //animator.speed = movement.magnitude ;

            //float normalizedSpeed = movement.magnitude / Mathf.Sqrt(2);
            //animator.speed = Mathf.Clamp(normalizedSpeed * 2, 0, 1);

        }
    }

    void ApplyGravity()
    {
        controller.Move(Physics.gravity * Time.deltaTime);
    }
}