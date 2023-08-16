using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectMoren;

public class Shed : MorenChiefHome
{
    public List<string>? _shedItems { get; set; }

    public Shed()
    {
        InitializeShedItems();
    }
    private void InitializeShedItems()
    {
        _shedItems = new();
        _shedItems.Add("Miotla");
        _shedItems.Add("Swinka_Maskotka");
        _shedItems.Add("Zardzewiala_Siekiera");
    }

    public void ShowShedItems()
    {
        if (_shedItems != null)
        {
            foreach (var item in _shedItems)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            return;
        }
    }
}

