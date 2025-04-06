using APICore.Modal;

namespace APICore.Service
{
    public interface IEmailService
    {
        Task SendEmail(Mailrequest mailrequest, string v);
    }
}
