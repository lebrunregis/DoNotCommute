using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Publics

    #endregion
    public List<GameObject> m_vehicles = new();
    public List<GameObject> m_spawns = new();
    public List<GameObject> m_goals = new();
    public int m_iteration = 0;
    #region Unity Api

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    private void OnEnable()
    {
        FirstIteration();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void NextIteration()
    {
        // m_vehicles[m_iteration].SetActive(false);
        m_vehicles[m_iteration].GetComponent<CharacterController>().enabled = false;
        m_vehicles[m_iteration].GetComponent<CarController>().enabled = false;
        m_goals[m_iteration].SetActive(false);
        m_spawns[m_iteration].SetActive(false);
        m_iteration++;
        if (m_iteration < m_vehicles.Count)
        {
            m_vehicles[m_iteration].transform.position = m_spawns[m_iteration].transform.position;
            m_vehicles[m_iteration].transform.rotation = m_spawns[m_iteration].transform.rotation;
            m_vehicles[m_iteration].SetActive(true);
            m_goals[m_iteration].SetActive(true);
            for (int i = 0; i < m_iteration; i++)
            {
                GhostManager ghostManager = m_vehicles[i].GetComponent<GhostManager>();
                ghostManager.Play();
            }
        }
    }

    public void FirstIteration() { 
        m_vehicles[0].SetActive(true);
        m_goals[0].SetActive(true);
        m_spawns[0].SetActive(true);
        m_vehicles[0].transform.position = m_spawns[0].transform.position;
        m_vehicles[0].transform.rotation = m_spawns[0].transform.rotation;
    }
    #endregion


    #region Main Methods

    #endregion


    #region Utils

    #endregion


    #region Private and Protected

    #endregion


}
