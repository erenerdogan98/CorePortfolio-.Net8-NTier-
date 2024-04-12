using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.BLL.Helper;
using Portfolio.DAL.Abstract;
using Portfolio.Entities;
using Serilog;
using System.Linq.Expressions;

namespace Portfolio.BLL.Concrete
{
	public class GenericManager<T, TDto>(IGenericDAL<T> genericDAL, IMapper mapper) : IGenericService<TDto> where T : class, IEntityBase, new() where TDto : class
	{
		private static string EntityName => typeof(T).Name; // for using logging.
		public async Task TAddAsync(TDto entityDto)
		{
			try
			{
				var entity = mapper.Map<T>(entityDto);
				await genericDAL.AddAsync(entity);
				Log.Information($"{EntityName} added successfully");
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while adding {EntityName} entity");
				throw;
			}

		}

		public async Task TDeleteAsync(TDto entityDto)
		{
			try
			{
				var entity = mapper.Map<T>(entityDto);
				genericDAL.Delete(entity);
				Log.Information($"{EntityName} deleted successfully");
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while deleting {EntityName} entity");
				throw;
			}
		}

		public async Task<IEnumerable<TDto>> TGetAllAsync()
		{
			try
			{
				var entities = await genericDAL.GetAllAsync();
				var entitesDto = mapper.Map<IEnumerable<TDto>>(entities);
				return entitesDto;
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while retrieving {EntityName} entities");
				throw;
			}
		}

		public async Task<IEnumerable<TDto>> TGetAllAsync(Expression<Func<TDto, bool>> filter)
		{
			try
			{
				var expression = FilterExpressionConverter<T, TDto>.Convert(filter);
				var entities = await genericDAL.GetAllAsync(expression);
				var entitiesDto = mapper.Map<IEnumerable<TDto>>(entities);
				return entitiesDto;
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while retrieving {EntityName} entities with filter : {filter}");
				throw;
			}
		}

		public TDto TGetById(int id)
		{
			try
			{
				var entity = genericDAL.GetById(id);
				return mapper.Map<TDto>(entity);
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while retrieving {EntityName} entity with ID: {id}");
				throw;
			}
		}

		public async Task<TDto> TGetByIdAsync(int id)
		{
			try
			{
				var entity = await genericDAL.GetByIdAsync(id);
				return mapper.Map<TDto>(entity);
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while retrieving {EntityName} entity with ID: {id}");
				throw;
			}
		}

		public void TUpdate(TDto entityDto)
		{
			try
			{
				var entity = mapper.Map<T>(entityDto);
				genericDAL.Update(entity);
				Log.Information($"{EntityName} updated successfully");
			}
			catch (Exception ex)
			{
				Log.Error(ex, $"Some issues happened while updating {EntityName} entity");
				throw;
			}
		}
	}
}
