using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Civilite
    {

        private byte civiliteIDField;

        private string libelleCourtField;

        private string libelleLongField;

        /// <remarks/>
        public byte CiviliteID
        {
            get
            {
                return this.civiliteIDField;
            }
            set
            {
                this.civiliteIDField = value;
            }
        }

        /// <remarks/>
        public string LibelleCourt
        {
            get
            {
                return this.libelleCourtField;
            }
            set
            {
                this.libelleCourtField = value;
            }
        }

        /// <remarks/>
        public string LibelleLong
        {
            get
            {
                return this.libelleLongField;
            }
            set
            {
                this.libelleLongField = value;
            }
        }
    }
}
