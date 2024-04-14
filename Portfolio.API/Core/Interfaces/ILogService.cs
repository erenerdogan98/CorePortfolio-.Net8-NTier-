using Portfolio.API.Core.Dtos.Log;
using System.Security.Claims;

namespace Portfolio.API.Core.Interfaces
{
	public interface ILogService
	{
		Task SaveNewLog(string UserName, string Description);
		Task<IEnumerable<GetLogDto>> GetLogsAsync();
		Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User);
	}
}
