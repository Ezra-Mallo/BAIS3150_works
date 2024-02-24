using BAIST3150ASPNETCoreEmpty.TechnicalServices;

namespace BAIST3150ASPNETCoreEmpty.Domain
{
    public class BCS
    {
        public DatabaseUser FindDatabaseUser()
        {
            DatabaseUsers DatabaseUserManager = new();

            DatabaseUser CurrentDatabaseUser = DatabaseUserManager.GetDatabaseUsers();  

            return CurrentDatabaseUser;


        }
    }
}
