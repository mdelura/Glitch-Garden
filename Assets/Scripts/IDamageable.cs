﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IDamageable
{
    event Action Destroyed;
    void Damage(float damageValue);
}