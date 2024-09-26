using ProjectInstaArt.Contracts;

namespace ProjectInstaArt
{
    public interface IUnitOfWork
    {
        IImportRepository ImportRepository { get; }
        IRoleRepository RoleRepository { get; }
        IImportDetail ImportDetailRepository { get; }

        IUnitRepository UnitRepository { get; }


        IStockRepository StockRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        //  IPriceSettingRepository PriceSettingRepository { get; }

        IUserRepository UserRepository { get; }

        IShelvesRepository ShelvesRepository { get; }
        IShelvesHistoryRepository ShelvesHistoryRepository { get; }
        
        IPriceSettingsRepository PriceSettingsRepository { get; }

        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
