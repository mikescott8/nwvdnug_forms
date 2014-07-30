﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWVDNUG_Meeting_Info_v2
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    public BaseViewModel()
    {
    }

    public bool IsInitialized { get; set; }

    private bool isBusy;
    /// <summary>
    /// Gets or sets if the view is busy.
    /// </summary>
    public const string IsBusyPropertyName = "IsBusy";
    public bool IsBusy
    {
      get { return isBusy; }
      set { SetProperty(ref isBusy, value, IsBusyPropertyName); }
    }

    //private bool canLoadMore = true;
    ///// <summary>
    ///// Gets or sets if we can load more.
    ///// </summary>
    //public const string CanLoadMorePropertyName = "CanLoadMore";
    //public bool CanLoadMore
    //{
    //  get { return canLoadMore; }
    //  set { SetProperty(ref canLoadMore, value, CanLoadMorePropertyName); }
    //}

    protected void SetProperty<T>(
        ref T backingStore, T value,
        string propertyName,
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return;

        backingStore = value;

        if (onChanged != null)
            onChanged();

        OnPropertyChanged(propertyName);
    }

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    public void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged == null)
        return;

        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
