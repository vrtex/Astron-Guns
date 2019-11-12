﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoubleSpawnUpgrade : Upgrade
{
    private float DoubleChance { get => (CurrentLevel - 1) * 0.25f; }
    public override string GetDescription()
    {
        return string.Format("{0}% chance to spawn an extra item", (double)(DoubleChance));
    }

    public override double GetUpgradeCost()
    {
        return  0.146 * Math.Pow(CurrentLevel, 10);
    }

    public override void Increase()
    {
        base.Increase();
        Spawner.DoubleSpawnChance = DoubleChance / 100;
    }
}