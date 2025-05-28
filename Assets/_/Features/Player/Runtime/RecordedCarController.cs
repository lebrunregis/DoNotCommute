using UnityEngine;

[RequireComponent(typeof(CarController))]
[RequireComponent(typeof(GhostManager))]
public class RecordedCarController : MonoBehaviour
{
    #region Publics

    #endregion


    #region Unity Api

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ghostManager.Play();
            m_carController.enabled = false;
        }
    }

    private void OnEnable()
    {
        m_carController = GetComponent<CarController>();
        m_ghostManager = GetComponent<GhostManager>();
        m_ghostManager.enabled = true;

    }

    #endregion


    #region Main Methods

    #endregion


    #region Utils

    #endregion


    #region Private and Protected
    private CarController m_carController;
    private GhostManager m_ghostManager;
    #endregion


}
