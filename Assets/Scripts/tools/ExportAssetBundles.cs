using UnityEngine;
using UnityEditor;

public class ExportAssetBundles {
	[MenuItem("Assets/Build AssetBundle From Selection")]
	static void ExportResource () 
	{
		StringHolder holder = ScriptableObject.CreateInstance<StringHolder>();
		holder.content = new string[Selection.objects.Length];

		for(var i = 0; i < holder.content.Length; i++)
		{
			holder.content[i] = Selection.objects[i].name;
		}

		string objectNamesFilePath = "Assets/objectsList.asset";
		AssetDatabase.CreateAsset(holder, objectNamesFilePath);
		Object createdObject = AssetDatabase.LoadAssetAtPath(objectNamesFilePath, typeof(Object));
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");

		if (path.Length != 0) 
		{
			Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
			System.Array.Resize(ref selection, selection.Length + 1);
			selection[selection.Length - 1] = createdObject;

			BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, 
			                               BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
			Selection.objects = selection;
			AssetDatabase.DeleteAsset(objectNamesFilePath);
		}
	}
}