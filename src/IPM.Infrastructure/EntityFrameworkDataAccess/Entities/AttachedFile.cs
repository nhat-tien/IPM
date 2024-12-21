namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AttachedFile
{
    public int AttachedFileId { get; set; }
    public int ProjectId { get; set; }

    //Đề cương dự án
    public string? ProposalFile { get; set; }

    public string? ThuChapNhanThucHienFile { get; set; }
    public string? ToTrinhXinPhepThucHienFile { get; set; }
    public string? QuyetDinhGiaoKinhPhiFile { get; set; }
    public string? QuyetDinhThanhLapBanQuanLiFile { get; set; }
    public string? QuyetDinhChoPhepThucHienFile { get; set; }
    public string? HopDongThoaThuanMOAFile { get; set; }
}

