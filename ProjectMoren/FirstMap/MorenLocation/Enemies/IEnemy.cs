﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies
{
    public interface IEnemy
    {
        public int health { get; set; }
        public int damage { get; set; }
    }
}
