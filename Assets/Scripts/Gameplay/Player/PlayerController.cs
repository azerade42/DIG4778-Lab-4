using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDestructable
{
    public Action OnDestroyed;
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
        inputActions.Gameplay.Restart.performed += Restart;
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Shoot.performed -= Shoot;
        inputActions.Gameplay.Restart.performed += Restart;
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

    private void Shoot(InputAction.CallbackContext context)
    {
        laserShooter.Shoot();
    }

    private void Restart(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.GameOver)
        {
            SceneController.Instance.LoadScene("Week5Lab");
        }
    }

    public void DestroyObject()
    {
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
