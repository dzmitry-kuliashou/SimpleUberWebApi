using Castle.Windsor;

namespace SimpleUber.Distribution.Host.Installers
{
    public static class WindsorContainer
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get
            {
                if(_container == null)
                {
                    _container = new Castle.Windsor.WindsorContainer();
                }

                return _container;
            }
        }
    }
}