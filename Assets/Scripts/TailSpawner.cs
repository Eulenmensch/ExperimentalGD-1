using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tailSegmentPrefab;
    [SerializeField] private GameObject FirstTailSegmentTarget;
    GameStateManager gameStateManager;
    List<GameObject> tailSegments;
    List<TailSegmentController> tailSegmentControllers;

    void Awake()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.OnInitialized += SetHistoricTailSegments;
    }

    void SetHistoricTailSegments()
    {
        List<Player> historicPlayers = gameStateManager.gameStateData.historicPlayers;

        for ( int i = 0; i < historicPlayers.Count; i++ )
        {
            if ( i == 0 )
            {
                GameObject tailSegment = Instantiate( tailSegmentPrefab, FirstTailSegmentTarget.transform.position, Quaternion.identity );
                tailSegments.Add( tailSegment );
                tailSegment.GetComponent<TailSegmentController>().Target = FirstTailSegmentTarget;
                SpriteRenderer tailSprite = tailSegment.GetComponent<SpriteRenderer>();
                SerializableColor historicColor = historicPlayers[i].color;
                tailSprite.color = new Color( historicColor.r, historicColor.g, historicColor.b, historicColor.a );
            }
            else
            {
                GameObject tailSegment = Instantiate( tailSegmentPrefab, tailSegments[i - 1].GetComponentInChildren<Transform>().position, Quaternion.identity );
                tailSegments.Add( tailSegment );
                tailSegment.GetComponent<TailSegmentController>().Target = tailSegments[i - 1].GetComponentInChildren<Transform>().gameObject;
                SpriteRenderer tailSprite = tailSegment.GetComponent<SpriteRenderer>();
                SerializableColor historicColor = historicPlayers[i].color;
                tailSprite.color = new Color( historicColor.r, historicColor.g, historicColor.b, historicColor.a );
            }
        }
    }
}
