using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace uml_workshop_2
{
    class RepositoryMember
    {
        private String str = @"server=localhost;database=member;userid=root;password=;";
        private MySqlConnection con;
        private string dbTableMember = "medlem";
        private string dbTableBoats = "boats";
        private MySqlCommand cmdMember;
        //private MySqlCommand cmdBoat;
        public void Connection()
        {
            try
            {
                con = new MySqlConnection(str);
                con.Open();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void viewUser()
        {
          
            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                String cmdText = "SELECT * FROM " + dbTableMember + " JOIN " + dbTableBoats + " ON  boatId = nameId";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetString(0)+"\t");
                    Console.Write(reader.GetString(1) + "\t");
                    Console.Write(reader.GetString(2) + "\t  ");
                    //(4) = idt på båtarna
                    Console.WriteLine(reader.GetString(4) + "\t");
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void specificUser(int Id)
        {

            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                String cmdText = "SELECT  nameId, firstname, lastname,socialNumber,noBoats,boatType,boatLength FROM " + dbTableMember + " JOIN " + dbTableBoats + " ON  boatId = nameId  WHERE nameId = " + Id + "";
                //string stm = @"SELECT Name, Title From Authors,Books WHERE Authors.Id=Books.AuthorId";             
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetString(0) + "\t");
                    Console.Write(reader.GetString(1) + "\t");
                    Console.Write(reader.GetString(2) + "\t  ");
                    //Console.WriteLine(reader.GetString(3) + "\t"); == Idt i boats
                    Console.Write(reader.GetString(3) + "\t");
                    Console.Write(reader.GetString(4) + "\t\t");
                    Console.Write(reader.GetString(5) + "  "); 
                    Console.WriteLine(reader.GetString(6));
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void viewAllUserInfo()
        {

            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                String cmdText = "SELECT * FROM " + dbTableMember + " JOIN " + dbTableBoats + " ON  boatId = nameId";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetString(0) + "\t");
                    Console.Write(reader.GetString(1) + "\t");
                    Console.Write(reader.GetString(2) + "\t  ");
                    Console.Write(reader.GetString(3) + "\t");
                    //hoppar över (4) då det är idt på båtarna
                    Console.Write(reader.GetString(5) + "\t\t");
                    Console.Write(reader.GetString(6) + "\t");
                    Console.WriteLine(reader.GetString(7));
                }
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void addUser(String Förnamn, String Efternamn,String SocialNumber, String NoBoats,String BoatType,String BoatLength )
        {
            try
            {
                
                con = new MySqlConnection(str);
                con.Open();
                //String cmdText = "INSERT INTO " + dbTableMember + "(firstname,lastname) VALUES(@first, @last)";
                
                String cmdText = "INSERT INTO " + dbTableMember + "(firstname,lastname,socialNumber) VALUES(@first, @last,@ssn);"
                  + "INSERT INTO " + dbTableBoats + "(noBoats,boatType,boatLength,boatId) VALUES (@nBoat,@bType,@bLength, LAST_INSERT_ID());";

                cmdMember = new MySqlCommand(cmdText, con);
                cmdMember.Parameters.AddWithValue("@first", Förnamn);
                cmdMember.Parameters.AddWithValue("@last", Efternamn);
                cmdMember.Parameters.AddWithValue("@ssn", SocialNumber);
                cmdMember.Parameters.AddWithValue("@nboat", NoBoats);
                cmdMember.Parameters.AddWithValue("@bType", BoatType);
                cmdMember.Parameters.AddWithValue("@bLength", BoatLength);
                cmdMember.ExecuteNonQuery();
                
                
                cmdMember.Prepare();

                //String boatText = "INSERT INTO " + dbTableBoats + "(noBoats)VALUES(@nboat)";
                //cmdBoat = new MySqlCommand(boatText, con);
                //cmdBoat.Parameters.AddWithValue("@nboat", NoBoats);
                //cmdBoat.ExecuteNonQuery();
                //cmdMember.ExecuteNonQuery();
              
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            } 
        }

        public void updateUser(String Förnamn, String Efternamn, String SocialNumber, String NoBoats,String BoatType,String BoatLength, int Id)
        {

            con = new MySqlConnection(str);

            String query = "UPDATE " + dbTableMember + " SET firstname = ?Förnamn, lastname = ?Efternamn, socialnumber = ?Ssn WHERE nameId = ?Id ;"
                + "UPDATE " + dbTableBoats +" SET noboats= ?NoBoats, boatType = ?BoatType, boatLength = ?BoatLength  WHERE boatId = ?Id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?Förnamn", Förnamn);
                cmd.Parameters.AddWithValue("?Efternamn", Efternamn);
                cmd.Parameters.AddWithValue("?Ssn", SocialNumber);
                cmd.Parameters.AddWithValue("?NoBoats", NoBoats);
                cmd.Parameters.AddWithValue("?BoatType", BoatType);
                cmd.Parameters.AddWithValue("?BoatLength", BoatLength);
                cmd.Parameters.AddWithValue("?Id", Id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            } 
        }
        public void removeUser(int Id)
        {
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                cmdMember = new MySqlCommand("DELETE FROM " + dbTableMember + " WHERE nameId = " + Id + "", con);
                cmdMember.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            } 
        }
    }
}
