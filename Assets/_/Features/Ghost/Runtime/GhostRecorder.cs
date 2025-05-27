using UnityEngine;

[RequireComponent(typeof(GhostTimeline))]
public class GhostRecorder : MonoBehaviour
{
    #region Public

    public GhostModeEnum m_ghostMode;
    public float m_deltaTime = 0;
    public float m_time = 0;
    public Transform m_transform;
    #endregion

    public void OnEnable()
    {
        m_timeline = GetComponent<GhostTimeline>();
        m_deltaTime = m_timeline.m_timeScale;
    }

    public void Update()
    {
        m_time -= Time.deltaTime;
        if (m_deltaTime <= 0)
        {
            m_deltaTime = m_timeline.m_timeScale;
            GhostRecord ghostRecord = new(m_time, m_transform.position, m_transform.rotation);
            AddRecord(ghostRecord);
        }
    }
    public void AddRecord(GhostRecord record)
    {
        m_timeline.m_records.AddLast(record);
    }


    #region Private
    private GhostTimeline m_timeline;
    #endregion
}
