
using CerealDevelopment.LifetimeManagement;

using System.Collections.Generic;
using System.Text;
#if UNITY_EDITOR
#endif
using UnityEngine;

public class ScriptableObjectsReferencer : MonoBehaviour
{
	private static ScriptableObjectsReferencer _instance;
	private static bool _needsInstance = true;
	public static ScriptableObjectsReferencer Instance
	{
		get
		{
			if (_needsInstance)
			{
				_instance = FindObjectOfType<ScriptableObjectsReferencer>();
				_needsInstance = _instance == null;
				if (_needsInstance)
				{
					var resource = Resources.Load<ScriptableObjectsReferencer>("Singletons/" + nameof(ScriptableObjectsReferencer));
					_instance = Instantiate(resource);
					_needsInstance = false;
				}
			}
			return _instance;
		}
	}


	public List<LifetimeScriptableObject> scriptableObjects = new List<LifetimeScriptableObject>();

	private void Awake()
	{
		var builder = new StringBuilder();
		builder.Append("Loading ScriptableObject references...");
		for (int i = 0; i < scriptableObjects.Count; i++)
		{
			builder.Append("\n");
			builder.Append(scriptableObjects[i].name);
			scriptableObjects[i].OnLifetimeEnable();
		}
		Debug.Log(builder.ToString());
	}
}
