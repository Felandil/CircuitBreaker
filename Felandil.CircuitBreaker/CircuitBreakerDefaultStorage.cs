// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerDefaultStorage.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  using System;
  using System.Runtime.Caching;

  using Felandil.CircuitBreaker.Configuration;

  /// <summary>
  /// The circuit breaker default storage.
  /// </summary>
  public class CircuitBreakerDefaultStorage : CircuitBreakerStorage
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerDefaultStorage"/> class.
    /// </summary>
    public CircuitBreakerDefaultStorage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerDefaultStorage"/> class.
    /// </summary>
    /// <param name="circuitBreakerConfiguration">
    /// The circuit breaker configuration.
    /// </param>
    public CircuitBreakerDefaultStorage(CircuitBreakerConfiguration circuitBreakerConfiguration)
      : base(circuitBreakerConfiguration)
    {
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the fail counter.
    /// </summary>
    public override int FailCounter
    {
      get
      {
        var cacheItem = Cache[this.CommandName + "FailCounter"];
        if (cacheItem != null)
        {
          return (int)cacheItem;
        }

        Cache.Add(new CacheItem(this.CommandName + "FailCounter", 0), DefaultCacheConfig);
        return 0;
      }

      protected set
      {
        Cache.Remove(this.CommandName + "FailCounter");
        Cache.Add(new CacheItem(this.CommandName + "FailCounter", value), DefaultCacheConfig);
      }
    }

    /// <summary>
    /// Gets or sets the success counter.
    /// </summary>
    public override int SuccessCounter
    {
      get
      {
        var cacheItem = Cache[this.CommandName + "SuccessCounter"];
        if (cacheItem != null)
        {
          return (int)cacheItem;
        }

        Cache.Add(new CacheItem(this.CommandName + "SuccessCounter", 0), DefaultCacheConfig);
        return 0;
      }

      protected set
      {
        Cache.Remove(this.CommandName + "SuccessCounter");
        Cache.Add(new CacheItem(this.CommandName + "SuccessCounter", value), DefaultCacheConfig);
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the cache.
    /// </summary>
    private static MemoryCache Cache
    {
      get
      {
        return MemoryCache.Default;
      }
    }

    /// <summary>
    /// Gets the default cache config.
    /// </summary>
    private static CacheItemPolicy DefaultCacheConfig
    {
      get
      {
        return new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(1440) };
      }
    }

    #endregion
  }
}