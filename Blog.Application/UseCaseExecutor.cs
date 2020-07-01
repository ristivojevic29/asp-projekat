using Blog.Application;
using Blog.Application.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;

namespace Blog.Api
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;
        public UseCaseExecutor(IApplicationActor actor,IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }
        public void ExecuteCommand<TRequest>(ICommand<TRequest>command,TRequest request)
        {
            _logger.Log(command, _actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            command.Execute(request);
        }
        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            _logger.Log(query, _actor, search);
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }
            return query.Execute(search);
        }

        public void ExecuteCommandUpdate<TRequest>(ICommandUpdate<TRequest,int> command, TRequest request,int id)
        {
            _logger.Log(command,_actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            command.Execute(request,id);
        }
        public void ExecuteCommandComment<TRequest>(ICommandComment<TRequest, int> command, TRequest request, int id)
        {
            _logger.Log(command, _actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            command.Execute(request, id);
        }
        public void ExecuteCommandWithPicture<TRequest,TImage>(ICommandWithPicture<TRequest ,TImage> command,TRequest request, TImage image)
        {
            _logger.Log(command, _actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }
            command.Execute(request, image);
        }
    }
}
