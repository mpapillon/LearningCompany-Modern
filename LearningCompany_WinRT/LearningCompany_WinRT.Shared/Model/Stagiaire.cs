using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Stagiaire
    {

        private Civilite civiliteField;

        private byte clientIDField;

        private string courrielField;

        private string nomField;

        private string prenomField;

        private byte stagiaireIDField;

        /// <remarks/>
        public Civilite Civilite
        {
            get
            {
                return this.civiliteField;
            }
            set
            {
                this.civiliteField = value;
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
        public string Nom
        {
            get
            {
                return this.nomField;
            }
            set
            {
                this.nomField = value;
            }
        }

        /// <remarks/>
        public string Prenom
        {
            get
            {
                return this.prenomField;
            }
            set
            {
                this.prenomField = value;
            }
        }

        /// <remarks/>
        public byte StagiaireID
        {
            get
            {
                return this.stagiaireIDField;
            }
            set
            {
                this.stagiaireIDField = value;
            }
        }
    }
}
