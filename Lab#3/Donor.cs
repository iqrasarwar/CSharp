
namespace Donor
{
    public class donor
    {
        //readonly bcz it is suppposed to remain same
        private readonly string registrationDate;
        public int Id { get; }
        public string DonorName { get; set; }
        public int DonorAge { get; set; }
        public string DonorBloodGroup { get; set; }
        public bool IsBloodDonated { get; set; }
        public long DonorPhone { get; set; }
        public string Email { get; set; }
       
        public string RegistrationDate
        {
            get
            {
                return this.registrationDate;
            }
        }

        public donor(string name, int age, string bloodgrp, bool isdonated, long phone, string email="")
        {
            this.DonorName = name;
            this.DonorBloodGroup = bloodgrp;
            this.DonorAge = age;
            this.DonorPhone = phone;
            this.IsBloodDonated = isdonated;
            this.Email = email;
            //take date from thre system at runtime when being registered
            this.registrationDate = System.DateTime.Now.ToString("dd.MM.yyyy");
        }

    }
}
