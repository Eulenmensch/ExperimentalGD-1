using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class GameStateManager : MonoBehaviour
{
    public GameStateData gameStateData;
    public bool initilaized = false;
    public System.Action OnInitialized;

    public List<Organ> defaulOrgans;
    public Player currentPlayer;

    Parasite _parasite;
    string serializedData;
    public string EggCode;


    private void Awake()
    {

        _parasite = FindObjectOfType<Parasite>();

    }

    public void Update()
    {
        if ( Input.GetKeyDown( KeyCode.S ) )
        {
            SaveState();
        }

        if ( Input.GetKeyDown( KeyCode.L ) )
        {
            LoadState();
        }
    }
    public void CreateNewState()
    {
        gameStateData = new GameStateData();
        gameStateData.organs = defaulOrgans;
        gameStateData.AssignRandomCode();
        gameStateData.historicPlayers = new List<Player>();

        currentPlayer = new Player();
        currentPlayer.Initialize();

        _parasite.activePlayer = currentPlayer;
        _parasite.historicPlayers = new List<Player>();

        initilaized = true;
        OnInitialized?.Invoke();
    }

    public void SaveState()
    {
        currentPlayer.trailPositions = _parasite.GetComponent<DrawTrail>().GetTrailPositions();
        gameStateData.historicPlayers.Add( currentPlayer );
        serializedData = SerializeObjectToString<GameStateData>( gameStateData );

        DataLoadingAndSaving.SetTitleData( gameStateData.code, serializedData );
    }

    public void LoadState()
    {
        DataLoadingAndSaving.GetTitleData( EggCode );
        DataLoadingAndSaving.OnDataRecovered += () =>
        {
            serializedData = DataLoadingAndSaving.recoveredValue;
            gameStateData = XmlDeserializeFromString( serializedData );
            initilaized = true;
            OnInitialized?.Invoke();

            //TODO: Maybe this works?
            currentPlayer = new Player();
            currentPlayer.Initialize();
            _parasite.activePlayer = currentPlayer;
        };


    }

    public string SerializeObjectToString<T>(T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer( toSerialize.GetType() );

        using ( StringWriter textWriter = new StringWriter() )
        {
            xmlSerializer.Serialize( textWriter, toSerialize );
            return textWriter.ToString();
        }
    }

    public GameStateData XmlDeserializeFromString(string serializedString)
    {
        var serializer = new XmlSerializer( typeof( GameStateData ) );

        StringReader stringReader = new StringReader( serializedString );

        GameStateData result = ( GameStateData )serializer.Deserialize( stringReader );

        return result;
    }
}
