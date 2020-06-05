using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ServerModels;

public class DataLoadingAndSaving : MonoBehaviour
{
	public string td_key;
	public string td_value;

	public void SetTitleData( string keyToSet, string valueToSet)
	{
		PlayFabServerAPI.SetTitleData(
			new SetTitleDataRequest
			{
				Key = keyToSet,
				Value = valueToSet
			},
			result => Debug.Log("Set titleData successful"),
			error => {
				Debug.Log("Got error setting titleData:");
				Debug.Log(error.GenerateErrorReport());
			}
		);
	}

	public void GetTitleData(string keyToGet)
	{
		PlayFabServerAPI.GetTitleData(new GetTitleDataRequest(),
			result => {
				if (result.Data == null || !result.Data.ContainsKey(keyToGet)) Debug.Log("No such key");
				else
				{
					Debug.Log("Mathcing key found");
					td_value = result.Data[keyToGet];
				}
			},
			error => {
				Debug.Log("Got error getting titleData:");
				Debug.Log(error.GenerateErrorReport());
			});
	}

}
