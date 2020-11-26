using System;

namespace IriaBridge.Presenter
{
    public interface INameablePresenter
    {
        String Name { get; }
        String Description { get; }
    }
}