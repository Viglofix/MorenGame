namespace ProjectMoren.FirstMap.MorenLocation
{
    public class AllMorenLocations
    {
        public bool playerPositionFlag { get; set; } = true;

        public void PlayerMoveSystem(Player player, Graph graphMoren)
        {
            ConsoleKeyInfo keyinfo;
            ConsoleKeyInfo keyinfoTemp;
            string? PlayerPositionMoren = "O";
            string? PlayerPositionTitalin = "O";
            string? PlayerPositionShed = "O";
            string? PlayerPositionShop = "O";
            string? PlayerPositionChiefHome = "O";
            string? PlayerPositionMARKS = "O";
            do
            {
                // Flag reset to prevent multiple statment execution
                playerPositionFlag = true;

                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(0)))
                {
                    PlayerPositionMoren = "X";
                }
                else if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(1)))
                {
                    PlayerPositionTitalin = "X";
                }
                else if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(2)))
                {
                    PlayerPositionShed = "X";
                }
                else if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(3)))
                {
                    PlayerPositionShop = "X";
                }
                else if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(4)))
                {
                    PlayerPositionChiefHome = "X";
                }
                else
                {
                    PlayerPositionMARKS = "X";
                }

                // Tutaj będzie pozycja gracza jako zmienna przekazana np jak tak

                Console.WriteLine($"(Moren: {PlayerPositionMoren})-------(Titalin: {PlayerPositionTitalin})");
                Console.WriteLine("|                           |");
                Console.WriteLine("|                           |");
                Console.WriteLine("|                           |");
                Console.WriteLine($"Szopa: ({PlayerPositionShed}-------(MorenArmorShop: {PlayerPositionShop}))");
                Console.WriteLine("|                           |");
                Console.WriteLine("|                           |");
                Console.WriteLine("|                           |");
                Console.WriteLine($"ChiefHome({PlayerPositionChiefHome}-------(MARKS: {PlayerPositionMARKS}))");

                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(0)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.DownArrow)
                    {
                        PlayerPositionMoren = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(2);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.RightArrow)
                    {
                        PlayerPositionMoren = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(1);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }

                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(1)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.LeftArrow)
                    {
                        PlayerPositionTitalin = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(0);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.DownArrow)
                    {
                        PlayerPositionTitalin = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(3);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }
                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(2)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.UpArrow)
                    {
                        PlayerPositionShed = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(0);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.RightArrow)
                    {
                        PlayerPositionShed = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(3);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.DownArrow)
                    {
                        PlayerPositionShed = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(4);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }
                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(3)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.LeftArrow)
                    {
                        PlayerPositionShop = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(2);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.DownArrow)
                    {
                        PlayerPositionShop = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(5);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.UpArrow)
                    {
                        PlayerPositionShop = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(1);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }
                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(4)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.UpArrow)
                    {
                        PlayerPositionChiefHome = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(2);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.RightArrow)
                    {
                        PlayerPositionChiefHome = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(5);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }
                if (player.PlayerPositionMoren.SequenceEqual(graphMoren.getVertexIndex(5)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.UpArrow)
                    {
                        PlayerPositionMARKS = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(3);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.LeftArrow)
                    {
                        PlayerPositionMARKS = "O";
                        player.PlayerPositionMoren = graphMoren.getVertexIndex(4);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }

                Console.WriteLine("Jesli chcesz wyjsc to kliknij X | Jesli Nie to wszystko inne");
                keyinfo = Console.ReadKey();

            } while (keyinfo.Key != ConsoleKey.X);
        }

        public void PlayerPositionSystemMoren(Player player, Graph graphMoren)
        {
            for (int i = 0; i < graphMoren.TotalNumber - 1; i++)
            {
                switch (player.PlayerPositionMoren[i])
                {
                    case 0: Console.WriteLine("Mozes udac sie do Moren"); break;
                    case 1: Console.WriteLine("Mozesz udac sie do Titalina"); break;
                    case 2: Console.WriteLine("Mozesz udac sie do Szopy"); break;
                    case 3: Console.WriteLine("Mozesz udac sie do MorenArmorShop"); break;
                    case 4: Console.WriteLine("Mozesz udac sie do DomuWodza"); break;
                    case 5: Console.WriteLine("Mozesz udac sie do MARKS"); break;
                }
            }
        }
    }
}
