using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GhostTimeline))]
public class GhostTimeline : MonoBehaviour
{
    #region Public
    public float m_timeScale = 1;
    public LinkedList<GhostRecord> m_records = new LinkedList<GhostRecord>();
    #endregion
}
