using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FIRSTP : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public float gravity = 9.81f;

    public MusicManager Musicmanager;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;
    private bool isRunning = false;
    private bool canRun = true;
    private bool canJump = true;  // Переменная для проверки возможности прыжка
    bool escape = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!escape)
        {
            HandleMovement();
            HandleMouseLook();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Используем GetKeyDown, чтобы сработало один раз при нажатии
        {
            escape = !escape; // Переключаем значение escape

            if (escape)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Musicmanager.ToggleMusic();
        }
    }


    void HandleMovement()
    {
        // Проверяем, находится ли игрок на земле
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            canJump = true;  // Разрешаем прыжок, если игрок на земле
        }

        // Получаем ввод для движения
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift) && canRun;

        float speed = isRunning ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Обработка прыжка
        if (Input.GetButtonDown("Jump") && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
            canJump = false;  // Запрещаем повторный прыжок до тех пор, пока игрок не коснется земли
        }

        // Применяем гравитацию
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Получаем ввод для движения мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    
}