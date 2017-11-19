using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    [Serializable]
    public class Panel
    {

        #region Attributes

        Type _type;
        int _value;
        bool _revealed;
        bool _flagged;

        #endregion

        #region Properties

        [XmlElementAttribute("Panel Type")]
        public Type Type { get => _type; set => _type = value; }

        [XmlElementAttribute("Neighboring Mine Count")]
        public int Value { get => _value; set => _value = value; }

        [XmlElementAttribute("Revealed Status")]
        public bool Revealed { get => _revealed; set => _revealed = value; }

        [XmlElementAttribute("Flagged Status")]
        public bool Flagged { get => _flagged; set => _flagged = value; }

        #endregion

        #region Constructors

        public Panel()
        {
            _type = Type.Empty;
            _value = 0;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type)
        {
            _type = type;
            _value = 0;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type, int value)
        {
            _type = type;
            _value = value;
            _revealed = false;
            _flagged = false;
        }

        public Panel(Type type, int value, bool revealed, bool flagged)
        {
            _type = type;
            _value = value;
            _revealed = revealed;
            _flagged = flagged;
        }

        #endregion
        
    }
}
