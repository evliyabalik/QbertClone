using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IsWin());
    }

    // Update is called once per frame
   

    private bool Win()
    {
        var tower = TowerManager.instance.transform;
        for (int i = 0; i < tower.childCount; i++)
        {
            if (!tower.GetChild(i).transform.GetChild(0).gameObject.activeSelf)
                return false;
        }

        Time.timeScale = 0;
        return true;
    }

    private IEnumerator IsWin()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (Win())
            {
                Debug.Log("Winner");
                break;
            }
        }
        yield return null;
    }
}
