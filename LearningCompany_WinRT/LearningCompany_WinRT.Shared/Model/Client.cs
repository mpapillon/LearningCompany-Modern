using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Client
    {

        private string adresseField;

        private byte clientIDField;

        private ushort codePostalField;

        private string courrielField;

        private string motDePasseField;

        private string raisonSocialeField;

        private string referenceField;

        private uint telephoneField;

        private string urlSiteField;

        private string villeField;

        /// <remarks/>
        public string Adresse
        {
            get
            {
                return this.adresseField;
            }
            set
            {
                this.adresseField = value;
            }
        }

        /// <remarks/>
        public byte ClientID
        {
            get
            {
                return this.clientIDField;
            }
            set
            {
                this.clientIDField = value;
            }
        }

        /// <remarks/>
        public ushort CodePostal
        {
            get
            {
                return this.codePostalField;
            }
            set
            {
                this.codePostalField = value;
            }
        }

        /// <remarks/>
        public string Courriel
        {
            get
            {
                return this.courrielField;
            }
            set
            {
                this.courrielField = value;
            }
        }

        /// <remarks/>
        public string MotDePasse
        {
            get
            {
                return this.motDePasseField;
            }
            set
            {
                this.motDePasseField = value;
            }
        }

        /// <remarks/>
        public string RaisonSociale
        {
            get
            {
                return this.raisonSocialeField;
            }
            set
            {
                this.raisonSocialeField = value;
            }
        }

        /// <remarks/>
        public string Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        public uint Telephone
        {
            get
            {
                return this.telephoneField;
            }
            set
            {
                this.telephoneField = value;
            }
        }

        /// <remarks/>
        public string UrlSite
        {
            get
            {
                return this.urlSiteField;
            }
            set
            {
                this.urlSiteField = value;
            }
        }

        /// <remarks/>
        public string Ville
        {
            get
            {
                return this.villeField;
            }
            set
            {
                this.villeField = value;
            }
        }
    }


}
