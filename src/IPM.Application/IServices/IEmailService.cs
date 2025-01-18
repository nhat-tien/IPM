namespace IPM.Application.IServices;

public interface IEmailService
{
    void SendMail(string receiverName, string receiverAddress, string emailMessage);
}
