﻿namespace BookApp.Observer;

public interface IObservable
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}