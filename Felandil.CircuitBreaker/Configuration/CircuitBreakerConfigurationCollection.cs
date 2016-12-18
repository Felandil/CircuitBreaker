// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfigurationCollection.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System.Configuration;

  /// <summary>
  /// The circuit breaker configuration collection.
  /// </summary>
  internal class CircuitBreakerConfigurationCollection : ConfigurationElementCollection
  {
    #region Properties

    /// <summary>
    /// Gets the element name.
    /// </summary>
    protected override string ElementName
    {
      get
      {
        return "Command";
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The get command by name.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <returns>
    /// The <see cref="CircuitBreakerConfigurationElement"/>.
    /// </returns>
    public CircuitBreakerConfigurationElement GetCommandByName(string name)
    {
      return (CircuitBreakerConfigurationElement)BaseGet(name);
    }

    #endregion

    #region Methods

    /// <summary>
    /// The create new element.
    /// </summary>
    /// <returns>
    /// The <see cref="ConfigurationElement"/>.
    /// </returns>
    protected override sealed ConfigurationElement CreateNewElement()
    {
      return new CircuitBreakerConfigurationElement();
    }

    /// <summary>
    /// The get element key.
    /// </summary>
    /// <param name="element">
    /// The element.
    /// </param>
    /// <returns>
    /// The <see cref="object"/>.
    /// </returns>
    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((CircuitBreakerConfigurationElement)element).Name;
    }

    #endregion
  }
}