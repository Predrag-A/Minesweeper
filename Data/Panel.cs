using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum Type
    {
        Empty,
        Mine,
        Number
    }

    public class Panel
    {
        Type _type;
        int _value;

        public Type Type { get => _type; set => _type = value; }
        public int Value { get => _value; set => _value = value; }

        public Panel()
        {
            Type = Type.Empty;
        }

        public Panel(Type type)
        {
            Type = Type;
        }
    }
}
