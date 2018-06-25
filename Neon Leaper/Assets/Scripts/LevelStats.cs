using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStats {
	public bool levelPassed = false;
	
	static public LevelStats Deserialize(string str) {
		string code = PlayerPrefs.GetString(str, null);
		return JsonUtility.FromJson<LevelStats>(code);
	}
}
