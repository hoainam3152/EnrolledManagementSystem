namespace EnrolledManagementSystem.DTO.Responses
{
    public class ToBoMonResponse
    {
        public int MaToBoMon { get; set; }
        public string TenToBoMon { get; set; }

        public ToBoMonResponse()
        {

        }

        public ToBoMonResponse(int maToBoMon, string tenToBoMon)
        {
            this.MaToBoMon = maToBoMon;
            this.TenToBoMon = tenToBoMon;
        }
    }
}
