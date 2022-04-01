using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GenerateLevelController
{
    private const int CountWall = 4;
    public const string TileMapName = nameof(_tileMap);
    public const string TileGroundName= nameof(_tileGround);
    public const string TileIceName = nameof(_tileIce);
    public const string MapWeightName = nameof(_mapWeight);
    public const string MapHeightName = nameof(_mapHeight);
    public const string FactorSmoothName = nameof(_factorSmooth);
    public const string RandomFillPercentName = nameof(_randomFillPercent);

    private Tilemap _tileMap;
    private Tile _tileGround;
    private Tile _tileIce;

    private int _mapWeight;
    private int _mapHeight;
    private int _factorSmooth;
    private int _randomFillPercent;
    private int[,] _map;

  

    public GenerateLevelController(GenerateLevelView levelView)
    {
        _tileMap = levelView.TileMap;
        _tileGround = levelView.TileGround;
        _tileIce = levelView.TileIce;

        _mapWeight = levelView.MapWeight;
        _mapHeight = levelView.MapHeight;
        _factorSmooth = levelView.FactorSmooth;
        _randomFillPercent = levelView.RandomFillPercent;
        _map = new int[_mapWeight, _mapHeight];
    }

   

    public void GenerateLevel()
    {
        RandomFillLevel();

        for (int i = 0; i < _factorSmooth-1; i++)
        {
            SmothMap();
        }

        DrawTileOnMap();
        DrawIce();
    }

    private void DrawIce()
    {
        if (_map == null) throw new NullReferenceException($"map is null");

        for (int x = 2; x <= _mapWeight/4; x++)
        {
            for (int y = 0; y <1; y++)
            {
                var positionTile = new Vector3Int(-_mapWeight / 2 + x, -_mapHeight / 2 + y, 0);
                if (_map[x, y] == 1)
                {
                    _tileMap.SetTile(positionTile, _tileIce);
                }
            }
        }
    }

    private void DrawTileOnMap()
    {
        if (_map == null) throw new NullReferenceException($"map is null");
   
        for (int x = 0; x <= _mapWeight - 1; x++)
        {
            for (int y = 0; y <= _mapHeight - 1; y++)
            {
                var positionTile = new Vector3Int(-_mapWeight / 2 + x, -_mapHeight / 2 + y, 0);
                if (_map[x, y] == 1)
                {
                    _tileMap.SetTile(positionTile, _tileGround);
                }
            }
        }
    }

    public void ClearMap()
    {
        if (_tileGround !=null)
        {
            _tileMap.ClearAllTiles();
        }
    }

    private void SmothMap()
    {
        for (int x = 0; x < _mapWeight-1; x++)
        {
            for (int y = 0; y < _mapHeight-1; y++)
            {
                var neigbordWall = GetNeghbhourWallCount(x, y);
                if (neigbordWall > CountWall)
                {
                    _map[x, y] = 1;
                }
                else
                {
                    _map[x, y] = 0;
                }
            }
        }
    }

    private int GetNeghbhourWallCount(int gridx, int gridy)
    {
        var wallCount = 0;
        for (var neighbhourX = gridx - 1; neighbhourX <= gridx + 1; neighbhourX++)
        {
            for (var neighbhourY = gridy - 1; neighbhourY <= gridy + 1; neighbhourY++)
            {
                if (IsNotTileOnTheBoard(neighbhourX, neighbhourY))
                {
                    if (neighbhourX != gridx || neighbhourY != gridy)
                    {
                        wallCount += _map[neighbhourX, neighbhourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    private bool IsNotTileOnTheBoard(int neighbhourX, int neighbhourY)
    {
        return (neighbhourX >= 0 && neighbhourX <= _mapWeight && neighbhourY >= 0 && neighbhourY < _mapHeight) ? true : false;
    }

    private void RandomFillLevel()
    {
        var psevdoRandom = new System.Random();
        for (int x = 0; x <= _mapWeight-1; x++)
        {
            for (int y = 0; y <= _mapHeight-1; y++)
            {
                if (x == 0 || x == _mapWeight - 1 || y == 0 || y == _mapHeight-1)
                {
                    _map[x, y] = 1;
                }
                else
                {
                    _map[x, y] = (psevdoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
                }
            }
        }
    }
}
