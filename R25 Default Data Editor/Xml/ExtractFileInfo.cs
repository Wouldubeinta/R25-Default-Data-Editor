using System.Xml;
using System.Xml.Serialization;

namespace R25_Default_Data_Editor
{
    [Serializable()]
    public partial class ExtractFileInfo
    {
        #region Fields
        private int index = 0;
        private bool isCompressed = false;
        private Entry[]? entries = null;
        #endregion

        #region Properties
        [XmlAttribute()]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        [XmlAttribute()]
        public bool IsCompressed
        {
            get { return isCompressed; }
            set { isCompressed = value; }
        }

        [XmlArrayItem("Entry", IsNullable = true)]
        public Entry[]? Entries
        {
            get { return entries; }
            set { entries = value; }
        }
        #endregion

        [Serializable()]
        public partial class Entry
        {
            [XmlAttribute()]
            public string? FilePath { get; set; }
        }
    }
}
