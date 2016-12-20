// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfigurationSection.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System.Configuration;

  /// <summary>
  /// The circuit breaker configuration section.
  /// </summary>
  public class CircuitBreakerConfigurationSection : ConfigurationSection
  {
    #region Public Properties

    /// <summary>
    /// Gets the commands.
    /// </summary>
    [ConfigurationProperty("Commands", IsDefaultCollection = false)]
    [ConfigurationCollection(typeof(CircuitBreakerConfigurationCollection))]
    public CircuitBreakerConfigurationCollection Commands
    {
      get
      {
        return (CircuitBreakerConfigurationCollection)base["Commands"];
      }
    }

    #endregion
  }
}