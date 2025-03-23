using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Repository.Entities;
using Service.Dtos;
using Service.Interfaces;
using Service.Service;
using System.Threading.Tasks;

public class SmtpEmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _port;
    private readonly string _senderEmail;
    private readonly string _appPassword;
    private readonly IMapper _mapper;
    private readonly IService<CandidateDto> _candidateService;
    private readonly IMyDetails<Candidate> _candidateMyDetails;
    private readonly IServiceMatch _serviceMatch;

    public SmtpEmailService(IConfiguration configuration, IService<CandidateDto> candidateService, IMapper mapper, IMyDetails<Candidate> candidateMyDetails, IServiceMatch serviceMatch)
    {
        _smtpServer = configuration["Gmail:SmtpServer"];
        _port = int.Parse(configuration["Gmail:Port"]);
        _senderEmail = configuration["Gmail:SenderEmail"];
        _appPassword = configuration["Gmail:AppPassword"];
        _candidateService = candidateService;
        _mapper = mapper;
        _candidateMyDetails = candidateMyDetails;
        _serviceMatch = serviceMatch;
    }
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using var client = new SmtpClient();
        await client.ConnectAsync(_smtpServer, _port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_senderEmail, _appPassword);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("שידוכים פלוס", _senderEmail));
        message.To.Add(new MailboxAddress(toEmail, toEmail));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = body }; // שליחה כ-HTML

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    public async Task SendMatchEmailAsync(int idCandidate1, int idCandidate2)
    {
        Candidate c1 = _mapper.Map<Candidate>(_candidateService.GetById(idCandidate1));
        Candidate c2 = _mapper.Map<Candidate>(_candidateService.GetById(idCandidate2));

        if (c1 == null || c2 == null)
            throw new Exception("One or both candidates were not found.");

        string baseUrl = "https://localhost:7242/api/Match/confirm";
        string callbackUrlC1 = $"{baseUrl}?candidateId={c1.Id}&matchId={c2.Id}";
        string callbackUrlC2 = $"{baseUrl}?candidateId={c2.Id}&matchId={c1.Id}";

        string emailBodyC1 = EmailTemplateHelper.GenerateMatchEmailBody(_candidateMyDetails, c1, c2, callbackUrlC1);
        string emailBodyC2 = EmailTemplateHelper.GenerateMatchEmailBody(_candidateMyDetails, c2, c1, callbackUrlC2);

        await SendEmailAsync(c1.Email, "הצעת שידוך", emailBodyC1);
        await SendEmailAsync(c2.Email, "הצעת שידוך", emailBodyC2);
    }
    public async Task sendEmailToMatchmakerActiveMatch()
    {
        List<Matchmaker> matchmakers = _serviceMatch.GetAllMatchmakerActives();
        foreach (Matchmaker matchmaker in matchmakers) 
        {
            await SendEmailAsync(matchmaker.Email, "עדכן את ההצעה", "שלום "+ matchmaker.LastName+ " "+matchmaker.FirstName+ "עדכן את השידוכים שלך באתר ");
        }
       
    }


}
