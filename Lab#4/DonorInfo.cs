namespace DonorInfo
{
    public class DonorInformation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string ReceptorName { get; set; }
        public string Date { get; set; }

        public DonorInformation(int donorid,string rname)
        {
            this.DonorId = donorid;
            this.ReceptorName = rname;
            //get the date of donation at runtime
            this.Date = System.DateTime.Now.ToString("dd.MM.yyyy"); ;
        }
    }
}
