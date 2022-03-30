using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T Instance { get; private set; }

	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Debug.LogErrorFormat("Trying to instantiate a second instance of singleton class {0}", GetType().Name);
		}
		else
		{
			Instance = (T)this;
		}
	}

	protected virtual void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
