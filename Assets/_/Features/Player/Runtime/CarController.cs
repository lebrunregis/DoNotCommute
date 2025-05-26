using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CarController : MonoBehaviour
{
    //Rigidbody m_rb;
    private CharacterController m_cc;
    public Vector3 m_velocity = new(0, 0, 0);
    public Vector3 m_angularVelocity = new(0, 0, 0);
    public float m_speed = 1.0f;
    public float m_angularSpeed = 1.0f;
    public bool m_grounded = false;
    public float m_gravity = -10;
    public float m_jumpHeight = 2;

    private void OnEnable()
    {
        m_cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        m_grounded = m_cc.isGrounded;
        if (m_grounded && m_velocity.y < 0)
        {
            m_velocity.y = 0f;
        }

        // Horizontal input
        Vector3 move = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && m_grounded)
        {
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2.0f * m_gravity);
        }

        // Apply gravity
        m_velocity.y += m_gravity * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * m_speed) + (m_velocity.y * Vector3.up);
        m_cc.Move(finalMove * Time.deltaTime);
    }
}
