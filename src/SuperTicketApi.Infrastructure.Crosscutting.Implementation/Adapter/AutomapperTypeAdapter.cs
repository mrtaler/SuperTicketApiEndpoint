﻿namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter
{
    using AutoMapper;

    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter
        : ITypeAdapter
    {
        #region ITypeAdapter Members

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="source">
        /// The <paramref name="source"/>.
        /// </param>
        /// <typeparam name="TSource">t Source
        /// </typeparam>
        /// <typeparam name="TTarget">T Target
        /// </typeparam>
        /// <returns>
        /// The <see cref="TTarget"/>.
        /// </returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="source">
        /// The <paramref name="source"/>.
        /// </param>
        /// <typeparam name="TTarget">d d 
        /// </typeparam>
        /// <returns>
        /// The <see cref="TTarget"/>.
        /// </returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion
    }
}
