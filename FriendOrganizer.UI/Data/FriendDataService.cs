using System.Collections.Generic;
using FriendOrganizer.Model;
namespace FriendOrganizer.UI.Data
{
    class FriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Thomas", LastName = "Coolman" };
            yield return new Friend { FirstName = "John", LastName = "Doe" };
            yield return new Friend { FirstName = "Nancy", LastName = "Daughtfire" };
            yield return new Friend { FirstName = "Andy", LastName = "Hubernito" };
        }
    }
}
