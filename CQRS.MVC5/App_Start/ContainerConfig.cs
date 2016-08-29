using Common.Core.Logging;
using Common.Interfaces.CQRS;
using Common.Interfaces.Logging;
using CQRS.MVC5.Business.Query;
using CQRS.MVC5.Business.Services;
using CQRS.MVC5.Infrastructure;
using FluentValidation;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace CQRS.MVC5
{
    public class ContainerConfig
    {
        /// <summary>
        /// Configure le container d'injection de dépendances.
        /// </summary>
        public static void RegisterContainer()
        {
            // Note : Dans un projet réel, la configuration du container se ferait dans un projet séparé, afin d'éviter
            // de devoir référencer l'ensemble des projets dans le projet web.
            var container = new Container();

            // Scope par défaut = par requête HTTP
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Configuration des dépendances
            var assemblies = GetAssemblies();
            
            // TODO : Ajouter vos dépendances ici

            // Explicite
            container.RegisterSingleton<ILogger, DebugLogger>();
            container.RegisterSingleton<ICommandQueryDispatcher, SimpleInjectorCommandQueryDispatcher>();
            container.RegisterSingleton<IComputationService, ComputationService>();
            
            // Depuis les assemblies
            container.Register(typeof(IQueryHandler<,>), assemblies);
            container.Register(typeof(ICommandHandler<>), assemblies);
            container.RegisterCollection(typeof(IValidator<>), assemblies);
            
            // Ajout des décorateurs pour gérer les autorisations, la validation & les logs
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(MonitoringQueryHandlerDecorator<,>));
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(FluentValidationQueryHandlerDecorator<,>));
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(MonitoringCommandHandlerDecorator<>));
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(FluentValidationCommandHandlerDecorator<>));

            // Vérification de la configuration
            container.Verify();

            // Application du container en tant de résolveur par défaut dans la pipeline ASP.NET MVC
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(WelcomeMessageQuery).GetTypeInfo().Assembly;
            // TODO : Ajouter vos assemblies ici
        }
    }
}