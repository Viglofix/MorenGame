namespace GameObjects.BasicGameMechanisms;
    public class MenuService
    {
        private readonly IEnumerable<Menu> _menus;
        public MenuService(IEnumerable<Menu> menus){
            _menus = menus;
        }

        public IEnumerable<Menu> GetMenus() => _menus;

        public Menu? GetMenuById(int id)
        {
            foreach(var item in _menus)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public static List<Menu> CreateMenus()
        {
            return new List<Menu>()
            {
                new Menu() {Id = 1, Name = "Start New Game"},
                new Menu() {Id = 2, Name = "Load Game"},
                new Menu() {Id = 3, Name = "About Lore"}
            };
        }
        public static void ShowMenus(IEnumerable<Menu> menus)
        {
            string? MenuLogo = "Witamy w Grze"; 
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (MenuLogo.Length /2)) + "}", MenuLogo));
            foreach (var menu in menus)
            {
                var menuTo = menu.ToString();
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (menuTo.Length / 2)) + "}", menuTo));
            }
        }
    }
