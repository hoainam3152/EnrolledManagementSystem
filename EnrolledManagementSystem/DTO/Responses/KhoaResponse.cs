namespace EnrolledManagementSystem.DTO.Responses
{
    public class KhoaResponse
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public KhoaResponse()
        {

        }

        public KhoaResponse(string maKhoa, string tenKhoa)
        {
            this.MaKhoa = maKhoa;
            this.TenKhoa = tenKhoa;
        }
    }
}
