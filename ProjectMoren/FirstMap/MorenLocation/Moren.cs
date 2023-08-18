using System.Linq;
using Newtonsoft.Json;

namespace ProjectMoren;

public class Moren : Shed
{
    public bool possibilityBasement = true;
    public bool possibilityBasementZero = true;
    public bool possibilityBasementTwo = true;
    public bool possibilityBasementGoose = true;

    public bool TitalinFightDone = true;
    public bool possibilityBasementSafeOption = true;

    public Moren()
    {

    }

    [JsonConstructor]
    public Moren(List<string> _shedItemsCopy, bool possibilityBasement, bool possibilityBasementZero, bool possibilityBasementTwo, bool possibilityBasementGoose, bool TitalinFightDone, bool possibilityBasementSafeOption, bool possibilityOneCopy, bool possibilityZeroCopy, Dictionary<int, string> toolsBoxCopy, bool MARKSEnterPossibilityCopy,  bool DeathAgreementCopy, bool NoAgreementToDeathPossibilityCopy, bool FirstTime, Dictionary<int, string> shop)
    {
        // Shop 
        base.FirstTime = FirstTime;
        base.shop = new Dictionary<int, string>();
        base.shop = shop;

        // MARKS
        MARKSEnterPossibility = MARKSEnterPossibilityCopy;
        DeathAgreement = DeathAgreementCopy;
        NoAgreementToDeathPossibility = NoAgreementToDeathPossibilityCopy;

        // MorenChiefHome
        possibilityOne = possibilityOneCopy;
        possibilityZero = possibilityZeroCopy;
        toolsBox = toolsBoxCopy;

        // Moren & Shed
        _shedItems = new List<string>();
        _shedItems = _shedItemsCopy;
        this.possibilityBasement = possibilityBasement;
        this.possibilityBasementZero = possibilityBasementZero;
        this.possibilityBasementTwo = possibilityBasementTwo;
        this.possibilityBasementGoose = possibilityBasementGoose;
        this.TitalinFightDone = TitalinFightDone;
        this.possibilityBasementSafeOption = possibilityBasementSafeOption;
    }

    public void FiflinsShed(Player player, Quest quest, QuestServices questServices, LemparsMutlaService lemparsMutlaService)
    {
        // var miotla = _shedItems.FindIndex(x => x == "miotla");
        // var swinka = _shedItems.FindIndex(x => x == "swinka maskotka");
        // var siekiera= _shedItems.FindIndex(x => x == "zardzewiala siekiera");

        string? agreement;
        int pick;
        string? enter;
        int enterInt;

        if(questServices.GetQuestByName("Udaj sie do szopy {Home}") != null)
        {
            questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie do szopy {Home}").Id);
        }

        Console.WriteLine();

        Console.WriteLine(@"&&&@&@@@@@%#%%&###%###&&&&&%%%%&&@&%&&%%%%%&@&&%%#&%&&@#@&&%&%&&@%&#%%&%%%&@@@&%&@@@@&@&%%&@%&@%&&@@
%%@&@@@@@@@&&%&%%###%%%%@@&&&##&%%%&@@@@&%%&%&@@@&@@@&&%%%%%&%&&&@&&&%&@&%%%&%&&#%&&@&%%@&%&&@@@@@&@
@@@&@@@@@%%%&&%&%#%#%%#%%%%%%&&%%#%%&@&%&%%&@%@%&@@&&&&%&%%&%&&%&@@@&@@&%%&@&@%@&&%&&%%%&@&@@@&&&%@@
@@@@@@&%%@@#&%&@&&&%%%%&%%%&%&%#(#%#%&&#%&%&@%@@&&%&%##%#%@&&&%%&&&#&&@&@&@@&&&%@@%&@@%%@&%&%&&%@@@%
@@@@@@@@&&&%&@@@&(##*(#,/*,,.,,/%&%&&%%%%%(#%&&%@&%#%&&&#%@%@@&&%%%%%#@@@@&&&%&&%%@@&&@%&%(%&&&@#%&&
@@@@@%%@@@@%%%###@@@&%&@@@@*#/,/***,,,,,,*./,**(%&#&%#%@&&&@&&&&&%&%#&@@@@&&&%%%@%#@&#%&(/(//#/((/((
&@@&@@((%#(/&@&&%&%%%#%%#%&&&&@&@/((**(*,,,...,,,*,,*,/#%%%&%&%%%#%%%%&&&@@%&%%%@&#(##/@@/(/(/#(#((/
%&%*/#(#@@%##%(((%#(//**/(%#%###%&&&&&&(**%%%&,*,**,,*********@&%/*((#@&&@@@%(/(&@((/((@@(*((//*//(/
&&%@@@@@%///((///#,/(*,,//#(/##(###/##&@&@@@@@@@&(((%%&&&%***/*,****#(@@@@@@#(#(#@@((((@@(((#(((((((
(####(#((*/(*(((*#./#,,.*/%(#(#/#/(##(##*,(**(%%&%&&@@@@@@@@@@@@@(((##@@@@@&%((((#@#(((@@&(/%*((///(
#/###/((,**,,(//*( ,#...**(((*(//((/((*(**(,,*(#%(/(**/(*/#((/#(#&%/((@@@@@@&%((#(@@#(%@@&#(#/(/%(//
/(###(#/,,,,.*/*,#.,/,.,**((*/*/*/(/(,/(/,/.,.(##//(,,**/,#**,/,*%##%@@@@@@@&&%%&#@@@&@&@@@&%#@&&%%@
/(#(%%##*,,,./(,(#*,/../*,*//,*#*/(/*/,/..***,*#%#/*.***,.*,,***/&@@@@@@@@@@@@@@@&@@&@&@@@@&&&&@@@@&
%&&&&&%&*,,,.*(*#(*,/,,(/,(/*,,#,/*/,/,* ./.*,*#&%**./*,,/*,*(*,/(&&&&%%&&&%&&&&%%&%&&&%&%%%%%%%%%%%
&&&%&&&&(,,,,,%*#(/,/,./*.*/*,,(,*//,(/, ., ,,..,.,,,(,/.(,,,(/(/*%%&%&&%%&%%%#%%%%%%%%%%%%%%%%%#%#%
&&&&&&&%#,,,/*#,#(/*(,.**.*//,.*.*/*,(*. ., *,.,  , *(*/,/,*./(/(*%%%###%#%%%#%%##%%%%#####%#%#%%%%%
&%&&&&&%#,,,,*/,*(/*/*.,*.**,,,/.,,,/**....,*/,, ., /.///,,/,/*//*%#%######%%%%###################&#
%%%%%#%%#,*(.*/,*(/*/*,,/.**,,,/ ,*%,*,,... *//, ., ,,**/..(*/****#########%#((((#######(%%%###%%%%#
*//(((##(,*,,*/ */(*(,*./,**,,,/ ,,*,** ,.,.,*,,..* ,,,/, .***/.,,(##########%%%%%%##/#%#####%%#%&##
*,**,**,,,*,**,,,,,*,*,****,,,**,*,,**,,/*/*(((/.*,  *.,,  ,*,,,../(#%%%%##%(%##(##((#(#%#(%#%%#(###
*************/******/***********,*****,***/***/*******,*,,,**/***,,***///((#/**///*/**/****///(////(
***,*****,,*/*******//*******,**********,*,*,,,*,*****,**,,*,,,,***,***,,**********/***,**/****/*/*/");

        Console.WriteLine();
        Console.WriteLine("Moja kochana szopa, musze chyba cos z niej wyniesc...");
        //  Console.WriteLine("Mozliwosci: 0: wez miotle | 1: wez swinke maskotke | 2: wez zardzewiala siekiere | 3: wyjscie przez dziure w oknie");
        DefaultTemplate.DefaultTemplateMethod(3, "wez miotle", "wez swinke maskotke", "wez zardzewiala siekiere", "wyjscie przez dziure w oknie");
        try
        {
            pick = Convert.ToInt32(Console.ReadLine());
            switch (pick)
            {

                case 0:
                    if (!player.Equipment.ContainsValue("Miotla"))
                    {
                        player.Add(player.Equipment.Count, "Miotla");
                        _shedItems.Remove("Miotla");
                        Console.WriteLine("*Pomyslnie dodano przedmiot");
                    }
                    else
                    {
                        Console.WriteLine("Niestety, ale zabrales juz ten przedmiot. Czy chcesz go odlozyc na miejsce?");
                        Console.WriteLine("Jesli chcesz odlozyc: yes | jesli nie chcesz odlozyc: no");
                        do
                        {
                            agreement = Console.ReadLine();
                            if (agreement == "yes")
                            {
                                _shedItems.Add(player.GetEquipmentItemByItem(player.Equipment, "Miotla"));
                                player.Remove(player.GetEquipmentIndexByItem(player.Equipment, "Miotla"));
                                Console.WriteLine("-Pomyslnie odlozono przedmiot");
                                break;
                            }
                            else if (agreement == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Zastanow sie nad swoim losem...");
                            }
                        } while (agreement != "yes" || agreement != "no");
                    }
                    break;
                case 1:
                    if (!player.Equipment.ContainsValue("Swinka_Maskotka"))
                    {
                        player.Add(player.Equipment.Count, "Swinka_Maskotka");
                        _shedItems.Remove("Swinka_Maskotka");
                        Console.WriteLine("*Pomyslnie dodano przedmiot");
                    }
                    else
                    {
                        Console.WriteLine("Niestety, ale zabrales juz ten przedmiot. Czy chcesz go odlozyc na miejsce?");
                        Console.WriteLine("Jesli chcesz odlozyc: yes | jesli nie chcesz odlozyc: no");
                        do
                        {
                            agreement = Console.ReadLine();
                            if (agreement == "yes")
                            {
                                _shedItems.Add(player.GetEquipmentItemByItem(player.Equipment, "Swinka_Maskotka"));
                                player.Remove(player.GetEquipmentIndexByItem(player.Equipment, "Swinka_Maskotka"));
                                Console.WriteLine("-Pomyslnie odlozono przedmiot");
                                break;
                            }
                            else if (agreement == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Zastanow sie nad swoim losem...");
                            }
                        } while (agreement != "yes" || agreement != "no");
                    }
                    break;
                case 2:
                    if (!player.Equipment.ContainsValue("Zardzewiala_Siekiera") && possibilityBasement == true)
                    {
                        player.Add(player.Equipment.Count, "Zardzewiala_Siekiera");
                        _shedItems.Remove("Zardzewiala_Siekiera");
                        Console.WriteLine("*Pomyslnie dodano przedmiot");
                        Console.WriteLine("^Fiflin: Co to za dziwny wlaz ?...");
                        Console.WriteLine("Czy chcesz zejsc pod ziemie ? jesli tak: yes | jesli nie: no/wszystko inne");
                        enter = Console.ReadLine();
                        if (possibilityBasementGoose == false && TitalinFightDone == false)
                        {
                            player.Add(player.Equipment.Count, "Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa");
                            lemparsMutlaService.Add(10);
                            TitalinFightDone = true;
                            Console.WriteLine("*Zdobyles Mutle Lemparu x1");
                            Console.WriteLine("*Zdobyles Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa");
                        }
                        if (enter == "yes" && possibilityBasement == true && possibilityBasementZero == true && possibilityBasementTwo == true)
                        {
                            Console.WriteLine("^Nieznajomy: Spierdalaj Filfinie smierdzielu!");
                            Thread.Sleep(1500);
                            Console.WriteLine("^Fiflin: Co ty robisz w mojej szopie !? ");
                            Thread.Sleep(1500);
                            Console.WriteLine("^Titalin: Spie, bo co? ");
                            Thread.Sleep(1500);
                            Console.WriteLine("Mozliwosci: ");
                            Console.WriteLine();
                            Console.WriteLine("| 0: Zostaw Titalina w spokoju ");
                            Console.WriteLine("| 1: uderz Titalina siekiera i zabierz jego rzeczy");
                            Console.WriteLine("| 2: Zapytaj od kiedy tutaj spi");
                            Console.WriteLine();
                            enterInt = Convert.ToInt32(Console.ReadLine());
                            switch (enterInt)
                            {
                                case 0:
                                    Console.WriteLine("^Fiflin: Spij dalej stary druchu...");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^Titalin: Dobra zamknij ten glupi ryj i spierdalaj bo spie!");
                                    possibilityBasementZero = false;
                                    possibilityBasementSafeOption = false;
                                    break;
                                case 1:
                                    Console.WriteLine("^Fiflin: To moja szopa !!! Dawaj wszystko co masz !!!");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^Titalin: Bierz ten kubrak i spierdalaj!");
                                    Thread.Sleep(1500);
                                    player.Add(player.Equipment.Count, "Stary_Kubrak_Titalina");
                                    player.Remove(player.GetEquipmentIndexByItem(player.Equipment, "Zardzewiala_Siekiera"));
                                    Console.WriteLine("*Zdobyles Stary Kubrak Titalina!");
                                    Console.WriteLine("-Straciles zardzewiala siekiere!");
                                    possibilityBasement = false;
                                    break;
                                case 2:
                                    Console.WriteLine("^Titalin: Chuj wie, od jakiegos miesiaca. ");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^Fiflin: Dlaczego tak dlugo ?");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^Titalin: Nie wiem, spierdalaj. Albo ci powiem, ale jak sie bedziesz smial");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^to ci jaja wykrece i przybije do drzewa");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^Otoz w mojej posiadlosci nieopodal studnii Mitomanolina zamieszkala pewna Ges");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^ktora zwie sie Barnaba i za kazdym razem, gdy probuje zasnac ta grozi mi smiercia");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^i wypomina wszystkie moje bledy mlodosci po czym gdacze jak najeta, jesli juz wysluchales mojej");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^zajebistej retrospekcji to teraz przyswiadcz mi przysluge i pozbedz sie tej kaczki a ja zostawie ci w piwnicy");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("^prezent i obiecuje ze sobie pojde na wieki wiekow amen...");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Przymij to zadanie: yes | Odrzuc to zadanie: no");
                                    Thread.Sleep(1500);

                                    agreement = Console.ReadLine();
                                    if (agreement == "yes")
                                    {
                                        Console.WriteLine("Zgoda!");
                                        questServices.AddQuest("Udaj sie do domu Titalina (TitalinHome), aby rozliczyc sie z ta przekleta Gesia");
                                        possibilityBasementGoose = false;
                                        possibilityBasementTwo = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("^Fiflin: Chyba sobie odpuszcze");
                                        Thread.Sleep(1500);
                                        Console.WriteLine("^Titalin: No spierdalaj mondziole");
                                        possibilityBasementTwo = false;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (possibilityBasementSafeOption == false)
                            {
                                Console.WriteLine("^Titalin: Spiedalaj, bo spie Mondziole !");
                            }
                            Console.WriteLine("^Fiflin: Smierdzi gownem w tej piwnicy...");
                        }
                    }
                    else
                    {
                        if (possibilityBasement == true)
                        {
                            Console.WriteLine("Niestety, ale zabrales juz ten przedmiot. Czy chcesz go odlozyc na miejsce?");
                            Console.WriteLine("Jesli chcesz odlozyc: yes | jesli nie chcesz odlozyc: no");
                            do
                            {
                                agreement = Console.ReadLine();
                                if (agreement == "yes")
                                {
                                    _shedItems.Add(player.GetEquipmentItemByItem(player.Equipment, "Zardzewiala_Siekiera"));
                                    player.Remove(player.GetEquipmentIndexByItem(player.Equipment, "Zardzewiala_Siekiera"));
                                    Console.WriteLine("-Pomyslnie odlozno przedmiot");
                                    break;
                                }
                                else if (agreement == "no")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Zastanow sie nad swoim losem...");
                                }
                            } while (agreement != "yes" || agreement != "no");
                            Console.WriteLine("Czy chcesz zejsc pod ziemie ? jesli tak: yes | jesli nie: no/wszystko inne");
                            enter = Console.ReadLine();
                            if (TitalinFightDone == false && possibilityBasementGoose == true && enter == "yes")
                            {
                                player.Add(player.Equipment.Count, "Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa");
                                lemparsMutlaService.Add(10);
                                TitalinFightDone = true;
                                Console.WriteLine("*Zdobykes Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa");
                                Console.WriteLine("*Zdobyles Mutle Lemparu x1");
                            }
                            if (enter == "yes" && possibilityBasementSafeOption == false)
                            {
                                Console.WriteLine("^Titalin: Spiedalaj, bo spie Mondziole!");
                                Console.WriteLine("Smierdzi gownem w tej piwnicy");
                            }
                            else
                            {
                                if(possibilityBasement == true && possibilityBasementZero == true && possibilityBasementTwo == true && possibilityBasementGoose == true && possibilityBasementSafeOption == true && TitalinFightDone == true)
                                {
                                    if (enter == "yes" && possibilityBasement == true && possibilityBasementZero == true && possibilityBasementTwo == true)
                                    {
                                        Console.WriteLine("^Nieznajomy: Spierdalaj Filfinie smierdzielu!");
                                        Thread.Sleep(1500);
                                        Console.WriteLine("^Fiflin: Co ty robisz w mojej szopie !? ");
                                        Thread.Sleep(1500);
                                        Console.WriteLine("^Titalin: Spie, bo co? ");
                                        Thread.Sleep(1500);
                                        Console.WriteLine("Mozliwosci: ");
                                        Console.WriteLine();
                                        Console.WriteLine("| 0: Zostaw Titalina w spokoju ");
                                        Console.WriteLine("| 1: uderz Titalina siekiera i zabierz jego rzeczy");
                                        Console.WriteLine("| 2: Zapytaj od kiedy tutaj spi");
                                        Console.WriteLine();
                                        enterInt = Convert.ToInt32(Console.ReadLine());
                                        switch (enterInt)
                                        {
                                            case 0:
                                                Console.WriteLine("^Fiflin: Spij dalej stary druchu...");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^Titalin: Dobra zamknij ten glupi ryj i spierdalaj bo spie!");
                                                possibilityBasementZero = false;
                                                possibilityBasementSafeOption = false;
                                                break;
                                            case 1:
                                                Console.WriteLine("^Fiflin: To moja szopa !!! Dawaj wszystko co masz !!!");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^Titalin: Bierz ten kubrak i spierdalaj!");
                                                Thread.Sleep(1500);
                                                player.Add(player.Equipment.Count, "Stary_Kubrak_Titalina");
                                                player.Remove(player.GetEquipmentIndexByItem(player.Equipment, "Zardzewiala_Siekiera"));
                                                Console.WriteLine("*Zdobyles Stary Kubrak Titalina!");
                                                Console.WriteLine("-Straciles zardzewiala siekiere!");
                                                possibilityBasement = false;
                                                break;
                                            case 2:
                                                Console.WriteLine("^Titalin: Chuj wie, od jakiegos miesiaca. ");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^Fiflin: Dlaczego tak dlugo ?");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^Titalin: Nie wiem, spierdalaj. Albo ci powiem, ale jak sie bedziesz smial");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^to ci jaja wykrece i przybije do drzewa");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^Otoz w mojej posiadlosci nieopodal studnii Mitomanolina zamieszkala pewna Ges");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^ktora zwie sie Barnaba i za kazdym razem, gdy probuje zasnac ta grozi mi smiercia");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^i wypomina wszystkie moje bledy mlodosci po czym gdacze jak najeta, jesli juz wysluchales mojej");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^zajebistej retrospekcji to teraz przyswiadcz mi przysluge i pozbedz sie tej kaczki a ja zostawie ci w piwnicy");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("^prezent i obiecuje ze sobie pojde na wieki wiekow amen...");
                                                Thread.Sleep(1500);
                                                Console.WriteLine("Przymij to zadanie: yes | Odrzuc to zadanie: no");
                                                Thread.Sleep(1500);

                                                agreement = Console.ReadLine();
                                                if (agreement == "yes")
                                                {
                                                    Console.WriteLine("Zgoda!");
                                                    questServices.AddQuest("Udaj sie do domu Titalina (TitalinHome), aby rozliczyc sie z ta przekleta Gesia");
                                                    possibilityBasementGoose = false;
                                                    possibilityBasementTwo = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("^Fiflin: Chyba sobie odpuszcze");
                                                    Thread.Sleep(1500);
                                                    Console.WriteLine("^Titalin: No spierdalaj mondziole");
                                                    possibilityBasementTwo = false;
                                                }
                                                break;
                                        }
                                    }
                                }
                                Console.WriteLine("Smierdzi gownem w tej piwnicy");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niestety, ale rozjebales sikiere w trakcie odstraszania");
                        }
                    }
                    break;
                case 3: break;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Podaj wartosc liczbowa...");
        }
        player.AdjustDictionaryIndexes(player.Equipment);

    }
    public void TitalinHouse(Player player, PlayerEquipmentStatistics playerStats, IEnemy ges, QuestServices questServices)
    {
        string? agreement;
        bool IntAgreement;
        if (possibilityBasementGoose == false)
        {
            Console.WriteLine("^Ges: Myslisz, ze nie wiem po co tutaj jestes Fiflinie?");
            Thread.Sleep(1500);
            Console.WriteLine("^Fiflin: Przestan dokuczac mojemu przyjacielowi Titalinowi!");
            Thread.Sleep(1500);
            Console.WriteLine("^Ges: Kwa Kwa, znaczy sie jak to dokuczac ? Przeciez jestem jego ukochana Matka!");
            Thread.Sleep(1500);
            Console.WriteLine("^Fiflin: Nie prawda jestes zwykla Gesia, ktora dokucza mojemu przyjacielowi i nie daje mu spac po noacach!");
            Thread.Sleep(1500);
            Console.WriteLine("^Matka Titalina: Ha Ha Ha on naprawde w to uwierzyl. Ja jestem tutaj tylko i wylacznie dlatego, ze moj byly maz \n spalil dom po pijaku i teraz szukam nowego miejsca do zamieszkania, a jako ze moj syn \n posiada calkiem ladny drewniany domek z piecykiem to postanowilam sie go pozbyc by miec caly dom dla siebie");
            Thread.Sleep(1500);
            Console.WriteLine("^Fiflin: To niemozliwe, jestes zwykla Gesia i probujesz mnie oszukac, nie jestem tak glupi nie wierze ci !!!");
            Thread.Sleep(1500);
            Console.WriteLine("^Matka Titalina: Dobra skoncz te blazenday i spadaj stad");
            //   Console.WriteLine("Co teraz zrobisz ? \n \n | 0: Zacznij walczyc z ta glupia Gesia Barnaba: yes \n | 1: Rozwiazanie dyplomatyczne: more > Wymagania: Charisma=10 | Money=50 \n");
            DefaultTemplate.DefaultTemplateMethod(1, "Zacznij walczyc z ta glupia Gesia Barnaba! ", "Rozwiazanie dyplomatyczne Wymagania: Charisma=10 | Money=50");
            agreement = Console.ReadLine();
            IntAgreement = int.TryParse(agreement, out int result);
            if (result == 0)
            {
                FightingSystem.Fight(player, ges, playerStats);
                TitalinFightDone = false;
                possibilityBasementGoose = true;
                questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie do domu Titalina (TitalinHome), aby rozliczyc sie z ta przekleta Gesia").Id);
            }
            if (result == 1 && player.Charisma == 10 && player.Moreny == 50)
            {
                Console.WriteLine("^Fiflin: Umowmy sie wredna Gesia, ja dam ci 50 Morenow a ty zostawisz mnie i Titalina w spokoju");
                Console.WriteLine("^Matka Titalina: W sumie to wystarczajaca kwota, azeby isc do baru i znalezc nowego amanta z ktorym moglabym zamieszkac w lepszych warunkach");
                Console.WriteLine("^Fiflin: Czyli umowa stoi ?");
                Console.WriteLine("^Matka Titalina: stoi");
                player.Moreny -= player.Moreny - 50;
                TitalinFightDone = false;
                possibilityBasementGoose = true;
                questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie do domu Titalina (TitalinHome), aby rozliczyc sie z ta przekleta Gesia").Id);
            }
            else
            {
                if (TitalinFightDone == false)
                {
                    return;
                }
                Console.WriteLine("Niestety, ale czegos ci brakuje :)...");
                FightingSystem.Fight(player, ges, playerStats);
                TitalinFightDone = false;
                possibilityBasementGoose = true;
                questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie do domu Titalina (TitalinHome), aby rozliczyc sie z ta przekleta Gesia").Id);
            }
        }
        else
        {
            Console.WriteLine("Ta smierdzaca buda jest zmaknieta...");
        }
        player.AdjustDictionaryIndexes(player.Equipment);
    }
}