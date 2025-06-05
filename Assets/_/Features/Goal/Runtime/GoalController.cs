using UnityEngine;

public class GoalController : MonoBehaviour
{
    #region Publics
    public Spawner m_spawner;
    #endregion


    #region Unity Api

    private void OnTriggerEnter(Collider other)
    {
           m_spawner.NextIteration();
    }
    #endregion


    #region Main Methods

    #endregion


    #region Utils

    #endregion


    #region Private and Protected

    #endregion


}
