using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PhotoManager
{
    public static int CurrentAlbumSize { get; set; }
    public static string PhotoDirectoryPath => $"{Application.dataPath}/PhotoCaptures";

    public static void Initialise()
    {
        Directory.CreateDirectory(PhotoDirectoryPath);
        CurrentAlbumSize = GetNumberOfPhotos();
    }

    private static int GetNumberOfPhotos()
    {
        int count = 0;
        DirectoryInfo directoryInfo = new DirectoryInfo(PhotoDirectoryPath);
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (var fileInfo in fileInfos)
        {
            if (fileInfo.Extension.Contains("png"))
                count++;
        }

        return count;
    }
}
