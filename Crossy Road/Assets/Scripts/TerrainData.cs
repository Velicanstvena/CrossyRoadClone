﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Tearrain Data")]
public class TerrainData : ScriptableObject
{
    public List<GameObject> possibleTerrains;
    public int maxInSuccession;
}
