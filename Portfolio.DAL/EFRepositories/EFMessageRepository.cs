using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFMessageRepository(AppDbContext context) : GenericRepository<Message>(context), IMessageDAL
    {
        public void ChangeMessageStatus(Message message)
        {
            // same operations with Update method (in Generic) , but this is for only change status 
            var entityEntry = context.Entry<Message>(message);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
            
        }     
    }
}
