using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uml_workshop_2
{
    class View
    {
        private string förnamn;
        private string efternamn;
        private string noBoats;
        private string socialNumber;
        private string boatType;
        private string boatLength;
  

        
        private int id;
        RepositoryMember rep = new RepositoryMember();


        public void introText()
        {
            Console.WriteLine("Meny");
            Console.WriteLine("ID\tFörnamn\tEfternamn Antal båtar");

            rep.viewUser();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1-viewall\n2-add\n3-remove\n4-update\n5-viewspecific");
            Console.WriteLine("---------------------------------------"); 
        }
        public void viewText()
        {

          
         int menyval = 0;
           while (true)
           { 
            Console.Write("Välj alternativ: ");
               try
               {
                   menyval = int.Parse(Console.ReadLine());
               }

               catch
               {
                   Console.BackgroundColor = ConsoleColor.Red;
                   Console.ForegroundColor = ConsoleColor.White;
                   Console.WriteLine("Måste vara ett TAL mellan 0-5");
                   Console.ResetColor();
                   Console.WriteLine("Försök igen");
               }

               
            if (menyval < 6)
            {
                switch (menyval)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        introText();
                        Console.WriteLine("view");
                        Console.WriteLine("ID\tFörnamn\tEfternamn Personnummer\tAntal båtar\tBåttyp\tBåtlängd");
                        rep.viewAllUserInfo();
                        break;
                    case 2:
                        Console.WriteLine("add");
                        userText();
                        rep.addUser(Förnamn, Efternamn,SocialNumber, NoBoats,BoatType,BoatLength );
                        break;
                    case 3:
                        Console.WriteLine("remove");
                        selectIdToDelete();
                        rep.removeUser(Id);
                        break;
                    case 4:
                        Console.WriteLine("update");
                        selectIdToUpdate();
                        userText();
                        rep.updateUser(Förnamn, Efternamn,SocialNumber, NoBoats,BoatType,BoatLength, Id);
                        break;
                    case 5:
                        Console.WriteLine("specific");
                        specificId();
                        Console.WriteLine("ID\tFörnamn\tEfternamn Personnummer\tAntal båtar\tBåttyp        Båtlängd");
                        rep.specificUser(Id);
                        break;
                    default: 
                        break;
                }
             }
            Console.WriteLine("---------------------------------------");
           }
        }
        private void specificId()
        {
            Console.Write("Välj id att inspektera: ");
            id = int.Parse(Console.ReadLine());
        }
        private void selectIdToUpdate()
        {
            Console.Write("Välj id att uppdatera: ");
            id = int.Parse(Console.ReadLine());
        }

        private void selectIdToDelete()
        {
            Console.WriteLine("Välj id att ta bort");
            id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Du har tagit bort id: "+ Id);
        }
        private void userText()
        {
            Console.Write("Mata in förnamn: ");
            förnamn = Console.ReadLine();
            Console.Write("Mata in efternamn: ");
            efternamn = Console.ReadLine();
            Console.Write("Mata in personnummer: ");
            socialNumber = Console.ReadLine();
            Console.Write("Mata in antalet båtar: ");
            noBoats = Console.ReadLine();
            Console.Write("Mata in båttyp: ");
            boatType = Console.ReadLine();
            Console.Write("Mata in båtlängd: ");
            boatLength = Console.ReadLine();
        }

        //Get set go
        public string Förnamn
        {
            get
            {
                return förnamn;
            }
            set
            {
                förnamn = value;
            }
        }
     
        public string Efternamn
        {
            get
            {
                return efternamn;
            }
            set
            {
                efternamn = value;
            }
        }
        public string SocialNumber
        {
            get { return socialNumber; }
            set { socialNumber = value; }
        }
        public string BoatType
        {
            get { return boatType; }
            set { boatType = value; }
        }
        public string NoBoats
        {
            get
            {
                return noBoats;
            }
            set
            {
                noBoats = value;
            }
        }
        public string BoatLength
        {
            get { return boatLength; }
            set { boatLength = value; }
        }
        public int Id
        {
            get{
                return id;
            }
            set{
                id = value;
            }
        }
   }
 }
