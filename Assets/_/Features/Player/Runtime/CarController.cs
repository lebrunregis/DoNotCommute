using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CarController : MonoBehaviour
{
    public Camera m_camera;
    public float m_rotation;
    public Vector3 m_velocity = new(0, 0, 0);
    public Vector3 m_angularVelocity = new(0, 0, 0);
    public float m_acceleration = 1.0f;
    public float m_angularSpeed = 15.0f;
    public bool m_grounded = false;
    public float m_gravity = -10;
    public float m_jumpHeight = 2;
    public float m_friction = 0.5f;
    public Transform m_transform;

    private void OnEnable()
    {
        m_cc = GetComponent<CharacterController>();
        m_rotation = m_transform.rotation.y;
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
            transform.forward = move;   
            m_velocity += move.z * m_acceleration * transform.forward * Time.deltaTime;
        m_rotation += move.x  * m_angularSpeed* Time.deltaTime;
        } else
        {
            m_velocity -= m_velocity * m_friction * Time.deltaTime;
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

        m_transform.rotation = Quaternion.Euler(0, m_rotation,0);

        m_cc.Move(m_velocity * Time.deltaTime);
    } 
    private CharacterController m_cc;
}
