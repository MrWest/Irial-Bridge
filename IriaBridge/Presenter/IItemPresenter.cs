using System;

namespace IriaBridge.Presenter
{
    public interface IItemPresenter: INameablePresenter
    {
        decimal Price { get; }
        String Version { get; }

    }
}