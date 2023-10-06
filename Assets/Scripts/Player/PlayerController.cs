using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_isPressedLeft => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
    private bool m_isPressedRight => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightAlt);
    private bool m_isPressedUp => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

    private TileControll m_current;

    private void Start()
    {
        var tile = TowerManager.instance.GetTile(new Vector2Int(6, 6));
        Move(tile);
    }

    private void Update()
    {
        if (m_isPressedLeft)
        {
            var tile = m_current.GetNeighbour(m_isPressedUp ? Direction.UpLeft : Direction.DownLeft);
            Move(tile);
        }

        if (m_isPressedRight)
        {
            var tile = m_current.GetNeighbour(m_isPressedUp ? Direction.UpRight : Direction.DownRight);
            Move(tile);
        }
    }

    private void Move(TileControll tileControll)
    {
        if (!tileControll)
            return;
        
        var position = tileControll.transform.position;
        m_current = tileControll;
        position.y += 1;
        transform.position = position;

        if(!tileControll.transform.GetChild(0).gameObject.activeSelf)
            tileControll.transform.GetChild(0).gameObject.SetActive(true);
    }
}
