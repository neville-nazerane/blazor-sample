using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace pusher.Helpers
{

    public class ScopeAccess<T> : ScopeAccess
    {

        public ScopeAccess(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public T Service => GetService<T>();

    }

    public class ScopeAccess 
    {

        public IServiceProvider CurrentServiceProvider { get; set; }

        private IServiceScope _scope;

        public ScopeAccess(IServiceProvider serviceProvider)
        {
            CurrentServiceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            if (_scope == null)
            {
                _scope = CurrentServiceProvider.CreateScope();
            }
            return _scope.ServiceProvider.GetService<T>();
        }

        public void ClearScope()
        {
            _scope.Dispose();
            _scope = null;
        }

    }
}
