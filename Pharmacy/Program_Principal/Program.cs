using System;
using System.Collections.Generic;

namespace Proiect_Piu_Simionescu_Gavril_Andrei__MEDICAMENT
{
    /// INCA NU ESTE GATA PROGRAMUL 
    
    class Program
    {
        static void Main(string[] args)
        {
            /**Medicament a = new Medicament("aspenter orala 230 24.07.2021");
            Console.WriteLine(a.ConversieLaSir());
            Medicament b = new Medicament("LIV52 orala 210 24.07.2021");
            **/

            string operatie;
            int op;
            bool operatievalida;
            ///lista de medicamente
            List < Medicament > Catena= new List<Medicament>();

            ///variabile pentru adaugare medicament

            string numemed;
            string tipadministrare;
            float pretmedicament;
            bool validarepret;
            string editnume;
            DateTime data;
            DateTime data_utilizare_program=DateTime.Today;
            bool validare_data_medicament;

            DateTime datasiorapentruafisareecran = DateTime.Now;

            Console.Write(datasiorapentruafisareecran);
            do
            {
                Console.WriteLine("\n\n\n\t\t\t\t\tGestiunea unei farmacii.");
                Console.WriteLine("\n\n\n1.Adaugare medicament.");
                Console.WriteLine("2.Editare medicament.");
                Console.WriteLine("3.Stergere medicament.");
                Console.WriteLine("4.Afisare lista medicamente.");
                Console.WriteLine("5.Cautare medicament");
                Console.WriteLine("6.Iesire.");
                Console.WriteLine("7.Comparare medicamente dupa pret.");
                Console.Write("\nAlegeti o optiune: ");
                operatie = Console.ReadLine();
                operatievalida = int.TryParse(operatie, out op);
                
                switch(op)
                {
                    case 1:
                        Console.WriteLine("\n---------------Introdu datele despre medicament---------------\n");
                        Console.Write("Nume medicament: ");
                        numemed = Console.ReadLine();
                        Console.Write("Tip de administrare: ");
                        tipadministrare = Console.ReadLine();
                        do
                        {
                            Console.Write("Pret medicament: ");
                            validarepret = float.TryParse(Console.ReadLine(), out pretmedicament);
                            if(!validarepret)
                            {
                                Console.WriteLine("\nATENTIE !!!!! PRETUL NU ESTE VALID");
                                Console.WriteLine("Introduceti o valoare numerica pentru pretul medicamentului.\n\n");
                            }
                        } while (!validarepret);
                        do
                        {
                            Console.Write("Data expirarii medicamentului introdus in format zi/luna/an (ex format:  " + data_utilizare_program.ToString("d") + "): ");
                            validare_data_medicament = DateTime.TryParse(Console.ReadLine(), out data);
                            if (!validare_data_medicament)
                            {
                                Console.WriteLine("\nATENTIE !!!!! FORMATUL INTRODUS  NU ESTE VALID sau luna ziua si anul nu exista in calendar");
                                Console.WriteLine("Introduceti un format corect.\n\n");
                            }
                        } while(!validare_data_medicament);

                        Catena.Add(new Medicament(numemed, tipadministrare, pretmedicament, data));
                        Console.WriteLine("Medicamentul a fost adaugat.");
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("\n---------------Trebuie sa introduceti numele medicamentului pe care doriti sa il editati---------");
                        Console.Write("\nIntrodu un nume:  ");
                        editnume = Console.ReadLine();
                        bool ok = false;
                        int operatie_editare;
                        bool validare_operatieeditare;

                        foreach(var m in Catena)
                        {
                            if(editnume.Equals(m.ReturnareNumeMedicament))
                            {
                                Console.Clear();
                                Console.WriteLine("\nMedicamentul cautat a fost gasit.");
                                Console.WriteLine("\n------------------------------Date despre acest medicament------------------------------");
                                Console.WriteLine("\n{0}", m.ConversieLaSir());
                                ok = true;
                                do
                                {
                                    Console.WriteLine("\n\n---------------Alegeti o optiune pe care doriti sa o editati la acest medicament---------------");
                                    Console.WriteLine("\n1.Nume medicament.");
                                    Console.WriteLine("2.Tip administrare medicament.");
                                    Console.WriteLine("3.Pret medicament.");
                                    Console.WriteLine("4.Data expirare medicament.");
                                    Console.Write("Introduceti optiunea:  ");
                                    validare_operatieeditare = int.TryParse(Console.ReadLine(), out operatie_editare);
                                    if(!validare_operatieeditare)
                                    {
                                        Console.WriteLine("ATENTIE !!! Operatia introdusa nu este valida.\nIntroduceti o operatie valida");
                                    }
                                } while (!validare_operatieeditare);
                                Console.Write("\nIntroduceti modificarea: ");
                                if(operatie_editare==1)
                                {
                                    string num;
                                    num = Console.ReadLine();
                                    m.EditareNume(num);
                                    Console.WriteLine("\nMedicamentul a fost actualizat.");
                                    Console.WriteLine("\nPress any key to continue.....");
                                    Console.ReadKey();
                                    Console.Clear();

                                }
                                if(operatie_editare==2)
                                {
                                    string tip_administr;
                                    tip_administr = Console.ReadLine();
                                    m.EditreTipAdministrare(tip_administr);
                                    Console.WriteLine("\nMedicamentul a fost actualizat.");
                                    Console.WriteLine("\nPress any key to continue.....");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                if(operatie_editare==3)
                                {
                                    string pret;
                                    float price;
                                    bool pretvalid;
                                    do
                                    {
                                        pret = Console.ReadLine();
                                        pretvalid = float.TryParse(pret, out price);
                                        if(!pretvalid)
                                        {
                                            Console.WriteLine("Cititi o valoare numerica.");
                                        }
                                    } while (!pretvalid);
                                    m.EditarePret(price);
                                    Console.WriteLine("\nMedicamentul a fost actualizat.");
                                    Console.WriteLine("\nPress any key to continue.....");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                if(operatie_editare==4)
                                {
                                    DateTime d;
                                    bool datavalida;
                                    Console.Write("\n\nIntroduceti data in format (" + data_utilizare_program.ToString("d")+") :  ");
                                    datavalida = DateTime.TryParse(Console.ReadLine(),out d);
                                    m.EditareDataExpirare(d);
                                    Console.WriteLine("\n\t\t\tMedicamentul a fost actualizat.");
                                    Console.WriteLine("\nPress any key to continue.....");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }
                        }
                        if (ok == false)
                        {
                            Console.WriteLine("\nMedicamentul cautat nu a fost gasit.");
                            Console.WriteLine("\nPress any key to continue.....");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case 3:
                        string n;
                        bool win=false;
                        Console.Write("\nIntroduceti numele medicamentului pe care doriti sa il stergeti: ");
                        n = Console.ReadLine();
                        foreach(var ob in Catena)
                        {
                            if(n.Equals(ob.ReturnareNumeMedicament))
                            {
                                win = true;
                                Console.WriteLine("\n Medicamentul a fost gasit");
                                Console.WriteLine("\n---------------Date despre medicament---------------");
                                Console.WriteLine("\n\n"+ob.ConversieLaSir());
                                Console.WriteLine("\n\nMedicamentul a fost sters.");
                                Catena.Remove(ob);
                                break;
                            }
                        }
                        if(win==false)
                        {
                            Console.WriteLine("\nMedicamentul nu exista in farmacie.");
                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        if(Catena.Count==0)
                        {
                            Console.WriteLine("\nFarmacia nu dispune de nici un medicament");
                        }
                        else
                        {
                            foreach(var medicam in Catena)
                            {
                                Console.WriteLine("\n"+medicam.ConversieLaSir());
                            }
                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        if(Catena.Count==0)
                        {
                            Console.WriteLine("\n\nNu exista medicamente");
                        }
                        else
                        {
                            string med;
                            bool gasit1 = false;
                            Console.Write("\nIntroduceti numele medicamentului pe care il cautati: ");
                            med=Console.ReadLine();
                            foreach(var m in Catena)
                            {
                                if(m.ReturnareNumeMedicament==med)
                                {
                                    Console.WriteLine("Medicamentul cautat a fost gasit.");
                                    gasit1 = true;
                                }
                                if (gasit1)
                                {
                                    Console.WriteLine("\n----------------------------Date despre medicamentul cautat----------------------");
                                    Console.WriteLine("\n"+m.ConversieLaSir());
                                    break;
                                }
                            }
                            if(!gasit1)
                            {
                                Console.WriteLine("\nMedicamentul cautat nu a fost gasit");
                            }
                            
                        }
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("\nPress any key to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        ///Console.WriteLine(a.Compare(a,b));
                        break;
                        
                }
               
            }while (op != 6) ;
        }
    }
}
