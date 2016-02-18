using System;

namespace DAL.Interfaces.Entities
{
    interface IDALKeyEntity: IDALEntity
    {
        Guid Id { get; set; }
    }
}
