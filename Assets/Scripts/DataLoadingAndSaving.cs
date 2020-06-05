using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ServerModels;

public static class DataLoadingAndSaving
{
	public static string recoveredValue;

	public static void SetTitleData( string keyToSet, string valueToSet)
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

	public static void GetTitleData(string keyToGet)
	{
		PlayFabServerAPI.GetTitleData(new GetTitleDataRequest(),
			result => {
				if (result.Data == null || !result.Data.ContainsKey(keyToGet)) Debug.Log("No such key");
				else
				{
					Debug.Log("Mathcing key found");
					recoveredValue = result.Data[keyToGet];
				}
			},
			error => {
				Debug.Log("Got error getting titleData:");
				Debug.Log(error.GenerateErrorReport());
			});
	}

}
