// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfigurationElement.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System;
  using System.Configuration;

  /// <summary>
  /// The circuit breaker default configuration element.
  /// </summary>
  internal class CircuitBreakerConfigurationElement : ConfigurationElement
  {
    #region Public Properties

    /// <summary>
    /// Gets the failure threshold.
    /// </summary>
    [ConfigurationProperty("failureThreshold", IsRequired = true)]
    public int FailureThreshold
    {
      get
      {
        return (int)this["failureThreshold"];
      }
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    [ConfigurationProperty("name", IsRequired = true)]
    public string Name
    {
      get
      {
        return (string)this["name"];
      }
    }

    /// <summary>
    /// Gets the open time.
    /// </summary>
    [ConfigurationProperty("openTime", IsRequired = true)]
    public TimeSpan OpenTime
    {
      get
      {
        return (TimeSpan)this["openTime"];
      }
    }

    /// <summary>
    /// Gets the success threshold.
    /// </summary>
    [ConfigurationProperty("successThreshold", IsRequired = true)]
    public int SuccessThreshold
    {
      get
      {
        return (int)this["successThreshold"];
      }
    }

    #endregion
  }
}