using ProjectMoren.FirstMap.MorenLocation.Enemies;
using GameObjects;
using ProjectMoren.StaticClasses;

namespace ProjectMoren.Templates;

public static class FightingSystem
{
    public static void Fight(PlayerObject player, IEnemy enemy, PlayerEquipmentStatistics playerStats)
    {
        string? agreement;
        bool indexAgreement;
        int result;
        string selectItem;
        bool punchFlag = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Wybierz bron: ");
            Console.WriteLine("!Jesli chcesz wybrac piesc wybierz: 'punch'");
            Console.WriteLine("--------------");
            player.IterateThroughTheEquipment();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Ilosc zycia: {nameof(enemy)}: " + enemy.health);
            Console.WriteLine($"Ilosc zycia Fiflina: " + player.Hp);
            Console.WriteLine("--------------------------------------------");
            punchFlag = true;
            agreement = Console.ReadLine();
            bool agreementBool = agreement != "punch";
            if (player.Equipment.Count == 0)
            {
                switch (agreementBool.ToString())
                {
                    case "False":
                        if (player.punch >= enemy.health)
                        {
                            enemy.health = 0;
                        }
                        else if (enemy.damage >= player.Hp)
                        {
                            player.Hp = 0;
                        }
                        else
                        {
                            enemy.health -= player.punch;
                            player.Hp -= enemy.damage;
                        }
                        punchFlag = false;
                        break;
                    case "True":
                        goto case "False";
                }
            }
            if (agreement == "punch")
            {
                if (player.punch >= enemy.health)
                {
                    enemy.health = 0;
                }
                else if (enemy.damage >= player.Hp)
                {
                    player.Hp = 0;
                }
                else
                {
                    enemy.health -= player.punch;
                    player.Hp -= enemy.damage;
                }
                punchFlag = false;
            }

            if (punchFlag == true && player.Equipment.Count != 0)
            {
                indexAgreement = int.TryParse(agreement, out result);
                selectItem = player.GetEquipmentItemByIndex(player.Equipment, result);
                var item = playerStats.ItemDamageFromStatisticForItems(playerStats.GetProperty(selectItem));
                if (playerStats.GetTOne<StatisticsForItems>(selectItem) == player.Equipment[player.GetEquipmentIndexByItem(player.Equipment, selectItem)])
                {
                    if (item >= enemy.health)
                    {
                        enemy.health = 0;
                    }
                    else if (enemy.damage >= player.Hp)
                    {
                        player.Hp = 0;
                    }
                    else
                    {
                        enemy.health -= playerStats.ItemDamageFromStatisticForItems(playerStats.GetProperty(selectItem));
                        player.Hp -= enemy.damage;
                    }
                }
            }

        } while (enemy.health != 0 && player.Hp != 0);

        if (enemy.health == 0)
        {
            Type objectType = enemy.GetType();
            string NameOfObject = objectType.Name;
            Console.WriteLine($"Wygrales pojedynek z {NameOfObject}");
        }
        else
        {
            Console.WriteLine("No niestety ale to koniec twojej przygody");
            Environment.Exit(1);
        }
    }
}
