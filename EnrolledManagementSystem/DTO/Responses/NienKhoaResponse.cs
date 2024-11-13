namespace EnrolledManagementSystem.DTO.Responses
{
    public class NienKhoaResponse
    {
        public string MaNienKhoa { get; set; }
        public string TenNiemKhoa { get; set; }

        public NienKhoaResponse()
        {

        }

        public NienKhoaResponse(string maNienKhoa, string tenNienKhoa)
        {
            this.MaNienKhoa = maNienKhoa;
            this.TenNiemKhoa = tenNienKhoa;
        }
    }
}
