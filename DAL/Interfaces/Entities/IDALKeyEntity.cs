using System;

namespace DAL.Interfaces.Entities
{
    public interface IDALKeyEntity: IDALEntity
    {
        Guid Id { get; set; }
    }
}
