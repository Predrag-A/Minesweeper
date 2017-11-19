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

        [XmlElementAttribute("Type")]
        public Type Type { get => _type; set => _type = value; }
        [XmlElementAttribute("Value")]
        public int Value { get => _value; set => _value = value; }
        [XmlElementAttribute("Revealed")]
        public bool Revealed { get => _revealed; set => _revealed = value; }
        [XmlElementAttribute("Flagged")]
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

        #region Methods

        public void Save(XmlTextWriter wr)
        {
            XmlSerializer sr = new XmlSerializer(typeof(Panel));
            sr.Serialize(wr, this);
            
            
        }

        #endregion

    }
}
