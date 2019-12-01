using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сема
{
    class Equimpent
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string Specification { get; set; }
        string[] Words = new string[4];

        public Equimpent(string name, string number, string status, string specification)
        {
            Name = name;
            Number = number;
            Status = status;
            Specification = specification;
        }

        public void Update(string data)
        {
            Words = data.Split(new char[] { '|' });
            if (Words[0] != "-")
            {
                Name = Words[0];
            }
            if (Words[1] != "-")
            {
                Number = Words[1];
            }
            if (Words[2] != "-")
            {
                Status = Words[2];
            }
            if (Words[3] != "-")
            {
                Specification = Words[3];
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
