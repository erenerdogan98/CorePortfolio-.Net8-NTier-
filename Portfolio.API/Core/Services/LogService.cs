using Microsoft.EntityFrameworkCore;
using Portfolio.API.Core.DbContext;
using Portfolio.API.Core.Dtos.Log;
using Portfolio.API.Core.Entities;
using Portfolio.API.Core.Interfaces;
using System.Security.Claims;

namespace Portfolio.API.Core.Services
{
	public class LogService(AppDbContext context) : ILogService
	{
		public async Task<IEnumerable<GetLogDto>> GetLogsAsync()
		{		
			var logs = await context.Logs
				.Select(q => new GetLogDto
				{
					CreatedAt = q.CreatedAt,
					Description = q.Description,
					UserName = q.UserName,
				})
				.OrderByDescending(q => q.CreatedAt)
				.ToListAsync();
			return logs;
		}

		public async Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User)
		{
			var logs = await context.Logs
				.Where(q => q.UserName == User.Identity.Name)
			   .Select(q => new GetLogDto
			   {
				   CreatedAt = q.CreatedAt,
				   Description = q.Description,
				   UserName = q.UserName,
			   })
			   .OrderByDescending(q => q.CreatedAt)
			   .ToListAsync();
			return logs;
		}

		public async Task SaveNewLog(string UserName, string Description)
		{
			var newLog = new Log()
			{
				UserName = UserName,
				Description = Description
			};

			await context.Logs.AddAsync(newLog);
			await context.SaveChangesAsync();
		}
	}
}
