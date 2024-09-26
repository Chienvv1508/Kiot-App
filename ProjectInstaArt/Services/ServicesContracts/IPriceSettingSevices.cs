using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    interface IPriceSettingSevices
    {
        /// <summary>
        /// Get PriceSetting by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        PriceSetting GetPriceSettings(Expression<Func<PriceSetting, bool>> expression);
        /// <summary>
        /// Get All PriceSetting by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        List<PriceSetting> GetAllPriceSettings(Expression<Func<PriceSetting, bool>> expression);

        void CreatePriceSetting(PriceSetting priceSetting);

        void UpdatePriceSetting(PriceSetting priceSetting);
        PriceSetting GetLastPriceSetting(Expression<Func<PriceSetting, bool>> expression);
    }
}
