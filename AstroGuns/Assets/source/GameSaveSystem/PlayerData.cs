﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int		weaponSpawnLevel;
    public int[]	weaponsId;

    public double	playerCredits;
    public double	playerEther;

	public int		lastDailyReward;
	public int      lastTimeDailyReward;

	public bool     sound;
	public bool     music;

	public PlayerData()
    {
        // 00 level spawnowanej broni
        weaponSpawnLevel = Inventory.weaponSpawnLevel;

        // 01 poziomy broni w slotach, jeżeli nie ma, to -1
        weaponsId = new int[Inventory.SLOT_QUANTITY];
        for(int i = 0; i < Inventory.SLOT_QUANTITY; i++)
        {
            if(Inventory.slots[i].weapon != null)
            {
                weaponsId[i] = Inventory.slots[i].weapon.id;
            }
            else
            {
                weaponsId[i] = -1;
            }
        }

        // 02 stan kredytów
        playerCredits = MoneyPocket.Instance.Money.ActualValue;

        // 03 stan eteru
        playerEther = MoneyPocket.Instance.Ether.ActualValue;

		// 04 stan ulepszeń

		// 05 czas do stworzenia klucza // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

		// 06 godzina o której wyłączyliśmy grę // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

		// 07 który dzień z rzędu odbieramy nagrodę dnia // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie
		lastDailyReward = DateTimeSystem.Instance.lastDailyReward;
		lastTimeDailyReward = DateTimeSystem.Instance.lastTimeDailyReward;

		// 08 skrzynie

		// 09 klucze

		// 10 fragmenty kluczy

		// 11 rdzenie energetyczne

		// 12 meteory

		// 13 kupione sloty w magazynie skrzynek

		// 14 muzyka i dźwięki
		sound = AudioManager.Instance.soundsOn;
		music = AudioManager.Instance.musicOn;
	}

    public void Reset()
    {

        // 00 level spawnowanej broni
        weaponSpawnLevel = 1;

        // 01 poziomy broni w slotach, jeżeli nie ma, to -1
        weaponsId = new int[Inventory.SLOT_QUANTITY];
        for(int i = 0; i < Inventory.SLOT_QUANTITY; i++)
        {
            weaponsId[i] = -1;
        }

        // 02 stan kredytów
        playerCredits = 0;

        // 03 stan eteru
        playerEther = 0;

        // 04 stan ulepszeń

        // 05 czas do stworzenia klucza // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

        // 06 godzina o której wyłączyliśmy grę // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

        // 07 który dzień z rzędu odbieramy nagrodę dnia // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie
        lastDailyReward = -1;
        lastTimeDailyReward = -1;

		// 08 skrzynie

		// 09 klucze

		// 10 fragmenty kluczy

		// 11 rdzenie energetyczne

		// 12 meteory

		// 13 kupione sloty w magazynie skrzynek

		// 14 muzyka i dźwięki
		sound = true;
		music = true;
	}

    public static void ApplyPlayerData(PlayerData data)
    {
        if (data != null)
        {
            // 00 level spawnowanej broni
            Inventory.weaponSpawnLevel = data.weaponSpawnLevel;

            // 01 poziomy broni w slotach, jeżeli nie ma, to -1
            for (int i = 0; i < Inventory.SLOT_QUANTITY; i++)
            {
                WeaponSpawner.setWeaponData(i, data.weaponsId[i]);
                WeaponSpawner.resetWeaponView(i);
            }

            // 02 stan kredytów
            MoneyPocket.Instance.Money.ActualValue = data.playerCredits;

            // 03 stan eteru
            MoneyPocket.Instance.Ether.ActualValue = data.playerEther;

			// 04 stan ulepszeń

			// 05 czas do stworzenia klucza // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

			// 06 godzina o której wyłączyliśmy grę // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie

			// 07 który dzień z rzędu odbieramy nagrodę dnia // trzeba obgadać, żeby ktoś nie zmieniał daty w fonie
			DateTimeSystem.Instance.lastDailyReward = data.lastDailyReward;
			DateTimeSystem.Instance.lastTimeDailyReward = data.lastTimeDailyReward;

			// 08 skrzynie

			// 09 klucze

			// 10 fragmenty kluczy

			// 11 rdzenie energetyczne

			// 12 meteory

			// 13 kupione sloty w magazynie skrzynek

			// 14 muzyka i dźwięki
			AudioManager.Instance.soundsOn = data.sound;
			AudioManager.Instance.musicOn = data.music;
		}
    }
}
