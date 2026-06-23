using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using FMODUnity;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private InputActionReference moveAction;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField]
    private EventReference footstepsEvent;

    [SerializeField]
    private FeetLogic feetLogic;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        this.moveAction.action.Enable();
    }

    private void OnDisable()
    {
        this.moveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            movement = new Vector2(Mathf.Sign(input.x), 0f);
        }
        else if (Mathf.Abs(input.y) > 0f)
        {
            movement = new Vector2(0f, Mathf.Sign(input.y));
        }
        else
        {
            movement = Vector2.zero;
        }

        this.animator.SetBool("IsMoving", movement != Vector2.zero);

        if (movement != Vector2.zero)
        {
            this.animator.SetFloat("MoveX", movement.x);
            this.animator.SetFloat("MoveY", movement.y);
        }
    }

    private void FixedUpdate()
    {
        this.rb.linearVelocity = movement * moveSpeed;
    }

    private void PlayFootstep()
    {
        EventInstance step = RuntimeManager.CreateInstance(footstepsEvent);

        step.setParameterByName(
            "Surface",
            feetLogic.CurrentSurface);

        step.start();
        step.release();
    }
}
