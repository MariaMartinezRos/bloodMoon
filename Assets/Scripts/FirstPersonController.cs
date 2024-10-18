using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private float verticalVelocity;
    private Vector3 moveDirection;

    // Variables para la rotación de la cámara
    private float verticalRotation = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el cursor en el centro de la pantalla
    }

    void Update()
    {
        // Movimiento del mouse (rotación de la cámara)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;  // Ajustar la rotación vertical
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);  // Limitar la rotación vertical

        transform.Rotate(0, mouseX, 0);  // Rotar el cuerpo del jugador horizontalmente
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);  // Rotar la cámara verticalmente

        // Movimiento del jugador (teclas WASD)
        float moveX = Input.GetAxis("Horizontal");  // Movimiento en el eje X
        float moveZ = Input.GetAxis("Vertical");    // Movimiento en el eje Z

        // Definir la dirección de movimiento
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;  // Mantener el jugador pegado al suelo

            // Saltar
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;  // Aplicar gravedad si no está en el suelo
        }

        // Aplicar movimiento
        moveDirection = move * speed;
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * Time.deltaTime);
    }
}

