namespace StudentManagement
{
    public static class Config
    {
        // Change this path to where you place StudentDB.accdb
        public static string DbPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\StudentManagement_Project (2)\StudentManagement_Project\StudentManagement\StudentDB.accdb";
        public static string ConnStr =
            $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DbPath};Persist Security Info=False;";
    }
}
