﻿using System.Collections.Generic;

namespace Сема
{
    class Lines
    {
        public string Name;
        public List<Equimpent> equimpents = new List<Equimpent>();

        public Lines(string name)
        {
            Name = name;
        }

        public void EquimpentAdd(Equimpent equimp)
        {
            equimpents.Add(equimp);
        }

        public void EquimpentDelete(int number)
        {
            equimpents.RemoveAt(number);
        }

        public void Update(string data)
        {
            Name = data;
        }

        public int Count()
        {
            return equimpents.Count;
        }

        public override string ToString()
        {
            string res = "";
            res = $"Линия {Name}:\nНа данный момент количество оборудования равно {equimpents.Count}.\n";
            if (equimpents.Count != 0)
            {
                for (int i = 0; i < equimpents.Count; i++)
                {
                    res += $"{i}) {equimpents[i].Number}\n";
                }
            }
            return res;
        }
    }
}
