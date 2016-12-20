// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationCache.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  /// <summary>
  /// The ConfigurationCache interface.
  /// </summary>
  public interface IConfigurationCache
  {
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
    CircuitBreakerConfigurationElement GetConfigurationElement(string commandName);

    /// <summary>
    /// The save configuration element.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    void SaveConfigurationElement(CircuitBreakerConfigurationElement element);

    #endregion
  }
}