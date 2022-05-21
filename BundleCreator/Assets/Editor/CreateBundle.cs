using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateBundle
{

    public static string assetBundleDirectory = "Assets/Bundles/";

    [MenuItem("Assets/Create Bundles")]
    static void BuildBundles()
    {

        //if main directory doesnt exist create it
        if (Directory.Exists(assetBundleDirectory))
        {
            Directory.Delete(assetBundleDirectory, true);
        }

        Directory.CreateDirectory(assetBundleDirectory);

        Debug.Log("Creating buindles for Windows 64");
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

        RemoveSpacesInFileNames();

        AssetDatabase.Refresh();
        Debug.Log("Process complete!");
    }

    static void RemoveSpacesInFileNames()
    {
        foreach (string path in Directory.GetFiles(assetBundleDirectory))
        {
            string oldName = path;
            string newName = path.Replace(' ', '-');
            File.Move(oldName, newName);
        }
    }
}