using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAbstraction;
using BLL.Entities;

namespace Epam.Wunderlist.PhotoService
{
    public interface IPhotoService: IService<UserEntity>
    {
        void Post();
    }
}
