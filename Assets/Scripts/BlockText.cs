using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockText : MonoBehaviour
{
    public TMP_Text Text;
    private Block Block;

    private void Awake()
    {
        Block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        Block.AtttackUpdat += OnAtttackUpdat;
    }

    private void OnDisable()
    {
        Block.AtttackUpdat -= OnAtttackUpdat;
    }

    private void OnAtttackUpdat(int attackText)
    {
        Text.text = attackText.ToString();
    }
}
