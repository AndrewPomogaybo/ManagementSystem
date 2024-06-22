using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ManagementSystem
{
    public class Generate
    {
        public static int GenerateId<T>( List<T> model, string id)
        {
            if(model == null || model.Count == 0)
                return 1;

            PropertyInfo idProperty = typeof(T).GetProperties()
                                               .FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) || p.Name.Equals(id, StringComparison.OrdinalIgnoreCase));

            return model.Max(item => (int)idProperty.GetValue(item)) + 1;
        }
    }
}
