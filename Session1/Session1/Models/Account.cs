namespace Session1.Models
{
    using System;

    public class Account
    {
        private string _id = Guid.NewGuid().ToString();

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
