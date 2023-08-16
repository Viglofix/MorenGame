using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
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
}
