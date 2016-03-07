﻿using BLL.Concrete.Entities;
using DAL.Concrete.Entities;

namespace BLL.Concrete.Mappers
{
    public class FolderMapper: IMapper<FolderDal, FolderEntity>
    {
        public FolderEntity ToBll(FolderDal item)
        {
            return new FolderEntity()
            {
                Id = item.Id,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }

        public FolderDal ToDal(FolderEntity item)
        {
            return new FolderDal()
            {
                Id = item.Id,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }
    }
}
