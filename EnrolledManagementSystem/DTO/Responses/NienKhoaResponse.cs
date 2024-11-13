namespace EnrolledManagementSystem.DTO.Responses
{
    public class NienKhoaResponse
    {
        public string MaNienKhoa { get; set; }
        public string TenNienKhoa { get; set; }

        public NienKhoaResponse()
        {

        }

        public NienKhoaResponse(string maNienKhoa, string tenNienKhoa)
        {
            this.MaNienKhoa = maNienKhoa;
            this.TenNienKhoa = tenNienKhoa;
        }
    }
}
