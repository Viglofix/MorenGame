﻿using GameObjects;
using GameObjects.BasicGameMechanisms;
using ProjectMoren.FirstMap.MorenLocation.Enemies;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseElderyEntities;
using ProjectMoren.StaticClasses;
using ProjectMoren.Templates;

namespace ProjectMoren.FirstMap.MorenLocation;

public class MARKS : Shop
{
    public bool MARKSEnterPossibility { get; set; } = true;
    public bool DeathAgreement { get; set; } = true;
    public bool NoAgreementToDeathPossibility { get; set; } = true;
    public bool MARKSEnterAgreement { get; set; } = true;


    public string MARKSName { get; set; }
    public int MARKSAge { get; set; }

    string agreement;
    bool intAgreement;

    public void MARKSBeginning(PlayerObject player, IEnemy enemy, PlayerEquipmentStatistics stat, QuestService questServices)
    {
        if (MARKSEnterPossibility == true && DeathAgreement == true)
        {
            DialogueQuestion.ThreeHeroesTwo(1, "BuchMajster", "Fiflin", "CO JEST SZTYWNONOGI, BIC SIE CHCESZ ?", "Znaczy sie... Moze nie z Panem..., ale tak! ", "", "");
            DialogueQuestion.ThreeHeroesTwo(1, "BuchMajster", "Fiflin", "NO DOBRA, GLOWNA ZASADA NASZEJ AGENCJI JEST SZACUNEK KAZDEGO \n KTO CHCE SIE LAC, NAWET GDY JEST MIESEM NA SZCZUDLACH", "Dziekuje! Moge sie juz bic ?", "", "");
            DialogueQuestion.ThreeHeroesTwo(1, "BuchMajster", "Fiflin", "SLUCHAJ CHLOPIE, PIERWSZE FORMALNOSCI PROSZE PODPISAC TEN DRUCZEK", "No dobrze...", "", "");

            DefaultTemplate.DefaultTemplateMethod(1, " | Oswiadczam, ze w razie jakiegokolwiek uszczerbku na zdrowiu lub smierci \n nie zloze wniosku o pozew do Morenskiego Sadu okregowego przy domu Wodza, \n agencji Morenska Arena Rekreacyjno-Kulturalna-Sportowa  \n w skrocie MARKS ani nie bede skladal zadnych roszczen wobec niej. \n Oswiadczam rowniez ze najblizsza rodzina i bliscy nie beda prawomocni do tego aby skladac \n roszczenia o odszkodowanie do agencji MARKS|", "Nie Zgadzam sie");
            agreement = Console.ReadLine();
            intAgreement = int.TryParse(agreement, out int result);
            if (result == 0)
            {
                Thread.Sleep(3000);
                Console.WriteLine("...Podpisano Oswiadczenie...");
                Thread.Sleep(3000);
                DialogueQuestion.ThreeHeroesTwo(1, "BuchMajster", "Fiflin", "DOBRA TERAZ ZMYKAJ DO WARLINA, ON POWIE CI DALEJ CO I JAK", "Dziekuje Panu!", "", "");
                DeathAgreement = false;
                MARKSEnterPossibility = false;

                Thread.Sleep(4000);

                Console.WriteLine();

                Console.WriteLine("^Warlin: Podaj swoje imie wojowiku: ");
                agreement = Console.ReadLine();
                MARKSName = agreement;
                Console.WriteLine($"^Fiflin: {MARKSName}");
                Console.WriteLine("^Warlin: Podaj swoj wiek wojowiku: ");
                agreement = Console.ReadLine();
                intAgreement = int.TryParse(agreement, out int resultSecond);
                MARKSAge = resultSecond;
                Console.WriteLine($"^Fiflin: {MARKSAge}");
                Thread.Sleep(3000);
                Console.WriteLine("^Warlin: Dobrze, wiec teraz mam wszystkie niezbedne informacje na twoj temat wojowniku. Teraz jestes gotow do walki!");
                Console.WriteLine("...");
                Thread.Sleep(2000);
                if (questServices.GetQuestByName("Udaj sie na arene, chociaz pierwsze polecalbym udac sie do sklepu {MARKS}") != null)
                {
                    questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie na arene, chociaz pierwsze polecalbym udac sie do sklepu {MARKS}").Id);
                }
            }
            else
            {
                Console.WriteLine("^BuchMajster: W takim razie wypad niemyty lumpaxie! i nie zawracaj mi wiecej gitary!");
                NoAgreementToDeathPossibility = false;
                MARKSEnterPossibility = false;
                if (questServices.GetQuestByName("Udaj sie na arene, chociaz pierwsze polecalbym udac sie do sklepu {MARKS}") != null)
                {
                    questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie na arene, chociaz pierwsze polecalbym udac sie do sklepu {MARKS}").Id);
                }
            }
        }
    }
    public void MARKSArena(PlayerObject player, IEnemy enemy, PlayerEquipmentStatistics stat)
    {
        Console.WriteLine($"WLASNIE TOCZYSZ POJEDYNEK Z {GetEnemyName(enemy)}");
        Thread.Sleep(3000);
        FightingSystem.Fight(player, enemy, stat);
    }

    public static string GetEnemyName(IEnemy enemy)
    {
        Type objectType = enemy.GetType();
        string NameOfObject = objectType.Name;
        return NameOfObject;
    }

    public void MARKSFight(PlayerObject player, Moren moren, Ges ges, PlayerEquipmentStatistics playerEq, QuestService questService)
    {
        moren.MARKSEnterAgreement = true;
        if (moren.MARKSEnterPossibility == true)
        {
            moren.MARKSBeginning(player, ges!, playerEq, questService!);
        }
        else if (moren.MARKSEnterPossibility == false && moren.DeathAgreement == false)
        {
            if (moren.MARKSAge >= 55)
            {
                object[] EnemiesObjectsArray = { new DziadekRumooplin(), new PanHeinzelin(), new PanMiliolin() };
                Random random = new Random();
                int luckyIndex = random.Next(0, EnemiesObjectsArray.Length);
                object luckyObject = EnemiesObjectsArray[luckyIndex];

                int[] randomWageArray = new int[] { 5, 10, 15 };
                int indexOfWage = random.Next(0, randomWageArray.Length);

                int randomWageArrayValue = randomWageArray[indexOfWage];

                using (EnemiesBase enemy = luckyObject as EnemiesBase)
                {
                    moren.MARKSArena(player, enemy, playerEq);
                    Console.WriteLine($"Wygrales pojedynek {moren.MARKSName}");

                    Console.WriteLine("Zdobyles: " + randomWageArrayValue + "Moren");
                    player.Moreny += randomWageArrayValue;
                    Console.WriteLine("Twoje Moreny: " + player.Moreny);
                    // enemyOne.Dispose(); Nalezy pamietac o tym, ze metoda ta jest wywolywana automatycznie w using, a uzywanie jej jawnie moze prowadzic do wycieku pamieci i nieprawidlowego zarzadzanania zasobow
                }
            }
            else
            {
                // Tutaj beda trudniejsi przeciwnicy... 
                object[] EnemiesObjectsArray = { new Voxenfix(), new Hamerlin(), new GombaShin() };
                Random random = new Random();
                int luckyIndex = random.Next(0, EnemiesObjectsArray.Length);
                object luckyObject = EnemiesObjectsArray[luckyIndex];


                int[] randomWageArray = new int[] { 15, 20, 30 };
                int indexOfWage = random.Next(0, randomWageArray.Length);
                int randomWageArrayValue = randomWageArray[indexOfWage];

                using (EnemisBaseAdult enemy = luckyObject as EnemisBaseAdult)
                {
                    moren.MARKSArena(player, enemy, playerEq);
                    Console.WriteLine($"Wygrales pojedynek {moren.MARKSName}");

                    Console.WriteLine("Zdobyles: " + randomWageArrayValue + "Moren");
                    player.Moreny += randomWageArrayValue;
                    Console.WriteLine("Twoje Moreny: " + player.Moreny);
                    // enemyOne.Dispose(); Nalezy pamietac o tym, ze metoda ta jest wywolywana automatycznie w using, a uzywanie jej jawnie moze prowadzic do wycieku pamieci i nieprawidlowego zarzadzanania zasobow
                }
            }
        }
        else
        {
            Console.WriteLine("^BuchMajster: WYPAD PTASIMOZGU!");
        }
    }

}
