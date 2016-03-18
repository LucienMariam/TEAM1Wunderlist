using BLL.Entities;
using DAL.Entities;
using BLL.Mappers;

namespace BLL.Mappers
{
    public class FolderMapper: IMapper<FolderDal, FolderEntity>
    {
        public FolderEntity ToBll(FolderDal item)
        {
            return new FolderEntity()
            {
                Id = item.Id,
                UserId = item.UserId,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }

        public FolderDal ToDal(FolderEntity item)
        {
            return new FolderDal()
            {
                Id = item.Id,
                UserId = item.UserId,
                ParentFolderId = item.ParentFolderId,
                Title = item.Title
            };
        }
    }
}
