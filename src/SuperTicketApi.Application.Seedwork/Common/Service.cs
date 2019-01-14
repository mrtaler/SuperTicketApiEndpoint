namespace SuperTicketApi.Application.Seedwork.Common
{
    using System;
    using System.Collections.Generic;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

    /*  public abstract class Service<TEntity, TEntityDto> : IService<TEntity, TEntityDto>
      where TEntity : Entity, new()
      where TEntityDto : Entity, new()
      {
          protected IRepository<TEntity> Repository;
          protected ILocalization Resources;
          protected IEntityValidator Validator;

          public Service(IRepository<TEntity> repository)
          {
              this.Repository = repository;
              this.Resources = LocalizationFactory.CreateLocalResources();
              this.Validator = EntityValidatorFactory.CreateValidator();
          }

          #region Private Methods
          private TEntity AddBase(TEntity item)
          {
              if (this.Validator.IsValid<TEntity>(item))
              {
                  this.Repository.Add(item);
                  this.Repository.UnitOfWork.Commit();
                  return item;
              }
              else
              {
                  throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
              }
          }

          private async Task<TEntity> AddBaseAsync(TEntity item)
          {
              if (this.Validator.IsValid<TEntity>(item))
              {
                  this.Repository.Add(item);
                  await this.Repository.UnitOfWork.CommitAsync();
                  return item;
              }
              else
              {
                  throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
              }
          }

          private IEnumerable<TEntity> AddBase(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Add(item);
                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              this.Repository.UnitOfWork.Commit();
              return items;
          }

          private async Task<IEnumerable<TEntity>> AddBaseAsync(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Add(item);
                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              await this.Repository.UnitOfWork.CommitAsync();
              return items;

          }

          private void RemoveBase(TEntity item)
          {
              this.Repository.Remove(item);
              this.Repository.UnitOfWork.Commit();
          }

          private async Task RemoveBaseAsync(TEntity item)
          {
              this.Repository.Remove(item);
              await this.Repository.UnitOfWork.CommitAsync();
          }

          private void RemoveBase(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (item != null) this.Repository.Remove(item);
              }

              this.Repository.UnitOfWork.Commit();
          }

          private async Task RemoveBaseAsync(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (item != null) this.Repository.Remove(item);
              }

              await this.Repository.UnitOfWork.CommitAsync();
          }

          private TEntity ModifyBase(TEntity item)
          {
              if (this.Validator.IsValid<TEntity>(item))
              {
                  this.Repository.Modify(item);
                  this.Repository.UnitOfWork.Commit();
                  return item;
              }
              else
              {
                  throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
              }
          }

          private async Task<TEntity> ModifyBaseAsync(TEntity item)
          {
              if (this.Validator.IsValid<TEntity>(item))
              {
                  this.Repository.Modify(item);
                  await this.Repository.UnitOfWork.CommitAsync();
                  return item;
              }
              else
              {
                  throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
              }
          }

          private TEntity ModifyBase(object id, TEntity item)
          {
              var persisted = this.Get(id);
              if (persisted != null)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Merge(persisted, item);
                      this.Repository.UnitOfWork.Commit();
                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              return persisted;
          }

          private async Task<TEntity> ModifyBaseAsync(object id, TEntity item)
          {
              var persisted = this.Get(id);
              if (persisted != null)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Merge(persisted, item);
                      await this.Repository.UnitOfWork.CommitAsync();
                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              return persisted;
          }

          private IEnumerable<TEntity> ModifyBase(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Modify(item);
                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              this.Repository.UnitOfWork.Commit();
              return items;
          }

          private async Task<IEnumerable<TEntity>> ModifyBaseAsync(IEnumerable<TEntity> items)
          {
              foreach (var item in items)
              {
                  if (this.Validator.IsValid<TEntity>(item))
                  {
                      this.Repository.Modify(item);

                  }
                  else
                  {
                      throw new ApplicationValidationErrorsException(this.Validator.GetInvalidMessages<TEntity>(item));
                  }
              }

              await this.Repository.UnitOfWork.CommitAsync();
              return items;
          }

          #endregion

          #region Public Methods
          public virtual TEntity Add(TEntity item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              return this.AddBase(item);
          }

          public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              return this.AddBase(items);
          }

          public virtual TEntityDto Add(TEntityDto item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              var entity = this.AddBase(item.ProjectedAs<TEntity>());

              if (entity != null)
              {
                  return entity.ProjectedAs<TEntityDto>();
              }

              return null;
          }

          public virtual IList<TEntityDto> Add(IList<TEntityDto> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              var entities = this.AddBase(items.ProjectedAsCollection<TEntity>());

              if (entities != null)
              {
                  return entities.ProjectedAsCollection<TEntityDto>();
              }

              return null;
          }

          public virtual void Remove(TEntity item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.RemoveBase(item);
          }

          public virtual void Remove(IEnumerable<TEntity> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.RemoveBase(items);
          }

          public virtual void Remove(TEntityDto item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.RemoveBase(item.ProjectedAs<TEntity>());
          }

          public virtual void Remove(IList<TEntityDto> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.RemoveBase(items.ProjectedAsCollection<TEntity>());
          }

          public virtual TEntity Modify(TEntity item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              return this.ModifyBase(item);
          }

          public virtual IEnumerable<TEntity> Modify(IEnumerable<TEntity> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              return this.ModifyBase(items);
          }

          public virtual TEntityDto Modify(TEntityDto item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              var entity = this.ModifyBase(item.ProjectedAs<TEntity>());
              if (entity != null)
              {
                  return entity.ProjectedAs<TEntityDto>();
              }

              return null;
          }

          public virtual IList<TEntityDto> Modify(IList<TEntityDto> items)
          {
              if (items == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              var entities = this.ModifyBase(items.ProjectedAsCollection<TEntity>());
              if (entities != null)
              {
                  return entities.ProjectedAsCollection<TEntityDto>();
              }

              return null;
          }

          public virtual void Refresh(TEntity item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.Repository.Refresh(item);
          }

          public virtual void Refresh(TEntityDto item)
          {
              if (item == null)
              {
                  throw new ArgumentException(this.Resources.GetStringResource(LocalizationKeys.Application.ValidationNoRecordsFoundError));
              }

              this.Repository.Refresh(item.ProjectedAs<TEntity>());
          }

          public virtual TEntity Get(object id)
          {
              if (id != null)
                  return this.Repository.Get(id);
              else
                  return null;
          }

          public virtual TEntityDto GetDto(object id)
          {
              TEntity entity = null;
              if (id != null) entity = this.Repository.Get(id);
              if (entity != null) return entity.ProjectedAs<TEntityDto>();
              return null;
          }

          public virtual IEnumerable<TEntity> GetAll()
          {
              return this.Repository.GetAll();
          }

          public virtual IList<TEntityDto> GetAllDto()
          {
              var entities = this.Repository.GetAll();
              if (entities != null)
              {
                  return entities.ProjectedAsCollection<TEntityDto>();
              }

              return null;
          }
          #endregion
      }
      */
}
