namespace Donor
{
    public class donor
    {
        //readonly bcz it is suppposed to remain same
        private readonly string registrationDate;
        private int id;
        public int Id 
        { 
            get
            {
                return id;
            }
        }
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
        public donor(int id, string name, int age, string bloodgrp, bool isdonated, long phone, string regDate, string email="")
        {
            this.DonorName = name;
            this.DonorBloodGroup = bloodgrp;
            this.DonorAge = age;
            this.DonorPhone = phone;
            this.IsBloodDonated = isdonated;
            this.Email = email;
            this.registrationDate = regDate;
            this.id = id;
        }
        public override string ToString()
        {
            string output = string.Format(
                    format: "DonorId: {0}\nDonorName: {1}\nDonorBloodGroup: {2}\n",
                    arg0: this.id,
                    arg1: this.DonorName,
                    arg2: this.DonorBloodGroup
                    );
            string output1 = string.Format(
                format: "DonorAge: {0}\nDonorStatus: {1}\nDonorPhone: {2}\n",
                arg0: this.DonorAge,
                arg1: this.IsBloodDonated,
                arg2: this.DonorPhone
                );
            string output2 = string.Format(
                format: "RegistrationDate: {0}\nDonorEmail: {1}\n",
                arg0: this.registrationDate,
                arg1: this.Email
                );
            return output + output1 + output2;
        }
    }
}
