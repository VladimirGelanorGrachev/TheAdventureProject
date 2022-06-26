using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelController
{
    private const int CountWall = 4;
    
    private Tilemap _tileMapGround;
    private Tile _tileGround;
    private int _widthMap;
    private int _heightMap;
    private int _factorSmooth;
    private int _randomFillPercent;

    private int[,] _map;

    public GenerateLevelController(GenerateLevelView generateLevelView)
    {
        _tileMapGround = generateLevelView.TileMapGround;
        _tileGround = generateLevelView.TileGround;
        _widthMap = generateLevelView.WidthMap;
        _heightMap = generateLevelView.HeightMap;
        _factorSmooth = generateLevelView.FactorSmooth;
        _randomFillPercent = generateLevelView.RandomFillPercent;

        _map = new int[_widthMap, _heightMap];
    }
    private MarchingSquaresGeneratorLevel _marchingSquaresGeneratorLevel = new MarchingSquaresGeneratorLevel();

    public void Awake()
    {        
        GenerateLevel();
    }

    public void ClearTileMap()
    {
        if (_tileMapGround != null)
            _tileMapGround.ClearAllTiles();

    }

    private void GenerateLevel()
    {
        RandomFillLevel();
        for (var i = 0; i < _factorSmooth; i++)
            SmoothMap();
        _marchingSquaresGeneratorLevel.GenerateGrid(_map, 1);
        _marchingSquaresGeneratorLevel.DrawTilesOnMap(_tileMapGround, _tileGround);
    }



    private void RandomFillLevel()
    {
        var seed = Time.time.ToString();
        var pseudoRandom = new System.Random(seed.GetHashCode());
        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                if (x == 0 || x == _widthMap - 1 || y == 0 || y == _heightMap - 1)
                    _map[x, y] = 1;
                else
                    _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
            }
        }
    }

    private void SmoothMap()
    {
        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var neighbourWallTiles = GetSurroundingWallCount(x, y);
                if (neighbourWallTiles > CountWall)
                    _map[x, y] = 1;
                else if (neighbourWallTiles < CountWall)
                    _map[x, y] = 0;
            }
        }
    }
    private int GetSurroundingWallCount(int gridX, int gridY)
    {
        var wallCount = 0;
        for (var neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (var neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < _widthMap && neighbourY >= 0 && neighbourY < _heightMap)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                        wallCount += _map[neighbourX, neighbourY];
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    private void DrawTilesOnMap()
    {
        if (_map == null)
            return;
        for (var x = 0; x < _widthMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var positionTile = new Vector3Int(-_widthMap / 2 + x,
                -_heightMap / 2 + y, 0);
                if (_map[x, y] == 1)
                    _tileMapGround.SetTile(positionTile, _tileGround);
            }
        }
    }
}

        