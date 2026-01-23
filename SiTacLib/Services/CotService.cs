using Microsoft.Extensions.Logging;
using SiTacLib.Models.CoT;

namespace SiTacLib.Services;

public class CotService
{
    private readonly ILogger<CotService> _logger;
    private readonly ICotRepository _repository;
    
    public CotService(ILogger<CotService> logger, ICotRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    public void ProcessIncomingCot(string cotXml)
    {
        try
        {
            CotEvent cotEvent = CotEvent.FromXml(cotXml);
            cotEvent.Validate();
            // _repository.Save(cotEvent);
        }
        catch (CotValidationException e)
        {
            _logger.LogWarning(e, "Received malformed CoT Event: {Xml}", cotXml);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to process CoT Event: {Xml}", cotXml);
        }
    }
}