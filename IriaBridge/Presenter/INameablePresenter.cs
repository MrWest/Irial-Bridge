using System;

namespace IriaBridge.Presenter
{
    public interface INameablePresenter: IEntityPresenter
    {
        String Name { get; }
        String Description { get; }
    }
}