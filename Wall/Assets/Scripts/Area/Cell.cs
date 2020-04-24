using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    [SerializeField] private List<Block> blocks;

    private void OnEnable()
    {
        GameManager.Instance.Select += () => Select(Const.SelectedPerCell);
    }
    public void Select(int blocksNum)
    {
        for (int i = 0; i < blocksNum;)
        {
            int j = Random.Range(0, blocks.Count);
            if (!blocks[j].IsSelected)
            {
                blocks[j].Select();
                i++;
            }
        }
    }
}
