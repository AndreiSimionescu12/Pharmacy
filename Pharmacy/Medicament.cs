using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Piu_Simionescu_Gavril_Andrei__MEDICAMENT
{
    class Medicament
    {
        private string NumeMedicament;

        

        public string ReturnareNumeMedicament
        {
            get
            {
                return NumeMedicament;
            }
        }

        public float Pret
        {
            get;
            set;
        }

        public float ReturnarePret
        {
            get
            {
                return Pret;
            }
        }

        public string TipAdministrare
        {
            get;
            set;
        }

        public DateTime DataExpirarii
        {
            get;
            set;
        }
        
        public Medicament()
        {
            this.NumeMedicament = string.Empty;
            this.TipAdministrare = string.Empty;
            this.Pret = 0;
            this.DataExpirarii = DateTime.Today;

        }
        public Medicament(string sirdate)
        {
            char[] delimitatori = {' '};
            string[] datemedicamente = sirdate.Split(delimitatori);
            this.NumeMedicament = datemedicamente[0];
            this.TipAdministrare = datemedicamente[1];
            this.Pret = float.Parse(datemedicamente[2]);
            this.DataExpirarii = Convert.ToDateTime(datemedicamente[3]);

        }

        public string ConversieLaSir()
        {
            return string.Format("Denumire medicament: {0} , tipul administrarii: {1} , pret: {2} , Data expirarii si ora expirarii: {3}" , NumeMedicament, TipAdministrare, Pret, DataExpirarii);
        }

        public string Compare(Medicament a, Medicament b)
        {
            if(a.Pret>b.Pret)
            {
                return $"Medicamentul {a.NumeMedicament} are pretul mai mare decat medicamentul {b.NumeMedicament}";
            }
            else if(a.Pret<b.Pret)
            {
                return $"Medicamentul {b.NumeMedicament} are pretul mai mare decat medicamentul {a.NumeMedicament}";
            }
            else
            {
                return $"Medicamentul {b.NumeMedicament} si medicamentul {a.NumeMedicament} au preturi egale";
            }
        }
        
        public Medicament(string name, string type, float price, DateTime date)
        {
            NumeMedicament = name;
            TipAdministrare = type;
            Pret = price;
            DataExpirarii = Convert.ToDateTime(date);
        }

        public void  EditareNume(string name)
        {
            NumeMedicament = name;
        }

        public void EditreTipAdministrare(string tip)
        {
            TipAdministrare = tip;
        }

        public void EditarePret(float pret)
        {
            this.Pret = pret;
        }

        public void EditareDataExpirare(DateTime data)
        {
            this.DataExpirarii = data;
        }
        
    }
}
