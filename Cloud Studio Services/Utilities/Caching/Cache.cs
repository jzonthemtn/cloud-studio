﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.Services.Utilities.Caching {

    public interface Cache {

        void Add(string key, object value);
        void Remove(string key);
        object Get(string key);
        bool ContainsKey(string key);

    }

}
