namespace WordPractic
{
    public  class Myinformation
    {
        public  string Name { get;set; }
        public  string SurName { get; set; }
        public  string Patronymic { get; set; }
        public Myinformation(string name,string surname, string patronymic)
        {
            Name = name; 
            SurName = surname; 
            Patronymic = patronymic;
        }
    }
}
