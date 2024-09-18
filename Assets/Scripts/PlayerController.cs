using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    PlayerInputActions inputActions;
    InputAction movement;
    Shooter laserShooter;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float horizontalScreenLimit = 10f;
    [SerializeField] private float verticalScreenLimit = 6f;


    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void Start()
    {
        inputActions.Gameplay.Enable();
        movement = inputActions.Gameplay.Movement;
        laserShooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Shoot.performed -= Shoot;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = movement.ReadValue<Vector2>();

        transform.Translate(input * speed * Time.deltaTime);

        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }

        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        laserShooter.Shoot();
    }
}
