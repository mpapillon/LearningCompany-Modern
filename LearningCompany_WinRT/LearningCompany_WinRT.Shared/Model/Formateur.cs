using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Models
{

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Formateur
    {

        private Civilite civiliteField;

        private string courrielField;

        private byte formateurIDField;

        private string infosField;

        private bool intervenantExterieurField;

        private string nomField;

        private string prenomField;

        private string telephoneField;

        private string urlPhotoField;

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
        public byte FormateurID
        {
            get
            {
                return this.formateurIDField;
            }
            set
            {
                this.formateurIDField = value;
            }
        }

        /// <remarks/>
        public string Infos
        {
            get
            {
                return this.infosField;
            }
            set
            {
                this.infosField = value;
            }
        }

        /// <remarks/>
        public bool IntervenantExterieur
        {
            get
            {
                return this.intervenantExterieurField;
            }
            set
            {
                this.intervenantExterieurField = value;
            }
        }

        /// <remarks/>
        public string Nom
        {
            get
            {
                return this.nomField[0].ToString().ToUpper() + this.nomField.Substring(1).ToLower();
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
        public string Telephone
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
        public string UrlPhoto
        {
            get
            {
                return this.urlPhotoField;
            }
            set
            {
                this.urlPhotoField = value;
            }
        }

        public string NomComplet
        {
            get
            {
                return this.Nom + " " + this.Prenom;
            }
        }
    }
}
