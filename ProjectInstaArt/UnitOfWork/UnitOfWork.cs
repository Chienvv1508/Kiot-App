using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectInstaArt.Contracts;
using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Repositories;
using ProjectInstaArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjectInstaArt
{
    class UnitOfWork : ProjectInstaArt.IUnitOfWork
    {
        public InstaArtVer3Context _dbContext;
       
        
        public IRoleRepository _roleReposiotry;
        public IUserRepository _userRepository;
        public IImportRepository _importRepository;
        public IImportDetail _importDetailRepository;
        public IUnitRepository _unitRepository;
       
        public IStockRepository _stockRepository;
        public IProductRepository _productRepository;
        public ICategoryRepository _categoryRepository;
        public IShelvesRepository _shelvesRepository;
        public IShelvesHistoryRepository _shelvesHistoryRepository;
        public IPriceSettingsRepository _priceSettingsRepository;

        public ICustomerRepository _customerRepository;
        public IOrderRepository _orderRepository;
        public IOrderDetailRepository _orderDetailRepository;

        //public IPriceSettingRepository _priceSettingRepository;
        public UnitOfWork(InstaArtVer3Context dbContext)
        {
            this._dbContext = dbContext;
            
            
        }

        public IRoleRepository RoleRepository
        {
            get 
            {
                return _roleReposiotry ??new RoleRepository(_dbContext);
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? new UserRepository(_dbContext);
            }
        }

        public IImportRepository ImportRepository => _importRepository ?? new ImportRepository(_dbContext);

        public IImportDetail ImportDetailRepository => _importDetailRepository ?? new ImportDetailRepository(_dbContext);

        public IUnitRepository UnitRepository => _unitRepository ?? new UnitRepository(_dbContext);

      

        public IStockRepository StockRepository => _stockRepository ?? new StockRepository(_dbContext);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dbContext);

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_dbContext);

        public IShelvesRepository ShelvesRepository => _shelvesRepository ?? new ShelvesRepository(_dbContext);

        public IShelvesHistoryRepository ShelvesHistoryRepository => _shelvesHistoryRepository?? new ShelvesHistoryRepository(_dbContext);

        public IPriceSettingsRepository PriceSettingsRepository => _priceSettingsRepository ?? new PriceSettingsRepository(_dbContext);

        public ICustomerRepository CustomerRepository => _customerRepository ?? new CustomerRepository(_dbContext);

        public IOrderRepository OrderRepository => _orderRepository ?? new OrderRepository(_dbContext);

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository?? new OrderDetailRepository(_dbContext);

        



        public void Commit()
        {
            _dbContext.SaveChanges();
          
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            
        }

        public void Rollback()
        {
          
            _dbContext.Dispose();
        }

        public async Task RollbackAsync()
        {
            
            await _dbContext.DisposeAsync();
        }
    }
}
