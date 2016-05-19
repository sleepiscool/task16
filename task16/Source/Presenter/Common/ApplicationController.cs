using Aapplication_model.IoC;

namespace Presenter.Common
{
    public class ApplicationController : IApplicationController 
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
            //RegisterInstance метод обеспечивает аналогичную функцию зависимостей к RegisterType метода 
            //    (при использовании с ContainerControlledLifetimeManager ) 
            //в том , что он создает регистрацию , которая всегда возвращает ссылку на тот же экземпляр 
            //указанного объекта, до тех пор , как этот объект находится в области видимости. 
            //    RegisterType метод с ContainerControlledLifetimeManager автоматически генерирует этот единичный случай 
            //        в первый раз , когда ваш код вызывает его, и RegisterInstance метод принимает существующий экземпляр , 
            //            для которого он будет возвращать ссылки.
            //В RegisterInstance метод перегружает принимает дополнительный параметр-экземпляр объекта для регистрации,
            //по сравнению с RegisterType методом перегрузками, но использование типа регистрации и необязательное 
            //имя идентичны. В следующем примере показано , как можно использовать RegisterInstance метод для 
            //регистрации существующих экземпляров объектов, реализующих IMyService интерфейс. В этом примере 
            //    используется как общий характер и не-родовые перегруженных методов контейнера.

            _container.RegisterInstance<IApplicationController>(this);
        }

        //public IApplicationController RegisterView<TView, TImplementation>()
        //    where TImplementation : class, TView
        //    where TView : IView
        //{
        //    _container.Register<TView, TImplementation>();
        //    return this;
        //}

        //public IApplicationController RegisterView<TView, TImplementation>(LifeTime lifeTime)
        //    where TImplementation : class, TView
        //    where TView : IView
        //{
        //    _container.Register<TView, TImplementation>(lifeTime);
        //    return this;
        //}

        //public IApplicationController RegisterInstance<TArgument>(TArgument instance)
        //{
        //    _container.RegisterInstance(instance);
        //    return this;
        //}

        //public IApplicationController RegisterInstance<TInstance>(TInstance instance, LifeTime lifeTime)
        //{
        //    _container.RegisterInstance(instance);
        //    return this;
        //}
        //Эта функция создает новый экземпляр службы.
        //public IApplicationController RegisterService<TModel, TImplementation>()
        //    where TImplementation : class, TModel
        //{
        //    _container.Register<TModel, TImplementation>();
        //    return this;
        //}

        //public IApplicationController RegisterService<TModel, TImplementation>(LifeTime lifeTime)
        //    where TImplementation : class, TModel
        //{
        //    _container.Register<TModel, TImplementation>();
        //    return this;
        //}


        public IApplicationController RegisterView<TView, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer)
        {
            throw new System.NotImplementedException();
        }

        public IApplicationController RegisterInstance<TArgument>(TArgument instance)
        {
            throw new System.NotImplementedException();
        }

        public IApplicationController RegisterInstance<TArgument>(TArgument instance, LifeTime lifeTime = LifeTime.PerContainer)
        {
            throw new System.NotImplementedException();
        }

        public IApplicationController RegisterService<TService, TImplementation>() where TImplementation : class, TService
        {
            throw new System.NotImplementedException();
        }

        public IApplicationController RegisterService<TService, TImplementation>(LifeTime lifeTime = LifeTime.PerContainer) where TImplementation : class, TService
        {
            throw new System.NotImplementedException();
        }

        public TService Resolve<TService>()
        {
            throw new System.NotImplementedException();
        }
    }
}
