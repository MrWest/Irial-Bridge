using System;

namespace IriaBridge.Presenter
{
    public interface IItemPresenter
    {
        int ItemId { get;  }
        decimal Price { get; }
        String Version { get; }
    }
}