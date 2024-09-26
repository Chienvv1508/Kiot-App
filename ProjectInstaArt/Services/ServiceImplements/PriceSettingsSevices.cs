using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServiceImplements
{
    class PriceSettingsSevices : IPriceSettingSevices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PriceSettingsSevices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePriceSetting(PriceSetting priceSetting)
        {
            _unitOfWork.PriceSettingsRepository.Add(priceSetting);
            _unitOfWork.Commit();
        }

        public List<PriceSetting> GetAllPriceSettings(Expression<Func<PriceSetting, bool>> expression)
        {
            List<PriceSetting> priceSettings;
            priceSettings = _unitOfWork.PriceSettingsRepository.GetAll(expression).ToList();
            if(priceSettings != null)
            {
                foreach(var priceSetting in priceSettings)
                {
                    priceSetting.Unit = _unitOfWork.UnitRepository.Get(x => x.UnitId == priceSetting.UnitId);
                    priceSetting.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == priceSetting.ProductCode);
                }
            }
            return priceSettings;
        }

        public PriceSetting GetLastPriceSetting(Expression<Func<PriceSetting, bool>> expression)
        {
            PriceSetting priceSetting;
            priceSetting = _unitOfWork.PriceSettingsRepository.GetLast(expression);
            if (priceSetting != null)
            {
                priceSetting.Unit = _unitOfWork.UnitRepository.Get(x => x.UnitId == priceSetting.UnitId);
                priceSetting.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode == priceSetting.ProductCode);

            }
            return priceSetting;
        }

        public PriceSetting GetPriceSettings(Expression<Func<PriceSetting, bool>> expression)
        {
            PriceSetting priceSetting;
            priceSetting = _unitOfWork.PriceSettingsRepository.Get(expression);
            if(priceSetting != null) 
            {
                priceSetting.Unit = _unitOfWork.UnitRepository.Get(x => x.UnitId == priceSetting.UnitId);
                priceSetting.ProductCodeNavigation = _unitOfWork.ProductRepository.Get(x => x.ProductCode ==  priceSetting.ProductCode);    

            }
            return priceSetting;
        }

        public void UpdatePriceSetting(PriceSetting priceSetting)
        {
            _unitOfWork.PriceSettingsRepository.Update(priceSetting);
            _unitOfWork.Commit();
        }
    }
}
