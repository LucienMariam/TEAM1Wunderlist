using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface IUserService :IService<UserEntity>
    {
        UserEntity GetUserEntityById(Guid userId);
        UserEntity GetUserEntityByName(string name);
    }
}
