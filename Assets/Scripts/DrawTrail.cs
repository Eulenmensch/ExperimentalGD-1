using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public GameObject trailPrefab;
    public GameObject currentTrail;

    public LineRenderer lineRenderer;
    public List<Vector2> playerPositions;

    Parasite parasite;

    // Start is called before the first frame update
    void Start()
    {
        parasite = GetComponent<Parasite>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempPlayerPos = parasite.transform.position;
        if(Vector2.Distance(tempPlayerPos, playerPositions[playerPositions.Count - 1]) > 0.4f)
        {
            UpdateTrail(tempPlayerPos);
        }
    }

    public void CreateTrail()
    {
        Debug.Log("CREATED");
        currentTrail = Instantiate(trailPrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentTrail.GetComponent<LineRenderer>();
        playerPositions.Clear();
        playerPositions.Add(parasite.transform.position);
        playerPositions.Add(parasite.transform.position);
        lineRenderer.SetPosition(0, playerPositions[0]);
        lineRenderer.SetPosition(1, playerPositions[1]);
    }

    void UpdateTrail(Vector2 newPlayerPos)
    {
        playerPositions.Add(newPlayerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPlayerPos);
    }

	public Vector3[] GetTrailPositions()
	{
		Vector3[] arrayToReturn = new Vector3[lineRenderer.positionCount];
		lineRenderer.GetPositions(arrayToReturn);
		return arrayToReturn;
	}
}
