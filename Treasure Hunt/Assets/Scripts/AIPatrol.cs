using UnityEngine;
using System.Collections.Generic;

public class AIPatrol : MonoBehaviour {
    public float speed = 2f;
    public float detectionDistance = 2f;
    public float rotationSpeed = 2f;
    public int numberOfWaypoints = 8;
    public float patrolRadius = 5f;
    
    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;
    private Vector3 targetPosition;

    // Reference to the assigned treasure and terrain
    public Transform targetTreasure;
    public GameObject plane;

    void Start() {
        if (targetTreasure != null && plane != null) {
            GenerateWaypointsAroundTreasure();
            if (waypoints.Count > 0) {
                targetPosition = waypoints[currentWaypoint];
            }
        }
        else {
            Debug.LogError("Target treasure or plane not assigned to AI patrol.");
        }
    }

    void GenerateWaypointsAroundTreasure() {
        waypoints.Clear();

        // Calculate the plane's boundaries
        MeshRenderer planeRenderer = plane.GetComponent<MeshRenderer>();
        float planeWidth = planeRenderer.bounds.size.x / 2;
        float planeLength = planeRenderer.bounds.size.z / 2;
        Vector3 planeCenter = plane.transform.position;

        for (int i = 0; i < numberOfWaypoints; i++) {
            float angle = i * Mathf.PI * 2 / numberOfWaypoints;
            float x = targetTreasure.position.x + Mathf.Cos(angle) * patrolRadius;
            float z = targetTreasure.position.z + Mathf.Sin(angle) * patrolRadius;

            // Clamp x and z within plane boundaries
            x = Mathf.Clamp(x, planeCenter.x - planeWidth, planeCenter.x + planeWidth);
            z = Mathf.Clamp(z, planeCenter.z - planeLength, planeCenter.z + planeLength);

            // Adjust y to match terrain height
            float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)) + Terrain.activeTerrain.transform.position.y;

            waypoints.Add(new Vector3(x, y, z));
        }
    }

    void Update() {
        MoveTowardsTarget();

        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, out hit, detectionDistance)) {
                SelectNewWaypoint();
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f) {
            SelectNextWaypoint();
        }
    }

    void MoveTowardsTarget() {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void SelectNextWaypoint() {
        if (waypoints.Count == 0) return;

        currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        targetPosition = waypoints[currentWaypoint];
    }

    void SelectNewWaypoint() {
        if (waypoints.Count == 0) return;

        int newWaypoint = currentWaypoint;
        while (newWaypoint == currentWaypoint) {
            newWaypoint = Random.Range(0, waypoints.Count);
        }
        currentWaypoint = newWaypoint;
        targetPosition = waypoints[currentWaypoint];
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistance);

        Gizmos.color = Color.green;
        foreach (Vector3 waypoint in waypoints) {
            Gizmos.DrawSphere(waypoint, 0.5f);
        }
    }
}
