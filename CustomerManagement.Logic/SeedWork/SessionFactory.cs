﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

using NHibernate;
using NHibernate.Event;

using System.Reflection;

namespace CustomerManagement.Logic.SeedWork
{
    public  class SessionFactory
    {
        private readonly ISessionFactory factory;

        public SessionFactory(string connectionString, EventListener eventListener)
        {
            factory = BuildSessionFactory(connectionString, eventListener);
        }

        internal  ISession OpenSession()
        {
            return factory.OpenSession();
        }
        

        public static ISessionFactory BuildSessionFactory(string connectionString, EventListener eventListener)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                .AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(
                    ForeignKey.EndsWith("ID"),
                    ConventionBuilder.Property.When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                .Conventions.Add<OtherConvention>()
                .Conventions.Add<TableNameConvention>()
                .Conventions.Add<HiLoConvention>()
                )
                .ExposeConfiguration(x =>
                {
                    x.EventListeners.PostCommitUpdateEventListeners = 
                        new IPostUpdateEventListener[] { eventListener };
                    x.EventListeners.PostCommitInsertEventListeners =
                        new IPostInsertEventListener[] { eventListener };
                    x.EventListeners.PostCommitDeleteEventListeners =
                        new IPostDeleteEventListener[] { eventListener };
                    x.EventListeners.PostCollectionUpdateEventListeners =
                        new IPostCollectionUpdateEventListener[] { eventListener };
                });

            return configuration.BuildSessionFactory();
        }

        private class OtherConvention : IHasManyConvention, IReferenceConvention
        {
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.LazyLoad();
                instance.AsBag();
                instance.Cascade.SaveUpdate();
                instance.Inverse();
            }

            public void Apply(IManyToOneInstance instance)
            {
                instance.LazyLoad(Laziness.Proxy);
                instance.Cascade.None();
                instance.Not.Nullable();
            }
        }

        public class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table(instance.EntityType.Name);
            }
        }

        public class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.HiLo("Ids", "NextHigh", "9", "EntityName = '" + instance.EntityType.Name + "'");
            }
        }

    }
}
