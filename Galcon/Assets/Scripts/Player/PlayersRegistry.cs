using System;
using UnityEngine;

public class PlayersRegistry : IPlayersRegistry
{
    [Serializable]
    public class Settings
    {
        public Color MainPlayerColor;
    }

    private readonly Settings _settings;
    private Player _mainPlayer;

    public Player MainPlayer => _mainPlayer;

    public PlayersRegistry(Settings settings)
    {
        _settings = settings;
        _mainPlayer = new Player(_settings.MainPlayerColor);
    }
}