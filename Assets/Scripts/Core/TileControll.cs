using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { UpLeft, UpRight, DownLeft, DownRight}

public class TileControll : MonoBehaviour
{
    public Vector2Int coordinate;

    public TileControll GetNeighbour(Direction direction)
    {
        var targetCoordinate = coordinate;
        switch (direction)
        {
            case Direction.UpLeft:
                targetCoordinate.x--;
                targetCoordinate.y++;
                break;
            case Direction.UpRight:
                targetCoordinate.x++;
                targetCoordinate.y++;
                break;
            case Direction.DownLeft:
                targetCoordinate.x--;
                targetCoordinate.y--;
                break;
            case Direction.DownRight:
                targetCoordinate.x++;
                targetCoordinate.y--;
                break;
            default:
                break;
        }

        return TowerManager.instance.GetTile(targetCoordinate);
    }
}
