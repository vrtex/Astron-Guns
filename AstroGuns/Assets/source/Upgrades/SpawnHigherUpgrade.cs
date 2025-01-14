﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHigherUpgrade : Upgrade
{
    public float Chance { get => (CurrentLevel - 1) * 0.1f / 100; }
    public override string GetDescription()
    {
        return string.Format("Items have a {0}% chance to spawn 1 level higher", Chance * 100);
    }

    public override double GetUpgradeCost()
    {
        return Math.Round(0.000868 * Math.Pow(CurrentLevel, 13), MidpointRounding.AwayFromZero);
    }

    public override void Increase()
    {
        base.Increase();
        UpgradesManager.Manager.Spawner.HigherSpawnChance = Chance;
    }

	public override void SetLevel(int lvl)
	{
		base.SetLevel(lvl);
		UpgradesManager.Manager.Spawner.HigherSpawnChance = Chance;
	}
}