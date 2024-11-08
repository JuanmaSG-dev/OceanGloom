using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float acceleration = 5f;
    public float maxSpeed = 10f;
    public float rotationSpeed = 100f;
    public float currentSpeed = 0f;

    private Rigidbody2D rb;
    public GameObject dialogueBubble;
    private bool show = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ToggleDialogueBubble(show);
    }

    public void ToggleDialogueBubble(bool show)
    {
        dialogueBubble.SetActive(show);
    }

    void FixedUpdate()
    {
        // Control de velocidad
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, -maxSpeed, maxSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.deltaTime, -maxSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 0.5f);
        }

        // Rotaci�n del barco
        float rotationInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationInput = -1f;
        }
        transform.Rotate(0, 0, rotationInput * rotationSpeed * Time.deltaTime);

        // Asigna la velocidad directamente al Rigidbody2D para que pueda calcularla
        Vector2 moveDirection = transform.up * currentSpeed;
        rb.velocity = moveDirection;
    }
}
