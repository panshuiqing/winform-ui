using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;
using Tlw.ZPG.Infrastructure;

namespace Tlw.ZPG.Services.Common
{
    public class DictionaryService : ServiceBase<Dictionary>
    {
        public override void Insert(Tlw.ZPG.Domain.Models.Dictionary entity)
        {
            base.Insert(entity);
            SetDictionaryCache(entity);
        }

        public override void Delete(Dictionary entity)
        {
            base.Delete(entity);
            SetDictionaryCache(entity);
        }

        public override void Update(Dictionary entity)
        {
            base.Update(entity);
            SetDictionaryCache(entity);
        }

        private void SetDictionaryCache(Dictionary entity)
        {
            var map = Application.GetDictionary();
            if (map == null)
            {
                map = new Dictionary<string, string>();
            }
            if (map.ContainsKey(entity.DictionaryName))
            {
                map[entity.DictionaryName] = entity.DictionaryValue;
            }
            Application.SetDictionaryCache(map);
        }
    }
}
