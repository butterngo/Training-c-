namespace Session1.Models
{
    using System;

    public class Customer
    {
        private string _id = Guid.NewGuid().ToString();

        public string Id
        {
            get
            {
                return _id;
            }
        }
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
