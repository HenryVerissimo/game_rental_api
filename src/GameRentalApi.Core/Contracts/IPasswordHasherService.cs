using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IPasswordHasherService
{
   string CreateHash(User user, string password);

   bool ValidateHash(User user, string password);
}