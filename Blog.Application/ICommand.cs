using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Blog.Application
{
    public interface ICommand<TRequest>:IUseCase
    {
        void Execute(TRequest request);
    }
    public interface ICommandUpdate<TRequest,TInt> : IUseCase
    {
        void Execute(TRequest request, TInt id);
    }
    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }    
   public interface ICommandWithInt<TRequest, TInt> : IUseCase
    {
        void Execute(TRequest request, TInt id);
    }
    public interface ICommandWithPicture<TRequest,TRequestImage>:IUseCase
    {
        void Execute(TRequest request, TRequestImage image);
    }
    public interface IUseCase
    {
        public int Id { get;  }
        public string Name { get;  }
    }

}
