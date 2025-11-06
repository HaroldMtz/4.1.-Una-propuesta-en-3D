using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem; 
#endif

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMotor : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;
    public float jumpForce  = 7f;

    [Header("Suelo (layers a considerar)")]
    public LayerMask groundMask;          
    [Tooltip("Margen inferior para tocar piso con la cápsula")]
    public float groundSkin = 0.06f;
    [Tooltip("Ventana de gracia para saltar tras tocar suelo")]
    public float coyoteTime = 0.12f;

    [Header("Entrada táctil (opcional)")]
    public SimpleJoystick joystick;       
    private Vector2 dpadDir = Vector2.zero; 

    [Header("Anti-spam")]
    public float jumpCooldown = 0.15f;

    Rigidbody rb;
    CapsuleCollider col;

    bool isGrounded = false;
    bool hasJumped  = false;
    float lastGroundedTime = -999f;
    float nextJumpAllowedAt = 0f;

    void Awake()
    {
        rb  = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        if (groundMask.value == 0)
            groundMask = LayerMask.GetMask("Ground", "Default");
    }

    void Update()
    {
        float h = 0f, v = 0f;

#if ENABLE_LEGACY_INPUT_MANAGER
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
#endif
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) h -= 1f;
            if (Keyboard.current.dKey.isPressed) h += 1f;
            if (Keyboard.current.sKey.isPressed) v -= 1f;
            if (Keyboard.current.wKey.isPressed) v += 1f;
            if (h != 0 || v != 0) { h = Mathf.Clamp(h, -1, 1); v = Mathf.Clamp(v, -1, 1); }
        }
#endif
        if (Mathf.Approximately(h,0f) && Mathf.Approximately(v,0f) && joystick != null)
        { var j = joystick.Direction; h = j.x; v = j.y; }

        if (Mathf.Approximately(h,0f) && Mathf.Approximately(v,0f) && dpadDir.sqrMagnitude > 0f)
        { h = dpadDir.x; v = dpadDir.y; }

        Vector3 wish = new Vector3(h, 0, v);
        if (wish.sqrMagnitude > 1f) wish.Normalize();

        Vector3 vel = rb.linearVelocity;
        rb.linearVelocity = new Vector3(wish.x * moveSpeed, vel.y, wish.z * moveSpeed);

        if (wish.sqrMagnitude > 0.01f)
        {
            var look = Quaternion.LookRotation(new Vector3(wish.x, 0, wish.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, look, 0.2f);
        }

        bool spacePressed = false;
#if ENABLE_LEGACY_INPUT_MANAGER
        spacePressed |= Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space);
#endif
#if ENABLE_INPUT_SYSTEM
        spacePressed |= (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame);
#endif
        if (spacePressed) JumpNow();
    }

    void FixedUpdate()
    {
        float r = Mathf.Max(0.05f, col.radius * 0.95f);
        Vector3 pTop = transform.position + Vector3.up * (col.center.y + col.height * 0.5f - r);
        Vector3 pBot = transform.position + Vector3.up * (col.center.y - col.height * 0.5f + r);

        bool groundedCapsule = Physics.CheckCapsule(
            pTop, pBot - Vector3.up * groundSkin, r,
            groundMask, QueryTriggerInteraction.Ignore
        );

        bool groundedRay = Physics.Raycast(
            pBot, Vector3.down, groundSkin * 1.5f,
            groundMask, QueryTriggerInteraction.Ignore
        );

        bool groundedNow = groundedCapsule || groundedRay;

        if (!isGrounded && groundedNow)
            hasJumped = false;

        isGrounded = groundedNow;
        if (isGrounded) lastGroundedTime = Time.time;
    }

    public void JumpNow()
    {
        bool canJumpByGround = isGrounded || (Time.time - lastGroundedTime) <= coyoteTime;
        if (!canJumpByGround) return;
        if (Time.time < nextJumpAllowedAt || hasJumped) return;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        hasJumped = true;
        nextJumpAllowedAt = Time.time + jumpCooldown;
    }

    public void SetMove(Vector2 dir) => dpadDir = dir;
    public void StopMove()           => dpadDir = Vector2.zero;

    void OnDrawGizmosSelected()
    {
        if (!col) col = GetComponent<CapsuleCollider>();
        float r = Mathf.Max(0.05f, col.radius * 0.95f);
        Vector3 pBot = transform.position + Vector3.up * (col.center.y - col.height * 0.5f + r);
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(pBot - Vector3.up * groundSkin, r);
    }
}
