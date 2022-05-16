using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFormation : FormationBase
{
    [SerializeField] private int _unitWidth = 5;
    [SerializeField] private int _unitDepth = 5;
    [SerializeField] private bool _hollow = false;
    [SerializeField] private float _nthOffset = 0;

    public override IEnumerable<Vector3> EvaluatePoints()
    {
        var middleOffset = new Vector3(_unitWidth * 0.5f, _unitDepth * 0.5f , 0);

        for (var x = 0; x < _unitWidth; x++)
        {
            for (var y = 0; y < _unitDepth; y++)
            {
                if (_hollow && x != 0 && x != _unitWidth - 1 && y != 0 && y != _unitDepth - 1) continue;
                var pos = new Vector3(x + (y % 2 == 0 ? 0 : _nthOffset), y , 0);

                pos -= middleOffset;

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }
        }
    }
}