using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelView : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tile _tileGround;
    [SerializeField] private Tile _tileIce;
    [SerializeField] private int _mapWeight;
    [SerializeField] private int _mapHeight;
    [SerializeField] private int _factorSmooth;
    [SerializeField] [Range(0, 100)] private int _randomFillPercent;
    public Tilemap TileMap => _tileMap;
    public Tile TileGround => _tileGround;
    public Tile TileIce => _tileIce;
    public int MapWeight => _mapWeight;
    public int MapHeight => _mapHeight;
    public int FactorSmooth => _factorSmooth;
    public int RandomFillPercent => _randomFillPercent;
}
