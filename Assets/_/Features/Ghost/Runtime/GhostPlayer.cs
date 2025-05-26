using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GhostTimeline))]
public class GhostPlayer : MonoBehaviour
{
    #region Public
    public float m_time = 0;
    public float m_speed = 1;
    public Transform m_target;
    #endregion

    #region Private
    private GhostTimeline m_timeline;
    private LinkedListNode<GhostRecord> m_currentNode;
    #endregion

    #region API
    private void OnEnable()
    {
        m_timeline = GetComponent<GhostTimeline>();
        m_currentNode = m_timeline.m_records.First;
    }
    private void Update()
    {
        if (m_currentNode != null)
        {
            m_time += Time.deltaTime;
            if (m_currentNode.Value.time < m_time)
            {
                m_currentNode = m_currentNode.Next;
            }
        }
    }
    #endregion
}
