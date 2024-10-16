using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    // variaveis de controle do tanque
    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;
    // variaveis de controle dos waypoints
    public WaypointManager waypointManager;
    GameObject[] waypoints;
    GameObject currentNode;
    int currentWaypoint = 0;
    Graph graph;

    void Start()
    {
        // inicializa as vari�veis
        waypoints = waypointManager.waypoints;
        graph = waypointManager.graph;
        currentNode = waypoints[0];

        // Invoke(nameof(GoToRuin), 2.0f);
    }
    // m�todos para ir para waypoints espec�ficos
    public void QuartoAmarelo()
    {
        graph.AStar(currentNode, waypoints[0]);
        currentWaypoint = 0;
    }

    public void QuartoCinza()
    {
        graph.AStar(currentNode, waypoints[26]);
        currentWaypoint = 0;
    }

    public void QuartoCasal()
    {
        graph.AStar(currentNode, waypoints[15]);
        currentWaypoint = 0;
    }

    public void Geladeira()
    {
        graph.AStar(currentNode, waypoints[24]);
        currentWaypoint = 0;
    }

    public void Piano()
    {
        graph.AStar(currentNode, waypoints[20]);
        currentWaypoint = 0;
    }

    public void Tv()
    {
        graph.AStar(currentNode, waypoints[29]);
        currentWaypoint = 0;
    }

    public void Sofa()
    {
        graph.AStar(currentNode, waypoints[18]);
        currentWaypoint = 0;
    }

    public void Banheiro()
    {
        graph.AStar(currentNode, waypoints[9]);
        currentWaypoint = 0;
    }
    
    public void Lavanderia()
    {
        graph.AStar(currentNode, waypoints[7]);
        currentWaypoint = 0;
    }

    public void AirHockey()
    {
        graph.AStar(currentNode, waypoints[19]);
        currentWaypoint = 0;
    }

    void Update()
    {
        // n�o temos caminho ou j� chegamos ao destino
        if(graph.GetPath().Count == 0 || currentWaypoint == graph.GetPath().Count) return;
        // se chegamos ao destino, vamos para o pr�ximo waypoint
        if (Vector3.Distance(graph.GetPath()[currentWaypoint].GetId().transform.position, transform.position) < accuracy)
        {
            currentNode = graph.GetPath()[currentWaypoint].GetId();
            currentWaypoint++;
        }
        // se n�o chegamos ao destino, vamos para o waypoint e olhamos para ele
        if(currentWaypoint < graph.GetPath().Count)
        {
            goal = graph.GetPath()[currentWaypoint].GetId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
