using System;

namespace Domain
{
    public static class Settings
    {
        public static string ConnectionString()
        {
            return "DataSource=../DataBase.db";
            
            //return "Server=172.16.107.164,2733;DataBase=FeraJoer;User id=dba;Password=m4st3rpw1";
        }


        public static string Secret = "fedaf7d8863b48e197b9287d492b708e";

    }
}
