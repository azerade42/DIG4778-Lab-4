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
        SoundManager.Instance.PlayPlayerDeathSound();
        Destroy(gameObject);
    }
}
