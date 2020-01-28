﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    public WeaponObject weapon; // jeżeli nie ma broni w slocie, to weapon jest nullem
    public List<EnergyCore> EnergyCores = new List<EnergyCore>();
    public int CoreSlotsLimit = 1;

    public Slot()
    {
        for(int i = 0; i < 3; ++i)
            EnergyCores.Add(null);

        // EquipCore(1, new EnergyCore { Level = 1, Type = EnergyCore.EnergyCoreType.Profit });
    }


    public void EquipCore(int index, EnergyCore energyCore)
    {
        EnergyCores[index] = energyCore;
    }

    public void UnequipCore(int index)
    {
        EnergyCores[index] = null;
    }

    public EnergyCore GetCoreAtIndex(int index)
    {
        return EnergyCores[index];
    }

    public List<EnergyCore> GetCurrentCores()
    {
        return EnergyCores.FindAll((EnergyCore e) => e != null);
    }

    public float GetCoreValue(EnergyCore.EnergyCoreType energyCoreType)
    {
        float toReturn = 0;
        EnergyCores
            .FindAll((EnergyCore e) => e != null)
            .FindAll((EnergyCore e) => e.Type == energyCoreType)
            .ForEach((EnergyCore e) => toReturn += e.Value);
        return toReturn;
    }
}
