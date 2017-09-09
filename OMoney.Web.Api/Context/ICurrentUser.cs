using OMoney.Domain.Core.Entities;

namespace OMoney.Web.Api.Context
{
    public interface ICurrentUser
    {
        User GetCurrentUser();
    }
}
