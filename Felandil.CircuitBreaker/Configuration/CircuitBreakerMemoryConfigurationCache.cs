// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerMemoryConfigurationCache.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System;
  using System.Runtime.Caching;

  /// <summary>
  /// The circuit breaker memory configuration cache.
  /// </summary>
  public class CircuitBreakerMemoryConfigurationCache : IConfigurationCache
  {
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

    #region Public Methods and Operators

    /// <summary>
    /// The get configuration element.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="CircuitBreakerConfigurationElement"/>.
    /// </returns>
    public CircuitBreakerConfigurationElement GetConfigurationElement(string commandName)
    {
      return (CircuitBreakerConfigurationElement)Cache.Get(string.Format("{0}_Configuration", commandName));
    }

    /// <summary>
    /// The save configuration element.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    public void SaveConfigurationElement(CircuitBreakerConfigurationElement element)
    {
      var cacheKey = string.Format("{0}_Configuration", element.Name);

      if (Cache.Get(cacheKey) != null)
      {
        Cache.Remove(cacheKey); 
      }

      Cache.Set(cacheKey, element, DefaultCacheConfig);
    }

    #endregion
  }
}