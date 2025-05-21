using MySql.Data.MySqlClient;

class Program
{
    static string connStr = "server=localhost;user=root;password=Admin@123;database=DotnetAssessment;";
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Enter a choice");
            Console.WriteLine("------------------");
            Console.WriteLine("1.Insert");
            Console.WriteLine("2.Read");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");
            Console.WriteLine("5.Search");
            Console.WriteLine("6.Exit");
            Console.WriteLine("------------------");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    InsertData();
                    break;
                case 2:
                    ReadData();
                    break;
                case 3:
                    UpdateData();
                    break;
                case 4:
                    DeleteData();
                    break;
                case 5:
                    SearchData();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
    static void InsertData()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Enter the Bin:");
        string bin = Console.ReadLine();
        Console.WriteLine("Enter the Bin Location:");
        string binLocation = Console.ReadLine();
        Console.WriteLine("Enter the Waste Type:");
        string wasteType = Console.ReadLine();
        Console.WriteLine("Enter the Pickup Schedule:");
        string pickupSchedule = Console.ReadLine();
        Console.WriteLine("Enter the Driver:");
        string driver = Console.ReadLine();
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "INSERT INTO WasteManagement(Bin,Bin_Location, Waste_Type, Pickup_Schedule, Driver) VALUES(@bin,@binLocation, @wasteType, @pickupSchedule, @driver)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bin", bin);
            cmd.Parameters.AddWithValue("@binLocation", binLocation);
            cmd.Parameters.AddWithValue("@wasteType", wasteType);
            cmd.Parameters.AddWithValue("@pickupSchedule", pickupSchedule);
            cmd.Parameters.AddWithValue("@driver", driver);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted Successfully!");
            Console.WriteLine("--------------------------------------------------------");
            conn.Close();
        }
    }
    static void ReadData()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "SELECT * FROM WasteManagement";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(reader["Bin"] + " | " + reader["Bin_Location"] + " | " + reader["Waste_Type"] + " | " + reader["Pickup_Schedule"] + " | " + reader["Driver"] + " | ");
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
            conn.Close();
        }
    }
    static void UpdateData()
    {
        Console.WriteLine("Enter the Bin to Update:");
        string bin = Console.ReadLine();
        Console.WriteLine("Enter the Bin Location:");
        string binLocation = Console.ReadLine();
        Console.WriteLine("Enter the Waste Type:");
        string wasteType = Console.ReadLine();
        Console.WriteLine("Enter the Pickup Schedule:");
        string pickupSchedule = Console.ReadLine();
        Console.WriteLine("Enter the Driver to be Assigned:");
        string driver = Console.ReadLine();
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "UPDATE WasteManagement SET Waste_Type=@wasteType, Pickup_Schedule=@pickupSchedule,Bin_Location=@binLocation, Driver=@driver WHERE Bin=@bin";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bin", bin);
            cmd.Parameters.AddWithValue("@wasteType", wasteType);
            cmd.Parameters.AddWithValue("@pickupSchedule", pickupSchedule);
            cmd.Parameters.AddWithValue("@driver", driver);
            cmd.Parameters.AddWithValue("@binLocation", binLocation);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Updated Successfully!");
            Console.WriteLine("--------------------------------------------------------");
            conn.Close();
        }
    }
    static void DeleteData()
    {
        Console.WriteLine("Enter the Bin to Delete:");
        string bin = Console.ReadLine();
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "DELETE FROM WasteManagement WHERE Bin=@bin";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bin", bin);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Deleted Successfully!");
            Console.WriteLine("--------------------------------------------------------");
            conn.Close();
        }
    }
    static void SearchData()
    {
        Console.WriteLine("Enter the Waste Type to Search:");
        string wasteType = Console.ReadLine();
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "SELECT * FROM WasteManagement WHERE Waste_Type=@wasteType";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@wasteType", wasteType);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Here is your searched data:");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(reader["Bin"] + " | " + reader["Bin_Location"] + " | " + reader["Pickup_Schedule"] + " | " + reader["Driver"] + " | ");
                Console.WriteLine("----------------------------------------------------------");
            }
            conn.Close();
        }
    }
}
