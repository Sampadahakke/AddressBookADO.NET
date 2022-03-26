using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBookADO.NET
{
    public class AddressbookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        
        //Creating method to get contacts from address book
        public bool GetContacts()
        {
            try
            {
                //Creating object of class
                AddressbookModel model = new AddressbookModel();
                using (this.connection)
                {
                    string query = @"Select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.FirstName=Convert.ToString(dr["FirstName"]);
                            model.LastName = Convert.ToString(dr["LastName"]);
                            model.Address = Convert.ToString(dr["Address"]);
                            model.City = Convert.ToString(dr["City"]);
                            model.State = Convert.ToString(dr["State"]);
                            model.Zip = Convert.ToInt32(dr["Zip"]);
                            model.PhoneNumber =Convert.ToInt64(dr["PhoneNumber"]);
                            model.BookName = Convert.ToString(dr["BookName"]);
                            model.Type = Convert.ToString(dr["Type"]);

                            Console.WriteLine("\nFirst name = " + model.FirstName + "\nLast name = " + model.LastName + "\nAddress = " + model.Address + "\nCity = " + model.City + "\nState = " + model.State+"\nZip = " + model.Zip+"\nPhone number =  " + model.PhoneNumber+"\nBook name = "+model.BookName+"\nType =  "+model.Type);
                            Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Creating method to add contacts
        public bool AddContacts(AddressbookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddContactDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@Type", model.Type);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

    
    }

}


