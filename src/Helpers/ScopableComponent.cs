using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace pusher.Helpers
{

    public class ScopableComponent<T> : ScopableComponent 
    {

        public T Service => GetService<T>();

    }

    public class ScopableComponent : ComponentBase
    {

        [Inject]
        public IServiceProvider CurrentServiceProvider { get; set; }

        private IServiceScope _scope;

        public T GetService<T>()
        {
            if (_scope == null)
            {
                _scope = CurrentServiceProvider.CreateScope();
            }
            return _scope.ServiceProvider.GetService<T>();
        }

        public void ClearService()
        {
            _scope.Dispose();
            _scope = null;
        }

    }
}
