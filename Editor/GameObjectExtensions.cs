using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GameObjectExtensions
{
	private static double renameTime;

	[MenuItem("GameObject/Extend/Group Selected %_g")]
	static void GroupSelected()
	{
		if (Selection.gameObjects.Length > 0)
		{
			var centerOfSelected = new Vector3(0, 0, 0);
			var previousParent = Selection.gameObjects[0].transform.parent;
			int siblingIndex = int.MaxValue;
			bool haveOneParent = true;
			for (int i = 0; i < Selection.gameObjects.Length; i++)
			{
				centerOfSelected += Selection.gameObjects[i].transform.position;
				if (previousParent != Selection.gameObjects[i].transform.parent)
				{
					haveOneParent = false;
				}
				if (Selection.gameObjects[i].transform.GetSiblingIndex() < siblingIndex)
				{
					siblingIndex = Selection.gameObjects[i].transform.GetSiblingIndex();
				}
			}
			centerOfSelected /= Selection.gameObjects.Length;
			var groupParent = new GameObject("New Group");
			if (haveOneParent)
			{
				groupParent.transform.SetParent(previousParent);
				groupParent.transform.SetSiblingIndex(siblingIndex);
			}
			groupParent.transform.position = centerOfSelected;
			Undo.RegisterCompleteObjectUndo(Selection.gameObjects, "Group objects");
			for (int i = 0; i < Selection.gameObjects.Length; i++)
			{
				Selection.gameObjects[i].transform.SetParent(groupParent.transform);
			}

			EditorApplication.update += EngageRenameMode;
			renameTime = EditorApplication.timeSinceStartup + 0.4d;
			EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
			Selection.activeGameObject = groupParent;
		}
		//Selection.objects;
	}


	private static void EngageRenameMode()
	{
		if (EditorApplication.timeSinceStartup >= renameTime)
		{
			EditorApplication.update -= EngageRenameMode;
			var e = new Event { keyCode = KeyCode.F2, type = EventType.KeyDown }; // or Event.KeyboardEvent("f2");
			EditorWindow.focusedWindow.SendEvent(e);
		}
	}
}

public class ReplacerWindow : EditorWindow
{
	private GameObject replace;

	[MenuItem("Tools/Replacer")]
	static void Init()
	{
		var window = EditorWindow.GetWindow<ReplacerWindow>();
		window.Show();
	}

	private void OnGUI()
	{
		replace = EditorGUILayout.ObjectField("Prefab", replace, typeof(GameObject), false) as GameObject;
		if (GUILayout.Button("Replace"))
		{
			var so = Selection.gameObjects;
			foreach (var item in so)
			{
				GameObject osd = PrefabUtility.InstantiatePrefab(replace) as GameObject;
				osd.transform.position = item.transform.position;
				osd.transform.parent = item.transform.parent;
				osd.transform.rotation = item.transform.rotation;
				Undo.DestroyObjectImmediate(item);
				Undo.RegisterCreatedObjectUndo(osd, "Replace Selected to Prefab");
			}
		}
	}
}
