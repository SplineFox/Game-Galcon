using System;
using UnityEngine;

public class LevelArea : ILevelArea
{
    [Serializable]
    public class Settings
    {
        public float OffsetFromEdges;
    }

    private readonly Settings _settings;
    private readonly Camera _camera;

    public LevelArea(Settings settings, Camera camera)
    {
        _settings = settings;
        _camera = camera;
    }

    public float Bottom
    {
        get { return -ExtentHeight; }
    }

    public float Top
    {
        get { return ExtentHeight; }
    }

    public float Left
    {
        get { return -ExtentWidth; }
    }

    public float Right
    {
        get { return ExtentWidth; }
    }

    public float ExtentHeight
    {
        get { return _camera.orthographicSize - _settings.OffsetFromEdges; }
    }

    public float Height
    {
        get { return ExtentHeight * 2.0f; }
    }

    public float ExtentWidth
    {
        get { return _camera.aspect * _camera.orthographicSize - _settings.OffsetFromEdges; }
    }

    public float Width
    {
        get { return ExtentWidth * 2.0f; }
    }
}