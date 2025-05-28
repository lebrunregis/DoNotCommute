using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CarController : MonoBehaviour
{
    public Camera m_camera;
    public float m_rotation;
    public Vector3 m_velocity = new(0, 0, 0);
    public Vector3 m_angularVelocity = new(0, 0, 0);
    public float m_acceleration = 2.5f;
    public float m_angularSpeed = 90.0f;
    public bool m_grounded = false;
    public float m_gravity = -10;
    public float m_jumpHeight = 2;
    public float m_friction = 0.9f;
    public float m_maxSpeed = 2.5f;
    public LayerMask m_wallLayers;
    public LayerMask m_groundLayers;

    private void OnEnable()
    {
        m_cc = GetComponent<CharacterController>();
        m_rotation = transform.rotation.y;
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

        if (move != Vector3.zero)
        {
            m_velocity -= m_friction * Time.deltaTime * m_velocity;
            m_velocity += m_acceleration * move.z * Time.deltaTime * transform.forward;
            m_velocity = Vector3.ClampMagnitude(m_velocity, m_maxSpeed);
            m_rotation += move.x * m_angularSpeed * Time.deltaTime;
        }
        else
        {
            m_velocity -= m_friction * Time.deltaTime * m_velocity;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && m_grounded)
        {
            m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2.0f * m_gravity);
        }

        if (!m_grounded)
        {
            // Apply gravity
            m_velocity.y += m_gravity * Time.deltaTime;
        }
        else
        {
            m_velocity.y = 0f;
        }

        transform.rotation = Quaternion.Euler(0, m_rotation, 0);

        m_cc.Move(m_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == m_wallLayers)
        {
            m_velocity = Vector3.zero;
        }
    }
    private CharacterController m_cc;
}
