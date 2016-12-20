// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryConfigurationCache.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using Felandil.CircuitBreaker.Configuration;

  /// <summary>
  /// The in memory configuration cache.
  /// </summary>
  internal class InMemoryConfigurationCache : IConfigurationCache
  {
    #region Fields

    /// <summary>
    /// The get config called times.
    /// </summary>
    public int ConfigLoadedFromCache = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the element.
    /// </summary>
    private CircuitBreakerConfigurationElement Element { get; set; }

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
      if (this.Element != null)
      {
        this.ConfigLoadedFromCache++;
      }

      return this.Element;
    }

    /// <summary>
    /// The save configuration element.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    public void SaveConfigurationElement(CircuitBreakerConfigurationElement element)
    {
      this.Element = element;
    }

    #endregion
  }
}