using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private Camera photographyCamera;

    private void OnEnable()
    {
        EventManager.OnTakePhoto.Subscribe(SavePhoto);
        PhotoManager.Initialise();
    }

    private void OnDisable()
    {
        EventManager.OnTakePhoto.Unsubscribe(SavePhoto);
    }

    private void SavePhoto()
    {
        RenderTexture.active = renderTexture;
        photographyCamera.Render();
        Texture2D renderedImage = new Texture2D(renderTexture.width, renderTexture.height);
        renderedImage.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        Byte[] byteArray = renderedImage.EncodeToPNG();
        System.IO.File.WriteAllBytes($"{PhotoManager.PhotoDirectoryPath}/photo{PhotoManager.CurrentAlbumSize}.png", byteArray);
        PhotoManager.CurrentAlbumSize++;
    }
}
