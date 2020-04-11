using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class CapsuleMovement : MonoBehaviour
{
    RaycastHit m_HitInfo = new RaycastHit();
    Vector3 AgentPosition;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                GetComponent<NavMeshAgent>().destination = m_HitInfo.point;
            }
                

        }
    }

    private void OnDrawGizmos()
    {
        SetAgentPosition();
        NavMeshAgent m_Agent = GetComponent<NavMeshAgent>();
        if (m_Agent != null && m_Agent.hasPath)
        {
            NavMeshPath m_Path = m_Agent.path;
            Gizmos.color = Color.blue;
            if (m_Path != null && m_Path.corners != null && m_Path.corners.Length > 0)
            {
                var prev = AgentPosition;
                for (int i = 0;
                    i < m_Path.corners.Length; ++i)
                {
                    Gizmos.DrawLine(prev, m_Path.corners[i]);
                    prev = m_Path.corners[i];
                }
            }
        }
    }
    void SetAgentPosition()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position,
                                  out hit, 1.0f,
                                  NavMesh.AllAreas))
        {
            AgentPosition = hit.position;
        }
    }
}