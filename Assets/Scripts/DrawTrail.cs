using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    public GameObject currentTrail;

    public LineRenderer lineRenderer;
    public List<Vector2> playerPositions;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempPlayerPos = player.transform.position;
        if(Vector2.Distance(tempPlayerPos, playerPositions[playerPositions.Count - 1]) > 0.4f)
        {
            UpdateTrail(tempPlayerPos);
        }
    }

    public void CreateTrail()
    {
        currentTrail = Instantiate(trailPrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentTrail.GetComponent<LineRenderer>();
        playerPositions.Clear();
        playerPositions.Add(player.transform.position);
        playerPositions.Add(player.transform.position);
        lineRenderer.SetPosition(0, playerPositions[0]);
        lineRenderer.SetPosition(1, playerPositions[1]);
    }

    void UpdateTrail(Vector2 newPlayerPos)
    {
        playerPositions.Add(newPlayerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPlayerPos);
    }
}
