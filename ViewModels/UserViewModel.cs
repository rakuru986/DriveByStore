namespace ViewModels
{
    public class SaveUserViewModel
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string passwordHash { get; set; }
    }

    public class LoginUserViewModel
    {
        public string email { get; set; }
        public string passwordHash { get; set; }
    }



}
